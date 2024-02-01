using System.Security.Cryptography;
using System.Text;

namespace SayyehBanTools.Encryptor;

public class Encryptor
{
    private readonly string initVector;
    private readonly int keysize;
    private readonly string passPhrase;
    private string _plainText;
    public Encryptor()
    {
        initVector = "tu89geji340t89u2";
        passPhrase = "SayyehBanString";
        keysize = 256;
    }
    private string Encrypt(string plainText)
    {
        byte[] bytes1 = Encoding.UTF8.GetBytes(initVector);
        byte[] bytes2 = Encoding.UTF8.GetBytes(plainText);
        byte[] bytes3 = new PasswordDeriveBytes(passPhrase, null).GetBytes(keysize / 8);
        Rijndael managed = new RijndaelManaged
        {
            Mode = CipherMode.CBC
        };
        ICryptoTransform encryptor = managed.CreateEncryptor(bytes3, bytes1);
        MemoryStream memoryStream = new MemoryStream();
        CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
        cryptoStream.Write(bytes2, 0, bytes2.Length);
        cryptoStream.FlushFinalBlock();
        byte[] array = memoryStream.ToArray();
        memoryStream.Close();
        cryptoStream.Close();
        return Convert.ToBase64String(array);
    }

    private string Decrypt(string cipherText)
    {
        byte[] bytes1 = Encoding.ASCII.GetBytes(initVector);
        byte[] buffer = Convert.FromBase64String(cipherText);
        byte[] bytes2 = new PasswordDeriveBytes(passPhrase, null).GetBytes(keysize / 8);
        RijndaelManaged managed = new RijndaelManaged
        {
            Mode = CipherMode.CBC
        };
        ICryptoTransform decryptor = managed.CreateDecryptor(bytes2, bytes1);
        MemoryStream memoryStream = new MemoryStream(buffer);
        CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
        byte[] numArray = new byte[buffer.Length];
        int count = cryptoStream.Read(numArray, 0, numArray.Length);
        memoryStream.Close();
        cryptoStream.Close();
        return Encoding.UTF8.GetString(numArray, 0, count);
    }
    public string PlainText
    {
        set => _plainText = value;
    }
    public string EncryptText => Encrypt(_plainText);
    public string DecryptConnectionString
    {
        get
        {
            int num1 = _plainText.IndexOf("||");
            if (num1 == -1)
            {
                return Decrypt(_plainText);
            }
            int num2 = num1 + 1;
            string str = _plainText.Substring(0, num2 - 1);
            string cipherText = _plainText.Substring(num2 + 1, _plainText.Length - (num2 + 1));
            try
            {
                return str + Decrypt(cipherText);
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
    }
    public string DecryptText => Decrypt(_plainText);
}