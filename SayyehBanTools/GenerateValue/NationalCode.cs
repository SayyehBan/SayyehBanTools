using System.Text.RegularExpressions;

/// <summary>
/// کلاس تولید و بررسی کد ملی
/// </summary>
public class NationalCode
{
    /// <summary>
    /// تولید کد ملی
    /// </summary>
    /// <returns></returns>
    public static string Generate()
    {
        string ss = "";
        string number123 = "0123456789";
        Random rnd = new Random();
        object code1 = rnd.Next(1, 9);
        object code2 = rnd.Next(1, 9);
        object code3 = rnd.Next(1, 9);
        object code4 = rnd.Next(1, 9);
        object code5 = rnd.Next(1, 9);
        object code6 = rnd.Next(1, 9);
        object code7 = rnd.Next(1, 9);
        object code8 = rnd.Next(1, 9);
        object code9 = rnd.Next(1, 9);
        string numbers1 = number123.Substring(Convert.ToInt32(code1), 1);
        string numbers2 = number123.Substring(Convert.ToInt32(code2), 1);
        string numbers3 = number123.Substring(Convert.ToInt32(code3), 1);
        string numbers4 = number123.Substring(Convert.ToInt32(code4), 1);
        string numbers5 = number123.Substring(Convert.ToInt32(code5), 1);
        string numbers6 = number123.Substring(Convert.ToInt32(code6), 1);
        string numbers7 = number123.Substring(Convert.ToInt32(code7), 1);
        string numbers8 = number123.Substring(Convert.ToInt32(code8), 1);
        string numbers9 = number123.Substring(Convert.ToInt32(code9), 1);
        string sumnumber = numbers1 + numbers2 + numbers3 + numbers4 + numbers5 + numbers6 + numbers7 + numbers8 + numbers9;
        var code = sumnumber.ToArray();
        if (code.Length == 9)
        {
            int numberPosition = 10;
            int sum = 0;
            while (numberPosition >= 2)
            {
                for (int i = 0; i <= 8; i++)
                {
                    int number = Convert.ToInt32(code[i].ToString()) * numberPosition;
                    sum = sum + number;
                    numberPosition--;
                }
            }

            int numberControl = (11 - (sum % 11));
            ss = sumnumber + Convert.ToString(numberControl);
            if (ss.Length == 10)
            {

            }
        }
        return ss;
    }
    /// <summary>
    /// نحوه استفاده برای تولید کد
    ///textBox3.Text = Generate();
    /// </summary>
    /// <param name="nationalCode"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public static Boolean IsValidNationalCode(String nationalCode)
    {
        //در صورتی که کد ملی وارد شده تهی باشد

        if (String.IsNullOrEmpty(nationalCode))
            throw new Exception("لطفا کد ملی را صحیح وارد نمایید");


        //در صورتی که کد ملی وارد شده طولش کمتر از 10 رقم باشد
        if (nationalCode.Length != 10)
            throw new Exception("طول کد ملی باید ده کاراکتر باشد");

        //در صورتی که کد ملی ده رقم عددی نباشد
        var regex = new Regex(@"\d{10}");
        if (!regex.IsMatch(nationalCode))
            throw new Exception("کد ملی تشکیل شده از ده رقم عددی می‌باشد؛ لطفا کد ملی را صحیح وارد نمایید");

        //در صورتی که رقم‌های کد ملی وارد شده یکسان باشد
        var allDigitEqual = new[] { "0000000000", "1111111111", "2222222222", "3333333333", "4444444444", "5555555555", "6666666666", "7777777777", "8888888888", "9999999999" };
        if (allDigitEqual.Contains(nationalCode)) return false;


        //عملیات شرح داده شده در بالا
        var chArray = nationalCode.ToCharArray();
        var num0 = Convert.ToInt32(chArray[0].ToString()) * 10;
        var num2 = Convert.ToInt32(chArray[1].ToString()) * 9;
        var num3 = Convert.ToInt32(chArray[2].ToString()) * 8;
        var num4 = Convert.ToInt32(chArray[3].ToString()) * 7;
        var num5 = Convert.ToInt32(chArray[4].ToString()) * 6;
        var num6 = Convert.ToInt32(chArray[5].ToString()) * 5;
        var num7 = Convert.ToInt32(chArray[6].ToString()) * 4;
        var num8 = Convert.ToInt32(chArray[7].ToString()) * 3;
        var num9 = Convert.ToInt32(chArray[8].ToString()) * 2;
        var a = Convert.ToInt32(chArray[9].ToString());

        var b = (((((((num0 + num2) + num3) + num4) + num5) + num6) + num7) + num8) + num9;
        var c = b % 11;

        return (((c < 2) && (a == c)) || ((c >= 2) && ((11 - c) == a)));
    }
    //نحوه بررسی صحت درست بودن و اشتباه بودن
    // if (!IsValidNationalCode(textBox4.Text))
    //{
    //    MessageBox.Show("کد ملی شما صحیح نیست");
    //}
    //if (IsValidNationalCode(textBox4.Text))
    //{
    //    MessageBox.Show("کد ملی شما صحیح است");
    //}
}
