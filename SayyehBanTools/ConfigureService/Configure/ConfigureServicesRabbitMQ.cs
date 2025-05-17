using Microsoft.Extensions.DependencyInjection;
using SayyehBanTools.ConnectionDB;
using SayyehBanTools.MessagingBus.RabbitMQ.SendMessage;
namespace SayyehBanTools.ConfigureService.Configure;
/// <summary>
/// این کلاس برای سرویس های رابیت مق استفاده میشود
/// </summary>
public class ConfigureServicesRabbitMQ
{
    /// <summary>
    /// این متد برای سرویس های رابیت مق استفاده میشود
    /// </summary>
    /// <param name="services"></param>
    public void ConfigureService(IServiceCollection services)
    {
        services.AddTransient<RabbitMQConnection, RabbitMQConnection>();
        services.AddTransient<ISendMessages, RabbitMQMessageBus>();
    }
}
/*
* طریقه صدا زدن سرویس ها
var configureServices = new ConfigureServicesRabbitMQ();
configureServices.ConfigureService(builder.Services);
*/