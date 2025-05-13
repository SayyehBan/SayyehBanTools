using Microsoft.Extensions.DependencyInjection;
using SayyehBanTools.MessagingBus.RabbitMQ.SendMessage;

/// <summary>
/// این کلاس برای سرویس های رابیت مق استفاده میشود
/// </summary>
public class ConfigureServicesRabbitMQNormal
{
    /// <summary>
    /// این متد برای سرویس های رابیت مق استفاده میشود
    /// </summary>
    /// <param name="services"></param>
    public void ConfigureService(IServiceCollection services)
    {
        services.AddTransient<RabbitMQConnectionNormal, RabbitMQConnectionNormal>();
        services.AddTransient<ISendMessages, RabbitMQMessageBusNormal>();
    }
}
