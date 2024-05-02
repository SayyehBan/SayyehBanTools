using Microsoft.Extensions.DependencyInjection;
using SayyehBanTools.ConfigureService;
using SayyehBanTools.MessagingBus.RabbitMQ.Connection;
using SayyehBanTools.MessagingBus.RabbitMQ.SendMessage;

namespace SayyehBanToolsTest.ConfigureService;

public class ConfigureServicesRabbitMQTest
{
    public class ConfigureServicesRabbitMQTests
    {
        [Fact]
        public void ConfigureServices_ShouldAddRabbitMQServices()
        {
            // Arrange
            var services = new ServiceCollection();

            // Act
            new ConfigureServicesRabbitMQ().ConfigureService(services); // Corrected method name

            // Assert
            Assert.True(services.Any(service => service.ServiceType == typeof(RabbitMQConnection)));
            Assert.True(services.Any(service => service.ServiceType == typeof(ISendMessages)));
        }
    }

}
