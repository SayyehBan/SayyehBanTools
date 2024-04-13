using RabbitMQ.Client;
using SayyehBanTools.Encryptor;
using SayyehBanTools.MessagingBus.RabbitMQ.Model;

namespace SayyehBanTools.MessagingBus.RabbitMQ.Connection;

public class RabbitMQConnection
{
    private readonly RabbitMqConnectionSettings _rabbitMqConnectionSettings;
    private readonly string _hostname;
    private readonly string _queueName;
    private readonly string _username;
    private readonly string _password;
    private readonly int _port;
    public IConnection Connection { get;  set; }
    public IModel Channel { get;  set; }
    public RabbitMQConnection()
    {
        
    }
    public RabbitMQConnection(RabbitMqConnectionSettings rabbitMqConnectionSettings)
    {
        _rabbitMqConnectionSettings = rabbitMqConnectionSettings;
        _hostname = StringEncryptor.Decrypt(_rabbitMqConnectionSettings.Hostname, _rabbitMqConnectionSettings.InitVector, _rabbitMqConnectionSettings.PassPhrase);
        _username = StringEncryptor.Decrypt(_rabbitMqConnectionSettings.Username, _rabbitMqConnectionSettings.InitVector, _rabbitMqConnectionSettings.PassPhrase);
        _password = StringEncryptor.Decrypt(_rabbitMqConnectionSettings.Password, _rabbitMqConnectionSettings.InitVector, _rabbitMqConnectionSettings.PassPhrase);
        _port = Convert.ToInt32(StringEncryptor.Decrypt(_rabbitMqConnectionSettings.Port.ToString(), _rabbitMqConnectionSettings.InitVector, _rabbitMqConnectionSettings.PassPhrase));
    }
    public void CreateRabbitMQConnection()
    {
        try
        {
            var factory = new ConnectionFactory
            {
                HostName = _hostname,
                UserName = _username,
                Password = _password
            };
            Connection = factory.CreateConnection();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"can not create connection: {ex.Message}");
        }
    }

    public bool CheckRabbitMQConnection()
    {
        if (Connection != null)
        {
            return true;
        }
        CreateRabbitMQConnection();
        return Connection != null;
    }
}
