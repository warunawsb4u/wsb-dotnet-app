using Xunit;

namespace MyHelloWorldApp.Tests;

public class SampleTests
{
    [Fact]
    public void Test_HelloWorldMessage_IsNotEmpty()
    {
        // Arrange
        string message = "Hello World from .NET running on Azure App Service!";

        // Act & Assert
        Assert.NotNull(message);
        Assert.Contains("Hello World", message);
    }

    [Theory]
    [InlineData(1, 1, 2)]
    [InlineData(10, 20, 30)]
    public void Test_MathCalculation(int a, int b, int expected)
    {
        Assert.Equal(expected, a + b);
    }
}
