using System.Security.Cryptography;
using System.Text;

namespace SayyehBanTools.Encryptor;

public static class StringEncryptor
{
    private static readonly int keysize = 256;

    public static string Encrypt(string plainText, string initVector, string passPhrase)
    {
        byte[] bytes1 = Encoding.UTF8.GetBytes(initVector.Substring(0, 16));
        byte[] bytes2 = Encoding.UTF8.GetBytes(plainText);
        byte[] bytes3 = new PasswordDeriveBytes(passPhrase.Substring(0, 16), null).GetBytes(keysize / 8);
        RijndaelManaged rijndaelManaged = new RijndaelManaged
        {
            Mode = CipherMode.CBC,
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

    //public static string Decrypt(string cipherText, string initVector, string passPhrase)
    //{
    //    byte[] bytes1 = Encoding.UTF8.GetBytes(initVector.Substring(0, 16));
    //    byte[] buffer = Convert.FromBase64String(cipherText);
    //    byte[] bytes2 = new PasswordDeriveBytes(passPhrase.Substring(0, 16), null).GetBytes(keysize / 8);
    //    RijndaelManaged rijndaelManaged = new RijndaelManaged
    //    {
    //        Mode = CipherMode.CBC,
    //    };
    //    ICryptoTransform decryptor = rijndaelManaged.CreateDecryptor(bytes2, bytes1);
    //    MemoryStream memoryStream = new MemoryStream(buffer);
    //    CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
    //    byte[] numArray = new byte[buffer.Length];
    //    int count = cryptoStream.Read(numArray, 0, numArray.Length);
    //    memoryStream.Close();
    //    cryptoStream.Close();
    //    return Encoding.UTF8.GetString(numArray, 0, count);
    //}
    public static string Decrypt(string cipherText, string initVector, string passPhrase)
    {
        byte[] bytes1 = Encoding.UTF8.GetBytes(initVector);
        byte[] buffer = Convert.FromBase64String(cipherText);
        byte[] bytes2 = new PasswordDeriveBytes(passPhrase, null).GetBytes(keysize / 8);

        RijndaelManaged rijndaelManaged = new RijndaelManaged
        {
            Mode = CipherMode.CBC
        };

        ICryptoTransform decryptor = rijndaelManaged.CreateDecryptor(bytes2, bytes1);
        using (MemoryStream memoryStream = new MemoryStream(buffer))
        using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
        {
            int bytesRead = 0;
            List<byte> decryptedBytes = new List<byte>();

            // Read decrypted data in chunks until the end of the stream
            do
            {
                byte[] chunk = new byte[4096]; // Adjust buffer size as needed
                bytesRead = cryptoStream.Read(chunk, 0, chunk.Length);
                decryptedBytes.AddRange(chunk.Take(bytesRead));
            } while (bytesRead > 0);

            // Remove padding bytes (if applicable)
            //if (rijndaelManaged.Padding == PaddingMode.PKCS7)
            //{
            //    int paddingSize = decryptedBytes[decryptedBytes.Count - 1];
            //    decryptedBytes.RemoveRange(decryptedBytes.Count - paddingSize, paddingSize);
            //}

            return Encoding.UTF8.GetString(decryptedBytes.ToArray());
        }
    }

    public static string DecryptConnectionString(string plainText, string initVector, string passPhrase)
    {
        int num1 = plainText.IndexOf("||");
        if (num1 == -1)
        {
            return Decrypt(plainText, initVector.Substring(0, 16), passPhrase.Substring(0, 16));
        }

        int num2 = num1 + 1;
        string str = plainText.Substring(0, num2 - 1);
        string cipherText = plainText.Substring(num2 + 1, plainText.Length - (num2 + 1));
        try
        {
            return str + Decrypt(cipherText, initVector.Substring(0, 16), passPhrase.Substring(0, 16));
        }
        catch (Exception)
        {
            return string.Empty;
        }
    }
}

/*
 طریقه استفاده از دستور
string encryptedText = StringEncryptor.Encrypt(plainText, initVector, passPhrase);
string decryptedText = StringEncryptor.Decrypt(encryptedText, initVector, passPhrase);

 */
