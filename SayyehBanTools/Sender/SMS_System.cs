using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net;

namespace SayyehBanTools.Sender;

public class SMS_System
{
    /// <summary>
    /// ارسال به صورت پترن
    /// </summary>
    /// <param name="APILink"></param>
    /// <param name="APIKey"></param>
    /// <param name="data"></param>
    /// <param name="patternCode"></param>
    /// <param name="from"></param>
    /// <param name="to"></param>
    /// <returns></returns>
    public static async Task<(HttpWebResponse Response, string ResponseContent)> SendPatternAsync(string APILink, string APIKey, Dictionary<string, object> data, string patternCode, string from, string to)
    {
        // Create JSON payload
        string jsonPayload = JsonConvert.SerializeObject(new
        {
            code = patternCode,
            sender = from,
            recipient = to,
            variable = data
        });

        try
        {
            // Construct HTTP POST request
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(APILink ?? "https://api2.ippanel.com/api/v1/sms/pattern/normal/send");
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Headers["apikey"] = APIKey;

            // Send JSON payload asynchronously
            using (var writer = new StreamWriter(await request.GetRequestStreamAsync()))
            {
                await writer.WriteAsync(jsonPayload);
                await writer.FlushAsync(); // Ensure data is flushed before closing the stream
            }

            // Get response asynchronously
            HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync();
            using (var stream = response.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                string responseContent = await reader.ReadToEndAsync();
                return (response, responseContent);
            }
        }
        catch (WebException ex)
        {
            Console.WriteLine("Error sending SMS: " + ex.Message);
            return (null, ex.Message); // Return null response and error message
        }
    }
    /// <summary>
    /// ارسال به صورت معمولی
    /// </summary>
    /// <param name="APILink"></param>
    /// <param name="APIKey"></param>
    /// <param name="from"></param>
    /// <param name="to"></param>
    /// <param name="Message"></param>
    /// <param name="DateTimeSender"></param>
    /// <returns></returns>
    public static async Task<(HttpWebResponse Response, string ResponseContent)> SendNormalSingleAsync(string APILink, string APIKey, string from, string[] to, string Message, DateTime DateTimeSender)
    {
        // ایجاد JSON payload
        string jsonPayload = JsonConvert.SerializeObject(new
        {
            sender = from,
            recipient = to,
            time = DateTimeSender,
            message = Message,
        });

        try
        {
            // ساخت درخواست HTTP POST
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(APILink ?? "https://api2.ippanel.com/api/v1/sms/send/webservice/single");
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Headers["apikey"] = APIKey;

            // ارسال JSON payload به صورت ناهمزمان
            using (var writer = new StreamWriter(await request.GetRequestStreamAsync()))
            {
                await writer.WriteAsync(jsonPayload);
                await writer.FlushAsync(); // اطمینان حاصل کنید که داده قبل از بستن جریان فرستاده شود
            }

            // دریافت پاسخ به صورت ناهمزمان
            HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync();
            using (var stream = response.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                string responseContent = await reader.ReadToEndAsync();
                return (response, responseContent);
            }
        }
        catch (WebException ex)
        {
            Console.WriteLine("Error sending SMS: " + ex.Message);
            return (null, ex.Message); // بازگرداندن پاسخ و متن خطا
        }
    }
    /// <summary>
    /// این کد یک تابع C# به نام SendPeerToPeerAsync است که به صورت همزمان برای ارسال پیامک‌های چند گیرنده به یک API با روش POST عمل می‌کند.
    /// </summary>
    /// <param name="APILink"></param>
    /// <param name="APIKey"></param>
    /// <param name="Recipients"></param>
    /// <param name="FromNumber"></param>
    /// <param name="Messages"></param>
    /// <returns></returns>
    public static async Task<(string ResponseContent, int StatusCode)> SendPeerToPeerAsync(string APILink, string APIKey, List<List<string>> Recipients, string FromNumber, string[] Messages)
    {
        try
        {
            // ایجاد JSON payload
            var jsonPayload = new Dictionary<string, object>()
            {
                ["recipient"] = Recipients,
                ["sending_type"] = "webservice",
                ["sender"] = FromNumber,
                ["message"] = Messages,
            };

            string jsonString = JsonConvert.SerializeObject(jsonPayload);

            // ایجاد درخواست HTTP POST
            var request = (HttpWebRequest)WebRequest.Create(APILink ?? "https://api2.ippanel.com/api/v1/sms/send/webservice/peer-to-peer");
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Headers["Accept"] = "application/json"; // سربرگ پذیرش را اضافه کنید (اختیاری)
            request.Headers["apikey"] = APIKey;

            // ارسال JSON payload به صورت ناهمزمان
            using (var streamWriter = new StreamWriter(await request.GetRequestStreamAsync()))
            {
                await streamWriter.WriteAsync(jsonString);
                await streamWriter.FlushAsync();
            }

            // دریافت پاسخ
            using (var response = (HttpWebResponse)await request.GetResponseAsync())
            {
                // بررسی کد وضعیت
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    // خواندن محتوای پاسخ
                    using (var stream = response.GetResponseStream())
                    using (var reader = new StreamReader(stream))
                    {
                        string responseContent = await reader.ReadToEndAsync();
                        return (responseContent, (int)response.StatusCode);
                    }
                }
                else
                {
                    throw new WebException($"Error sending SMS: {response.StatusCode}");
                }
            }
        }
        catch (WebException ex)
        {
            Console.WriteLine("Error sending SMS: " + ex.Message);
            return ("", -1); // Return empty content and error status code
        }
    }


    public static async Task<string> SendPeerToPeerByFileAsync(string APILink, string APIKey, string FromNumber, IFormFile File)
    {
        try
        {
            if (File == null || File.Length == 0)
            {
                throw new ArgumentException("File parameter cannot be null or empty.");
            }

            using (var client = new HttpClient())
            {
                // Create the HttpContent for the form to be posted.
                var requestContent = new MultipartFormDataContent();
                requestContent.Add(new StringContent(FromNumber), "sender");
                requestContent.Add(new StreamContent(File.OpenReadStream()), "file", File.FileName);
                requestContent.Add(new StringContent("ارسال به فایل"), "description[summary]");
                requestContent.Add(new StringContent("1"), "description[count_recipient]");

                // Set additional headers.
                
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("apikey", APIKey);

                // Send the POST request.
                HttpResponseMessage response = await client.PostAsync(APILink ?? "https://api2.ippanel.com/api/v1/sms/send/panel/peer-to-peer-by-file", requestContent);

                // Get the response content.
                HttpContent responseContent = response.Content;

                // Read the response.
                string result = await responseContent.ReadAsStringAsync();
                return result;
            }
        }
        catch (WebException ex)
        {
            Console.WriteLine("Error sending SMS: " + ex.Message);
            return (ex.Message); // Return empty content and error status code}
        }
    }
    /// <summary>
    /// نمایش هزینه پانل
    /// </summary>
    /// <param name="APILink"></param>
    /// <param name="APIKey"></param>
    /// <returns></returns>
    public static async Task<(string ResponseContent, int StatusCode)> GetCreditAsync(string APILink, string APIKey)
    {
        try
        {
            // ایجاد درخواست HTTP GET
            var request = (HttpWebRequest)WebRequest.Create(APILink ?? $"https://api2.ippanel.com/api/v1/sms/accounting/credit/show");
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Headers["Accept"] = "application/json"; // سربرگ پذیرش را اضافه کنید (اختیاری)
            request.Headers["apikey"] = APIKey;

            // دریافت پاسخ
            using (var response = (HttpWebResponse)await request.GetResponseAsync())
            {
                // بررسی کد وضعیت
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    // خواندن محتوای پاسخ
                    using (var stream = response.GetResponseStream())
                    using (var reader = new StreamReader(stream))
                    {
                        string responseContent = await reader.ReadToEndAsync();
                        return (responseContent, (int)response.StatusCode);
                    }
                }
                else
                {
                    throw new WebException($"Error getting credit: {response.StatusCode}");
                }
            }
        }
        catch (WebException ex)
        {
            Console.WriteLine("Error getting credit: " + ex.Message);
            return ("", -1); // Return empty content and error status code
        }
    }
    /// <summary>
    /// نمایش پیام های ارسال شده   
    /// /// </summary>
    /// <param name="APILink"></param>
    /// <param name="APIKey"></param>
    /// <param name="page"></param>
    /// <param name="per_page"></param>
    /// <returns></returns>
    public static async Task<(string ResponseContent, int StatusCode)> GetSendListAsync(string APILink, string APIKey, int page, int per_page)
    {
        try
        {
            // ایجاد درخواست HTTP GET
            var request = (HttpWebRequest)WebRequest.Create(APILink ?? $"https://api2.ippanel.com/api/v1/sms/message/all?page={page}&per_page={per_page}");
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Headers["Accept"] = "application/json"; // سربرگ پذیرش را اضافه کنید (اختیاری)
            request.Headers["apikey"] = APIKey;

            // دریافت پاسخ
            using (var response = (HttpWebResponse)await request.GetResponseAsync())
            {
                // بررسی کد وضعیت
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    // خواندن محتوای پاسخ
                    using (var stream = response.GetResponseStream())
                    using (var reader = new StreamReader(stream))
                    {
                        string responseContent = await reader.ReadToEndAsync();
                        return (responseContent, (int)response.StatusCode);
                    }
                }
                else
                {
                    throw new WebException($"Error getting credit: {response.StatusCode}");
                }
            }
        }
        catch (WebException ex)
        {
            Console.WriteLine("Error getting credit: " + ex.Message);
            return ("", -1); // Return empty content and error status code
        }
    }


}
/*
How Use Source
https://github.com/SayyehBan/SendSMSSayyehBan/blob/master/SendSMSSayyehBan/Controllers/SMS_SayyehBanController.cs
 */
