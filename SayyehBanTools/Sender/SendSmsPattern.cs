using Newtonsoft.Json;
using System.Net;

namespace SayyehBanTools.Sender;

public class SendSmsPattern
{
    public static async Task<HttpWebResponse> SendPatternAsync(string APILink, string APIKey, Dictionary<string, object> data, string patternCode, string from, string to)
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
            return await request.GetResponseAsync() as HttpWebResponse;
        }
        catch (WebException ex)
        {
            Console.WriteLine("Error sending SMS: " + ex.Message);
            throw; // Re-throw the exception for handling in the calling code
        }
    }
}
/*
 ## نحوه استفاده از تابع `SendPatternAsync` برای ارسال پیامک الگو (با توضیحات فارسی)

این کد یک کلاس به نام `SendSmsPattern` را تعریف می کند که شامل یک تابع به نام `SendPatternAsync` است. این تابع به صورت **ناهمزمان (async)** کار می کند و برای ارسال پیامک الگو با استفاده از یک API خارجی طراحی شده است.

### لیست پارامترهای تابع:

* **`APILink` (اختیاری):** لینک API مورد نظر برای ارسال پیامک. اگر این مقدار خالی باشد، به صورت پیش فرض آدرس "[https://api2.ippanel.com/api/v1/sms/pattern/normal/send](https://api2.ippanel.com/api/v1/sms/pattern/normal/send)" استفاده می شود.
* **`APIKey` (اجباری):** کلید API برای دسترسی به سرویس ارسال پیامک.
* **`data` (اجباری):** یک دیکشنری (فرهنگ لغت) از داده ها که قرار است در الگوی پیامک استفاده شود. کلیدهای دیکشنری اسامی متغیرهای الگو هستند و مقادیر آنها داده هایی هستند که جایگزین متغیرها می شوند.
* **`patternCode` (اجباری):** کد الگوی پیامکی که می خواهید برای ارسال استفاده کنید.
* **`from` (اجباری):** شماره فرستنده پیامک.
* **`to` (اجباری):** شماره گیرنده پیامک.

### نحوه استفاده:

1. **مقادیر پارامترها را مشخص کنید:**
   - کلید API خود را بدست آورید.
   - کد الگوی پیامکی مورد نظر را مشخص کنید.
   - شماره فرستنده و گیرنده پیامک را وارد کنید.
   - در صورت نیاز، لینک API دلخواه خود را تنظیم کنید (در غیر این صورت پیش فرض استفاده می شود).
   - یک دیکشنری حاوی داده های الگو با کلید و مقدار مناسب ایجاد کنید.

2. **تابع را به صورت ناهمزمان فراخوانی کنید:**
   از آنجایی که تابع `SendPatternAsync` ناهمزمان است، باید آن را با کلمه کلیدی `async` در متد فراخوانی کننده استفاده کنید. همچنین، نتیجه آن یک شیء از نوع `Task<HttpWebResponse>` است که به صورت ناهمزمان در دسترس خواهد بود.

3. **نتیجه را مدیریت کنید:**
   برای دسترسی به نتیجه ارسال پیامک، از روش `await` روی شیء `Task` برگشتی استفاده کنید. شیء `HttpWebResponse` حاوی اطلاعات مربوط به پاسخ سرور ارسال پیامک است.

4. **بررسی پاسخ:**
   با استفاده از خواص شیء `HttpWebResponse` (مانند `StatusCode`) می توانید نتیجه ارسال پیامک را بررسی کنید. کد وضعیت 200 نشان دهنده موفقیت ارسال است، در غیر این صورت با بررسی کد و محتوای پاسخ (با استفاده از `GetResponseStream`) می توانید خطا را تشخیص دهید.

   **مثال:**

```C#
string apiKey = "YOUR_API_KEY";
string patternCode = "YOUR_PATTERN_CODE";
string fromNumber = "YOUR_SENDER_NUMBER";
string toNumber = "RECIPIENT_NUMBER";

Dictionary<string, object> data = new Dictionary<string, object>()
{
    { "name", "John Doe" },
    { "code", "123456" }
};

// Call the function asynchronously
async Task SendSmsAsync()
{
    try
    {
        HttpWebResponse response = await SendSmsPattern.SendPatternAsync(null, apiKey, data, patternCode, fromNumber, toNumber);

        if (response.StatusCode == HttpStatusCode.OK)
        {
            Console.WriteLine("SMS sent successfully!");
        }
        else
        {
            Console.WriteLine("Error sending SMS: Status code {0}", response.StatusCode);
            // Handle error based on response content (if needed)
        }
    }
    catch (WebException ex)
    {
        Console.WriteLine("Error sending SMS: " + ex.Message);
    }
}

// Start the asynchronous operation
SendSmsAsync();

// Your program can continue executing other tasks while waiting for the SMS to be sent
```

**نکات مهم:**

* مطمئن شوید که کتابخانه `Newtonsoft.Json` را به پروژه خود اضافه کرده اید تا از `JsonConvert.SerializeObject` استفاده کنید.
* برای مدیریت خطاهای احتمالی، از بلوک `try-catch` استفاده کنید.
* بسته به نیاز خود، ممکن است بخواهید محتوای پاسخ سرور را با استفاده از `GetResponseStream` بخوانید.

 */