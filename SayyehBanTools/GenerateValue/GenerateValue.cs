using System.Security.Cryptography;

namespace SayyehBanTools.GenerateValue;

public class GenerateValue
{
    /// <summary>
    /// تولید عدد تصادفی 8 رقمی
    /// </summary>
    /// <returns></returns>
    public static string Generate_Unique_Number()
    {
        var bytes = new byte[4];
        var rng = RandomNumberGenerator.Create();
        rng.GetBytes(bytes);
        uint random = BitConverter.ToUInt32(bytes, 0) % 100000000;
        return String.Format("{0:D8}", random);
    }
}
