using Microsoft.Extensions.DependencyInjection;
using Moq;
using SayyehBanTools.ConfigureService;
using SayyehBanTools.MessagingBus.RabbitMQ.Connection;
using SayyehBanTools.MessagingBus.RabbitMQ.SendMessage;

namespace SayyehBanToolsTest.ConfigureService;

public class ConfigureServicesRabbitMQNormalTest
{

    [Fact]
    public void ConfigureService_ShouldAddNormalRabbitMQServices()
    {
        // Arrange
        var services = new ServiceCollection();
        var mockConnection = new Mock<RabbitMQConnectionNormal>();
        var mockMessages = new Mock<ISendMessages>();

        // Act
        new ConfigureServicesRabbitMQNormal().ConfigureService(services);

        // Assert service registration (assuming no explicit configuration methods)
        Assert.True(services.Any(service => service.ServiceType == typeof(RabbitMQConnectionNormal)));
        Assert.True(services.Any(service => service.ServiceType == typeof(ISendMessages)));
    }
}
