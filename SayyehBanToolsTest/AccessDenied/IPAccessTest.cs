using SayyehBanTools.AccessDenied;

namespace SayyehBanToolsTest.AccessDenied;

public class IPAccessTests
{
    [Theory]
    [InlineData("192.168.1.10", "192.168.1.1", "192.168.1.255", true)] // IP in range
    [InlineData("10.0.0.5", "10.0.0.1", "10.0.0.10", true)] // IP in range
    [InlineData("172.16.0.1", "172.16.0.10", "172.16.0.20", false)] // IP out of range
    [InlineData("192.168.2.5", "192.168.1.1", "192.168.1.255", false)] // IP out of range
    public void IsInRange_ShouldReturnExpectedResult(string ipAddress, string rangeStart, string rangeEnd, bool expectedResult)
    {
        // Arrange

        // Act
        bool result = IPAccess.IsInRange(ipAddress, rangeStart, rangeEnd);

        // Assert
        Assert.Equal(expectedResult, result);
    }
}
