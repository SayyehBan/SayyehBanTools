using SayyehBanTools.Converter;
using SayyehBanTools.Encryptor;
using System.Net;
using System.Text;

namespace SayyehBanTools.Sender
{
    public class SendSmsNormal
    {
        public async Task sendSms(string Mobile, string Message, string Username, string Password, string Number)
        {
            try
            {
                Uri address = new Uri("http://ippanel.com/services.jspd");
                HttpWebRequest request = WebRequest.Create(address) as HttpWebRequest;
                // Set type to POST
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";

                // Create the data we want to send
                StringBuilder data = new StringBuilder();
                data.Append("op=send&uname=" + StringExtensions.CleanString(Username));
                data.Append("&pass=" + StringExtensions.CleanString(Password));
                data.Append("&from=" + StringExtensions.CleanString(Number));
                data.Append(" &to=+98" + StringExtensions.CleanString(Mobile));
                data.Append("&message=" + StringExtensions.CleanString(Message));
                // Create a byte array of the data we want to send
                byte[] byteData = UTF8Encoding.UTF8.GetBytes(data.ToString());
                // Set the content length in the request headers
                request.ContentLength = byteData.Length;
                // Write data
                using (Stream postStream = request.GetRequestStream())
                {
                    await postStream.WriteAsync(byteData, 0, byteData.Length);
                }
                // Get response
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    //LblResult.Text = reader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {

            }
        }
        public async Task sendSms(string Mobile, string Message, string Username, string Password, string Number, string initVector, string passPhrase)
        {
            try
            {
                Uri address = new Uri("http://ippanel.com/services.jspd");
                HttpWebRequest request = WebRequest.Create(address) as HttpWebRequest;
                // Set type to POST
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";

                // Create the data we want to send
                StringBuilder data = new StringBuilder();

                string username = StringEncryptor.Decrypt(Username, initVector, passPhrase);
                data.Append("op=send&uname=" + StringExtensions.CleanString(username));

                string password = StringEncryptor.Decrypt(Password, initVector, passPhrase);
                data.Append("&pass=" + StringExtensions.CleanString(password));
                data.Append("&from=" + StringExtensions.CleanString(Number));
                data.Append(" &to=+98" + StringExtensions.CleanString(Mobile));
                data.Append("&message=" + StringExtensions.CleanString(Message));
                // Create a byte array of the data we want to send
                byte[] byteData = UTF8Encoding.UTF8.GetBytes(data.ToString());
                // Set the content length in the request headers
                request.ContentLength = byteData.Length;
                // Write data
                using (Stream postStream = request.GetRequestStream())
                {
                    await postStream.WriteAsync(byteData, 0, byteData.Length);
                }
                // Get response
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    //LblResult.Text = reader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {

            }
        }
        public string getCredit(string Username, string Password)
        {
            string dt;
            WebRequest request = WebRequest.Create("http://ippanel.com/services.jspd");
            request.Method = "POST";
            StringBuilder data = new StringBuilder();
            data.Append("op=credit&uname=" + StringExtensions.CleanString(Username));
            data.Append("&pass=" + StringExtensions.CleanString(Password));
            byte[] byteArray = Encoding.UTF8.GetBytes(data.ToString());
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            WebResponse response = request.GetResponse();
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            string a;
            a = responseFromServer.Replace("[", "").Replace("]", "").Replace("\"", "").Replace(".", "").Replace(",", "").Substring(1, 5);
            decimal aa = Convert.ToDecimal(a);
            dt = "مبلغ اعتبار شما : " + aa.ToString("n0") + " ریال میباشد";
            reader.Close();
            dataStream.Close();
            response.Close();
            System.Diagnostics.Debug.WriteLine(responseFromServer);
            return dt;
        }

        public string getCredit(string Username, string Password, string initVector, string passPhrase)
        {
            string dt;
            WebRequest request = WebRequest.Create("http://ippanel.com/services.jspd");
            request.Method = "POST";
            StringBuilder data = new StringBuilder();

            string username = StringEncryptor.Decrypt(Username, initVector, passPhrase);
            data.Append("op=credit&uname=" + StringExtensions.CleanString(username));

            string password = StringEncryptor.Decrypt(Password, initVector, passPhrase);
            data.Append("&pass=" + StringExtensions.CleanString(password));
            byte[] byteArray = Encoding.UTF8.GetBytes(data.ToString());
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            WebResponse response = request.GetResponse();
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            string a;
            a = responseFromServer.Replace("[", "").Replace("]", "").Replace("\"", "").Replace(".", "").Replace(",", "").Substring(1, 5);
            decimal aa = Convert.ToDecimal(a);
            dt = "مبلغ اعتبار شما : " + aa.ToString("n0") + " ریال میباشد";
            reader.Close();
            dataStream.Close();
            response.Close();
            System.Diagnostics.Debug.WriteLine(responseFromServer);
            return dt;
        }
    }
}
