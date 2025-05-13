using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using SayyehBanTools.MessagingBus.RabbitMQ.Model;

/// <summary>
/// این کلاس برای اتصال به رابیت مق استفاده میشود
/// </summary>
public class RabbitMQConnectionNormal
{
    private readonly RabbitMqConnectionSettingsNormal _rabbitMqConnectionSettingsNormal;
    private readonly string _hostname;
    private readonly string _username;
    private readonly string _password;
    private readonly int _port;
    public IConnection Connection { get; set; }
    public IModel Channel { get; set; }
    /// <summary>
    /// این متد برای اتصال به رابیت مق استفاده میشود
    /// </summary>
    public RabbitMQConnectionNormal()
    {

    }
    /// <summary>
    /// // این متد برای اتصال به رابیت مق استفاده میشود
    /// </summary>
    /// <param name="rabbitMqConnectionSettingsNormal"></param>
    public RabbitMQConnectionNormal(IOptions<RabbitMqConnectionSettingsNormal> rabbitMqConnectionSettingsNormal)
    {
        _rabbitMqConnectionSettingsNormal = rabbitMqConnectionSettingsNormal.Value;

        _port = Convert.ToInt32(_rabbitMqConnectionSettingsNormal.Port.ToString());
    }
    public void CreateRabbitMQConnection()
    {
        try
        {
            var factory = new ConnectionFactory
            {
                HostName = _hostname,
                UserName = _username,
                Password = _password,
                Port = _port,

            };
            Connection = factory.CreateConnection();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"can not create connection: {ex.Message}");
        }
    }
    /// <summary>
    /// این متد برای بررسی اتصال به رابیت مق استفاده میشود
    /// </summary>
    /// <returns></returns>
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
