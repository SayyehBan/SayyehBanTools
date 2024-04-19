using System.Security.Cryptography;
using System.Text;

namespace SayyehBanTools.Encryptor;

public static class StringEncryptor
{
    private static readonly int keysize = 256;

    public static string Encrypt(string plainText, string initVector, string passPhrase)
    {
        byte[] bytes1 = Encoding.UTF8.GetBytes(initVector);
        byte[] bytes2 = Encoding.UTF8.GetBytes(plainText);
        byte[] bytes3 = new PasswordDeriveBytes(passPhrase, null).GetBytes(keysize / 8);
        RijndaelManaged rijndaelManaged = new RijndaelManaged
        {
            Mode = CipherMode.CBC,
            Padding = PaddingMode.PKCS7 // Specify padding mode
        };
        ICryptoTransform encryptor = rijndaelManaged.CreateEncryptor(bytes3, bytes1);
        MemoryStream memoryStream = new MemoryStream();
        CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
        cryptoStream.Write(bytes2, 0, bytes2.Length);
        cryptoStream.FlushFinalBlock();
        byte[] array = memoryStream.ToArray();
        memoryStream.Close();
        cryptoStream.Close();
        return Convert.ToBase64String(array);
    }

    public static string Decrypt(string cipherText, string initVector, string passPhrase)
    {
        byte[] bytes1 = Encoding.ASCII.GetBytes(initVector);
        byte[] buffer = Convert.FromBase64String(cipherText);
        byte[] bytes2 = new PasswordDeriveBytes(passPhrase, null).GetBytes(keysize / 8);
        RijndaelManaged rijndaelManaged = new RijndaelManaged
        {
            Mode = CipherMode.CBC,
            Padding = PaddingMode.PKCS7 // Specify padding mode
        };
        ICryptoTransform decryptor = rijndaelManaged.CreateDecryptor(bytes2, bytes1);
        MemoryStream memoryStream = new MemoryStream(buffer);
        CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
        byte[] numArray = new byte[buffer.Length];
        int count = cryptoStream.Read(numArray, 0, numArray.Length);
        memoryStream.Close();
        cryptoStream.Close();
        return Encoding.UTF8.GetString(numArray, 0, count);
    }

    public static string DecryptConnectionString(string plainText, string initVector, string passPhrase)
    {
        int num1 = plainText.IndexOf("||");
        if (num1 == -1)
        {
            return Decrypt(plainText, initVector, passPhrase);
        }

        int num2 = num1 + 1;
        string str = plainText.Substring(0, num2 - 1);
        string cipherText = plainText.Substring(num2 + 1, plainText.Length - (num2 + 1));
        try
        {
            return str + Decrypt(cipherText, initVector, passPhrase);
        }
        catch (Exception)
        {
            return string.Empty;
        }
    }
}

/*
 طریقه استفاده از دستور
string encryptedText = StringEncryptDecryptLength16.Encrypt(plainText, initVector, passPhrase);
string decryptedText = StringEncryptDecryptLength16.Decrypt(encryptedText, initVector, passPhrase);

 */
