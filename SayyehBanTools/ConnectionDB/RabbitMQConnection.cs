using SayyehBanTools.Encryptor;

namespace SayyehBanTools.ConnectionDB;

public class RabbitMQConnection
{
    public static Uri DefaultConnection()
    {
        string connection = "amqp://guest:guest@localhost:5672";
        Uri uri = new Uri(connection);
        return uri;
    }

    public static Uri RabbitMQ(string Username, string Password, string Url, string Port, string InitVector, string PassPhrase)
    {
        string username = StringEncryptor.Decrypt(Username, InitVector, PassPhrase);
        string password = StringEncryptor.Decrypt(Password, InitVector, PassPhrase);
        string url = StringEncryptor.Decrypt(Url, InitVector, PassPhrase);
        string port = StringEncryptor.Decrypt(Port, InitVector, PassPhrase);
        string connection = $"amqp://{username}:{password}@{url}:{port}";
        Uri uri = new Uri(connection);
        return uri;
    }
    public static Uri RabbitMQ(string Username, string Password, string Url, string Port)
    {
        string connection = $"amqp://{Username}:{Password}@{Url}:{Port}";
        Uri uri = new Uri(connection);
        return uri;
    }
    public static Uri CloudAMQP(string Username, string Password, string Url,  string InitVector, string PassPhrase)
    {
        string username = StringEncryptor.Decrypt(Username, InitVector, PassPhrase);
        string password = StringEncryptor.Decrypt(Password, InitVector, PassPhrase);
        string url = StringEncryptor.Decrypt(Url, InitVector, PassPhrase);
     
        string connection = $"amqps://{username}:{password}@{url}";
        Uri uri = new Uri(connection);
        return uri;
    }
    public static Uri CloudAMQP(string Username, string Password, string Url)
    {
     
        string connection = $"amqps://{Username}:{Password}@{Url}";
        Uri uri = new Uri(connection);
        return uri;
    }
}
//string plainText = "متن مورد نظر برای رمزنگاری";
//string encryptedText = StringEncryptor.Encrypt(plainText);
//string encryptedText = "متن رمزنگاری شده";
//string plainText = StringEncryptor.Decrypt(encryptedText);
//string plainText = "ConnectionString||密文";
//string connectionString = StringEncryptor.DecryptConnectionString(plainText);