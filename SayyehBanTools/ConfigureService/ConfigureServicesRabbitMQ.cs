﻿using Microsoft.Extensions.DependencyInjection;
using SayyehBanTools.MessagingBus.RabbitMQ.Connection;
using SayyehBanTools.MessagingBus.RabbitMQ.SendMessage;

namespace SayyehBanTools.ConfigureService;

public class ConfigureServicesRabbitMQ
{
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