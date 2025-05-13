using Microsoft.Extensions.DependencyInjection;
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
            new ConfigureServicesRabbitMQ().ConfigureService(services);

            // Assert
            Assert.Contains(services, service => service.ServiceType == typeof(RabbitMQConnection));
            Assert.Contains(services, service => service.ServiceType == typeof(ISendMessages));
        }
    }
}
