using Newtonsoft.Json;
using RabbitMQ.Client;
using SayyehBanTools.MessagingBus.RabbitMQ.Connection;
using SayyehBanTools.MessagingBus.RabbitMQ.Model;
using System.Text;

namespace SayyehBanTools.MessagingBus.RabbitMQ.SendMessage;

public class RabbitMQMessageBusNormal : ISendMessages
{

    private readonly RabbitMQConnectionNormal _rabbitMqConnectionNormal;
    public RabbitMQMessageBusNormal(RabbitMQConnectionNormal rabbitMqConnectionNormal)
    {
        _rabbitMqConnectionNormal = rabbitMqConnectionNormal;
    }
    public void SendMessage(BaseMessage message, string QueueName)
    {
        if (_rabbitMqConnectionNormal.CheckRabbitMQConnection())
        {
            using (var channel = _rabbitMqConnectionNormal.Connection.CreateModel())
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