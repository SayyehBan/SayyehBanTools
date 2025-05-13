using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;
/// <summary>
/// این کلاس برای ارسال پیام های رابیت مق استفاده میشود
/// </summary>
public class RabbitMQMessageBus : ISendMessages
{

    private readonly RabbitMQConnection _rabbitMqConnection;
    /// <summary>
    /// این متد برای ارسال پیام های رابیت مق استفاده میشود
    /// </summary>
    /// <param name="rabbitMqConnection"></param>
    public RabbitMQMessageBus(RabbitMQConnection rabbitMqConnection)
    {
        _rabbitMqConnection = rabbitMqConnection;
    }
    /// <summary>
    /// این متد برای ارسال پیام های رابیت مق استفاده میشود
    /// </summary>
    /// <param name="message"></param>
    /// <param name="exchange"></param>
    /// <param name="QueueName"></param>
    public void SendMessage(BaseMessage message, string? exchange, string? QueueName)
    {
        if (_rabbitMqConnection.CheckRabbitMQConnection())
        {
            using (var channel = _rabbitMqConnection.Connection.CreateModel())
            {
                if (QueueName != null)
                {
                    channel.QueueDeclare(queue: QueueName, durable: true, exclusive: false, autoDelete: false, arguments: null);
                }
                if (exchange != null)
                {
                    channel.ExchangeDeclare(exchange, ExchangeType.Fanout, true, false, null);
                }

                var json = JsonConvert.SerializeObject(message);
                var body = Encoding.UTF8.GetBytes(json);
                var Properties = channel.CreateBasicProperties();
                Properties.Persistent = true;
                channel.BasicPublish(exchange: exchange == null ? "" : exchange, routingKey: QueueName == null ? "" : QueueName, basicProperties: Properties, body: body);
            }
        }
    }
}
