namespace SayyehBanTools.MessagingBus.RabbitMQ.Model;

public class RabbitMqConnectionSettingsNormal
{
    public string Hostname { get; set; }
    public string Port { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string queue { get; set; }
}

/*
 طریقه دادن اطلاعات به 
RabbitMQ in program.cs
var rabbitMqConnectionSettings = new RabbitMqConnectionSettings();
rabbitMqConnectionSettings.Hostname = "localhost";
rabbitMqConnectionSettings.Port = "5672"; // Default RabbitMQ port
rabbitMqConnectionSettings.Username = "guset";
rabbitMqConnectionSettings.Password = "guest";
builder.Services.Configure<RabbitMqConnectionSettingsNormal>((IConfiguration)rabbitMqConnectionSettingsNormal);
 
 */