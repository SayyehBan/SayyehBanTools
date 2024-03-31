﻿using SayyehBanTools.Encryptor;

namespace SayyehBanTools.ConnectionDB;

public class RabbitMQConnection
{
    public static string DefaultConnection()
    {
        string connection = "amqp://guest:guest@localhost:5672";
        return connection;
    }
    public static string DynamicConnection(string Username, string Password, string Url, string Port, string InitVector, string PassPhrase)
    {
        string username = StringEncryptor.Decrypt(Username, InitVector, PassPhrase);
        string password = StringEncryptor.Decrypt(Password, InitVector, PassPhrase);
        string url = StringEncryptor.Decrypt(Url, InitVector, PassPhrase);
        string port = StringEncryptor.Decrypt(Port, InitVector, PassPhrase);
        string connection = $"amqp://{username}:{password}@{url}:{port}";
        return connection;
    }
}
//string plainText = "متن مورد نظر برای رمزنگاری";
//string encryptedText = StringEncryptor.Encrypt(plainText);
//string encryptedText = "متن رمزنگاری شده";
//string plainText = StringEncryptor.Decrypt(encryptedText);
//string plainText = "ConnectionString||密文";
//string connectionString = StringEncryptor.DecryptConnectionString(plainText);