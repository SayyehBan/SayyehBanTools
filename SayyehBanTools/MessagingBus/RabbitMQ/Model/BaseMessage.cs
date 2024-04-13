namespace SayyehBanTools.MessagingBus.RabbitMQ.Model;

public class BaseMessage
{
    public Guid MessageId { get; set; } = Guid.NewGuid();
    public DateTime Creationtime { get; set; } = DateTime.UtcNow;
}
