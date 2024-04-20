using Microsoft.Extensions.DependencyInjection;
using SayyehBanTools.MessagingBus.RabbitMQ.Connection;
using SayyehBanTools.MessagingBus.RabbitMQ.SendMessage;

namespace SayyehBanTools.ConfigureService;

public class ConfigureServicesRabbitMQNormal
{
    public void ConfigureService(IServiceCollection services)
    {
        services.AddTransient<RabbitMQConnectionNormal, RabbitMQConnectionNormal>();
        services.AddTransient<ISendMessages, RabbitMQMessageBusNormal>();
    }
}
