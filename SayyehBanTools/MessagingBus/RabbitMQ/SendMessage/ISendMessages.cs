using SayyehBanTools.MessagingBus.RabbitMQ.Model;

namespace SayyehBanTools.MessagingBus.RabbitMQ.SendMessage;

public interface ISendMessages
{
    void SendMessage(BaseMessage message,string? exchange, string? QueueName);
}
