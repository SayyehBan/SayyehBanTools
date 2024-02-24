using System.Collections.Generic;
using System.Net;
using System.Text;

namespace SayyehBanToolsWin.Sender
{
    public class SendSmsPattern
    {
        public bool sendSmsPattern(string APIKey, Dictionary<string, object> data, string patternCode, string SendSMSNumber, string to)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                foreach (KeyValuePair<string, object> item in data)
                {
                    sb.Append(item.Key.Trim() + "" + item.Value.ToString());
                }

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"http://ippanel.com:8080/?apikey={APIKey}&pid={patternCode.Trim()}&fnum={SendSMSNumber}&tnum={to.Trim()}{sb}");
                var result = request.GetResponse();
                WebResponse response = result;
                response.Close();
            }
            catch { }

            return true;
        }
    }
}
