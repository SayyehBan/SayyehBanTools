﻿using Microsoft.Extensions.DependencyInjection;
using SayyehBanTools.MessagingBus.RabbitMQ.Connection;
using SayyehBanTools.MessagingBus.RabbitMQ.SendMessage;

namespace SayyehBanTools.ConfigureService;

public class ConfigureServices
{
    public void ConfigureService(IServiceCollection services)
    {
        services.AddTransient<RabbitMQConnection, RabbitMQConnection>();
        services.AddTransient<RabbitMQConnectionNormal, RabbitMQConnectionNormal>();
        services.AddTransient<ISendMessages, RabbitMQMessageBus>();
        services.AddTransient<ISendMessages, RabbitMQMessageBusNormal>();
    }
}
/*
* طریقه صدا زدن سرویس ها
var configureServices = new ConfigureServices();
configureServices.ConfigureService(builder.Services);
*/