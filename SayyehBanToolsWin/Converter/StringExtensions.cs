using System;
using System.Text.RegularExpressions;


namespace SayyehBanToolsWin.Converter
{ 
public static class StringExtensions
{/// <summary>
 /// بررسی اینکه آیا مقدار وجود داره یا خیر
 /// </summary>
 /// <param name="value"></param>
 /// <param name="ignoreWhiteSpace"></param>
 /// <returns></returns>
    public static bool HasValue(this string value, bool ignoreWhiteSpace = true)
    {
        return ignoreWhiteSpace ? !string.IsNullOrWhiteSpace(value) : !string.IsNullOrEmpty(value);
    }
    /// <summary>
    /// تبدیل به Int
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static int ToInt(this string value)
    {
        return Convert.ToInt32(value);
    }
    /// <summary>
    /// تبدیل به Decimal
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static decimal ToDecimal(this string value)
    {
        return Convert.ToDecimal(value);
    }
    /// <summary>
    /// دریافت مقدار
    /// int
    /// و نمایش آن به صورت سه رغم اعشار
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string ToNumeric(this int value)
    {
        return value.ToString("N0"); //"123,456"
    }
    /// <summary>
    /// دریافت مقدار
    /// decimal
    /// و نمایش آن به صورت سه رشته اعشار
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string ToNumeric(this decimal value)
    {
        return value.ToString("N0");
    }
    /// <summary>
    /// دریافت مقدار
    /// int
    /// و نمایش آن به صورت
    /// Currency
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string ToCurrency(this int value)
    {
        //fa-IR => current culture currency symbol => ریال
        //123456 => "123,123ریال"
        return value.ToString("C0");
    }
    /// <summary>
    /// دریافت مقدار 
    /// decimal
    /// و نمایش آن به صورت
    /// Currency
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string ToCurrency(this decimal value)
    {
        return value.ToString("C0");
    }
    /// <summary>
    /// جایگزین عدد پارسی به جای انگلیسی
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string En2Fa(this string str)
    {
        if (str == null)
        {
            str = "۰";
        }
        return str.Replace("0", "۰")
            .Replace("1", "۱")
            .Replace("2", "۲")
            .Replace("3", "۳")
            .Replace("4", "۴")
            .Replace("5", "۵")
            .Replace("6", "۶")
            .Replace("7", "۷")
            .Replace("8", "۸")
            .Replace("9", "۹");
    }
    /// <summary>
    /// جایگزین عدد انگلیسی به جای پارسی
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string Fa2En(this string str)
    {
        if (str == null)
        {
            str = "0";
        }
        return str.Replace("۰", "0")
            .Replace("۱", "1")
            .Replace("۲", "2")
            .Replace("۳", "3")
            .Replace("۴", "4")
            .Replace("۵", "5")
            .Replace("۶", "6")
            .Replace("۷", "7")
            .Replace("۸", "8")
            .Replace("۹", "9")
            //iphone numeric
            .Replace("٠", "0")
            .Replace("١", "1")
            .Replace("٢", "2")
            .Replace("٣", "3")
            .Replace("٤", "4")
            .Replace("٥", "5")
            .Replace("٦", "6")
            .Replace("٧", "7")
            .Replace("٨", "8")
            .Replace("٩", "9");
    }
    /// <summary>
    /// جایگزین حروف پارسی به جای حروف عربی و غیر ایرانی
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string FixPersianChars(this string str)
    {
        if (str == null)
        {
            str = " ";
        }
        if (str == "string")
        {
            str = " ";
        }
        return str.Replace("ﮎ", "ک")
            .Replace("ﮏ", "ک")
            .Replace("ﮐ", "ک")
            .Replace("ﮑ", "ک")
            .Replace("ك", "ک")
            .Replace("ي", "ی")
            .Replace(" ", " ")
            .Replace("‌", " ")
            .Replace("ھ", "ه");//.Replace("ئ", "ی");
    }
    /// <summary>
    /// حذف نقطه یا علامت اعشار از اعداد
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string RemovePoint(this string str)
    {
        return str.Replace(",", "")
            .Replace(".", "")
            .Replace("/", "")
            .Replace(".", "");
    }
    public static string Msg(this string str)
    {
        return str.Replace("Core .Net SqlClient Data Provider-", "").CleanString();
    }
    /// <summary>
    /// انجام چندین عملیات پاکسازی با هم
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string CleanString(this string str)
    {
        return str.FixPersianChars().Fa2En().Trim();
    }
    /// <summary>
    /// جلو مقدار خالی رو گرفتن و به جای مقدار خالی
    /// Null
    /// ارسال کردن.
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string NullIfEmpty(this string str)
    {
        return str?.Length == 0 ? null : str;
    }
    //حذف تگ های html  از توضیحات
    public static string HtmlTags(this string source)
    {
        //string pattern = @"<.*?>";
        string pattern = @"<[^>]*(>|$)|&zwnj;|&raquo;|&laquo;";
        return Regex.Replace(source.Replace("&nbsp;", " ").Trim(), pattern, string.Empty);
    }
    //حذف مقدار عملکر گردها
    public static string ASCII(this string source)
    {

        string pattern = @"\r\n";
        return Regex.Replace(source.Trim(), pattern, " ");
    }
}
}