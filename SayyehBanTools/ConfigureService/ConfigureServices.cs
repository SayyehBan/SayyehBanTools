using Microsoft.Extensions.DependencyInjection;
using SayyehBanTools.MessagingBus.RabbitMQ.SendMessage;

namespace SayyehBanTools.ConfigureService;

public class ConfigureServices
{
    public void ConfigureService(IServiceCollection services)
    {
        services.AddTransient<ISendMessages, RabbitMQMessageBus>();
    }
}
/*
* طریقه صدا زدن سرویس ها
var configureServices = new ConfigureServices();
configureServices.ConfigureService(builder.Services);
*/