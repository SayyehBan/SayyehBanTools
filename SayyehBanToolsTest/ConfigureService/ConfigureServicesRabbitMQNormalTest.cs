using Microsoft.Extensions.DependencyInjection;
using Moq;
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
        Assert.Contains(services, service => service.ServiceType == typeof(RabbitMQConnectionNormal));
        Assert.Contains(services, service => service.ServiceType == typeof(ISendMessages));
    }
}
