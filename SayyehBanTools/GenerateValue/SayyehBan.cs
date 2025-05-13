using System.Text.RegularExpressions;

/// <summary>
/// کلاس بررسی و تولید کد سایه بان
/// </summary>
public class SayyehBan
{
    /// <summary>
    /// بررسی کد سایه بان
    /// </summary>
    /// <param name="nationalCode"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public static Boolean IsValidCode(String nationalCode)
    {
        //در صورتی که کد ملی وارد شده تهی باشد

        if (String.IsNullOrEmpty(nationalCode))
            throw new Exception("لطفا کد سایه بان را صحیح وارد نمایید");


        //در صورتی که کد ملی وارد شده طولش کمتر از 10 رقم باشد
        if (nationalCode.Length != 13)
            throw new Exception("طول کد سایه بان باید سیزده کاراکتر باشد");

        //در صورتی که کد ملی ده رقم عددی نباشد
        var regex = new Regex(@"\d{13}");
        if (!regex.IsMatch(nationalCode))
            throw new Exception("کد سایه بان تشکیل شده از سیزده رقم عددی می‌باشد؛ لطفا کد سایه بان را صحیح وارد نمایید");

        //در صورتی که رقم‌های کد ملی وارد شده یکسان باشد
        var allDigitEqual = new[] { "0000000000000",
                                        "1111111111111",
                                        "2222222222222",
                                        "3333333333333",
                                        "4444444444444",
                                        "5555555555555",
                                        "6666666666666",
                                        "7777777777777",
                                        "8888888888888",
                                        "9999999999999" };
        if (allDigitEqual.Contains(nationalCode)) return false;


        //عملیات شرح داده شده در بالا
        var chArray = nationalCode.ToCharArray();
        var num0 = Convert.ToInt32(chArray[0].ToString()) * 13;
        var num2 = Convert.ToInt32(chArray[1].ToString()) * 12;
        var num3 = Convert.ToInt32(chArray[2].ToString()) * 11;
        var num4 = Convert.ToInt32(chArray[3].ToString()) * 10;
        var num5 = Convert.ToInt32(chArray[4].ToString()) * 9;
        var num6 = Convert.ToInt32(chArray[5].ToString()) * 8;
        var num7 = Convert.ToInt32(chArray[6].ToString()) * 7;
        var num8 = Convert.ToInt32(chArray[7].ToString()) * 6;
        var num9 = Convert.ToInt32(chArray[8].ToString()) * 5;
        var num10 = Convert.ToInt32(chArray[9].ToString()) * 4;
        var num11 = Convert.ToInt32(chArray[10].ToString()) * 3;
        var num12 = Convert.ToInt32(chArray[11].ToString()) * 2;
        var a = Convert.ToInt32(chArray[12].ToString());

        var b = ((((((((((num0 + num2) + num3) + num4) + num5) + num6) + num7) + num8) + num9) + num10) + num11) + num12;
        var c = b % 14;

        return (((c < 2) && (a == c)) || ((c >= 2) && ((14 - c) == a)));
    }
    ///نحوه بررسی کد سایه بان
    ///   if (!IsValidCode(textBox2.Text))
    //{
    //    MessageBox.Show("کد شما صحیح نیست");
    //}
    //if (IsValidCode(textBox2.Text))
    //{
    //    MessageBox.Show("کد شما صحیح است");
    //}
    public static string GenerateCode()
    {
        string ss = "";
        string number123 = "01234567890123";
        Random rnd = new Random();
        object code1 = rnd.Next(1, 12);
        object code2 = rnd.Next(1, 12);
        object code3 = rnd.Next(1, 12);
        object code4 = rnd.Next(1, 12);
        object code5 = rnd.Next(1, 12);
        object code6 = rnd.Next(1, 12);
        object code7 = rnd.Next(1, 12);
        object code8 = rnd.Next(1, 12);
        object code9 = rnd.Next(1, 12);
        object code10 = rnd.Next(1, 12);
        object code11 = rnd.Next(1, 12);
        object code12 = rnd.Next(1, 12);
        string numbers1 = number123.Substring(Convert.ToInt32(code1), 1);
        string numbers2 = number123.Substring(Convert.ToInt32(code2), 1);
        string numbers3 = number123.Substring(Convert.ToInt32(code3), 1);
        string numbers4 = number123.Substring(Convert.ToInt32(code4), 1);
        string numbers5 = number123.Substring(Convert.ToInt32(code5), 1);
        string numbers6 = number123.Substring(Convert.ToInt32(code6), 1);
        string numbers7 = number123.Substring(Convert.ToInt32(code7), 1);
        string numbers8 = number123.Substring(Convert.ToInt32(code8), 1);
        string numbers9 = number123.Substring(Convert.ToInt32(code9), 1);
        string numbers10 = number123.Substring(Convert.ToInt32(code10), 1);
        string numbers11 = number123.Substring(Convert.ToInt32(code11), 1);
        string numbers12 = number123.Substring(Convert.ToInt32(code12), 1);
        string sumnumber = numbers1 + numbers2 + numbers3 + numbers4 + numbers5 + numbers6 + numbers7 + numbers8 + numbers9 + numbers10 + numbers11 + numbers12;
        var code = sumnumber.ToArray();
        if (code.Length == 12)
        {
            int numberPosition = 13;
            int sum = 0;
            while (numberPosition >= 2)
            {
                for (int i = 0; i <= 11; i++)
                {
                    int number = Convert.ToInt32(code[i].ToString()) * numberPosition;
                    sum = sum + number;
                    numberPosition--;
                }
            }
            int numberControl = (14 - (sum % 14));
            ss = sumnumber + Convert.ToString(numberControl);
            if (ss.Length == 13)
            {
            }
        }

        return ss;
    }
    //نحوه استفاده از کد تولید
    // textBox1.Text = GenerateCode();
}
