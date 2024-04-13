namespace SayyehBanTools.MessagingBus.RabbitMQ.Model;

public class RabbitMqConnectionSettings
{
    public string Hostname { get; set; }
    public int Port { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string InitVector { get; set; }
    public string PassPhrase { get; set; }
}

