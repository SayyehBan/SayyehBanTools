namespace SayyehBanTools.MessagingBus.RabbitMQ.Model;

public class RabbitMqConnectionSettings
{
    public string Hostname { get; set; }
    public string Port { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string InitVector { get; set; }
    public string PassPhrase { get; set; }
}

/*
 طریقه دادن اطلاعات به 
RabbitMQ in program.cs
var rabbitMqConnectionSettings = new RabbitMqConnectionSettings();
rabbitMqConnectionSettings.Hostname = "HyyV3VbQHmNeQglHqlhcKQ==";
rabbitMqConnectionSettings.Port = "EpPdu9pj1Nus2am5LbmM6w=="; // Default RabbitMQ port
rabbitMqConnectionSettings.Username = "r/mhRXOYeJERTka7tzHfwA==";
rabbitMqConnectionSettings.Password = "r/mhRXOYeJERTka7tzHfwA==";
rabbitMqConnectionSettings.InitVector = "3p2ra5ux5e357t2i";
rabbitMqConnectionSettings.PassPhrase = "4l146t34556422ny";
builder.Services.Configure<RabbitMqConnectionSettings>((IConfiguration)rabbitMqConnectionSettings);
 
 */