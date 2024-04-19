using Newtonsoft.Json;
using System.Net;

namespace SayyehBanTools.Sender;

public class SendSmsPattern
{
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

}
/*
 Dictionary<string, object> dicDataSMS = new Dictionary<string, object>
            {
                ["DisposablePassword"] = DisposablePassword,
                ["Cemetery"] = Cemetery,
            };
            //string message = "رمز یکبار مصرف : " + DisposablePassword + " \n آرامستان " + Cemetery;
            if (IsActive == true)
            {
                var (response, responseContent) = await SendSmsPattern.SendPatternAsync(null, API, dicDataSMS, "86hpqw3d9mvkvw4", Number, Mobile);

                if (response != null)
                {
                    Console.WriteLine("SMS response status code: " + response.StatusCode);
                    Console.WriteLine("SMS response content: " + JsonConvert.DeserializeObject(responseContent));
                }
                else
                {
                    Console.WriteLine("Error sending SMS: " + JsonConvert.DeserializeObject(responseContent)); // Handle error message
                }
 */