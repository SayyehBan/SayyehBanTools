using Newtonsoft.Json;
using RabbitMQ.Client;
using SayyehBanTools.MessagingBus.RabbitMQ.Connection;
using SayyehBanTools.MessagingBus.RabbitMQ.Model;
using System.Text;

namespace SayyehBanTools.MessagingBus.RabbitMQ.SendMessage;

public interface ISendMessages
{
    void SendMessage(BaseMessage message, string QueueName);
}
public class RabbitMQMessageBus : ISendMessages
{
    private readonly RabbitMQConnection rabbitMQConnection;

    public RabbitMQMessageBus(RabbitMQConnection RabbitMQConnection)
    {
        rabbitMQConnection = RabbitMQConnection; 
        rabbitMQConnection.CheckRabbitMQConnection();
    }

    public void SendMessage(BaseMessage message, string QueueName)
    {
        if (rabbitMQConnection.CheckRabbitMQConnection())
        {
            using (var channel = rabbitMQConnection.Connection.CreateModel())
            {
                channel.QueueDeclare(queue: QueueName, durable: true, exclusive: false, autoDelete: false, arguments: null);

                var json = JsonConvert.SerializeObject(message);
                var body = Encoding.UTF8.GetBytes(json);
                var Properties = channel.CreateBasicProperties();
                Properties.Persistent = true;
                channel.BasicPublish(exchange: "", routingKey: QueueName, basicProperties: Properties, body: body);
            }
        }
    }
}