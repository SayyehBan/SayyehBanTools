using SayyehBanTools.Calc;

namespace SayyehBanToolsTest.Calc;

public class CalculatorTest
{
    [Theory]
    [InlineData(new double[] { 2, 3 }, 5)] // Add two numbers
    [InlineData(new double[] { 1, 2, 3 }, 6)] // Add three numbers
    [InlineData(new double[] { 0 }, 0)] // Add zero
    public void Add_ShouldReturnSum_WhenGivenMultipleNumbers(double[] numbers, double expectedResult)
    {
        // Act
        var result = Calculator.Add(numbers);

        // Assert
        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void Add_ShouldReturnZero_WhenGivenEmptyArray()
    {
        // Act
        var result = Calculator.Add();

        // Assert
        Assert.Equal(0, result);
    }
    [Theory]
    [InlineData(new double[] { 5, 3 }, 2)] // Subtract one number from another
    [InlineData(new double[] { 10, 2, 3 }, 5)] // Subtract multiple numbers
    public void Subtract_ShouldReturnDifference_WhenGivenMultipleNumbers(double[] numbers, double expectedResult)
    {
        // Act
        var result = Calculator.Subtract(numbers);

        // Assert
        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void Subtract_ShouldThrowArgumentException_WhenGivenEmptyArray()
    {
        // Assert
        Assert.Throws<ArgumentException>(() => Calculator.Subtract());
    }

    [Theory]
    [InlineData(new double[] { 6, 2 }, 3)] // Divide two numbers
    [InlineData(new double[] { 12, 3, 2 }, 2)] // Divide multiple numbers
    public void Divide_ShouldReturnQuotient_WhenGivenMultipleNumbers(double[] numbers, double expectedResult)
    {
        // Act
        var result = Calculator.Divide(numbers);

        // Assert
        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void Divide_ShouldThrowArgumentException_WhenGivenSingleNumber()
    {
        // Assert
        Assert.Throws<ArgumentException>(() => Calculator.Divide(2));
    }

    [Fact]
    public void Divide_ShouldThrowDivideByZeroException_WhenDividingByZero()
    {
        // Assert
        Assert.Throws<DivideByZeroException>(() => Calculator.Divide(5, 0));
    }

    [Theory]
    [InlineData(100, 10, 90)] // Apply 10% discount to 100
    [InlineData(200, 25, 150)] // Apply 25% discount to 200
    public void Discount_ShouldReturnDiscountedAmount_WhenGivenAmountAndPercent(decimal amount, short percent, decimal expectedResult)
    {
        // Act
        var result = Calculator.Discount(amount, percent);

        // Assert
        Assert.Equal(expectedResult, result);
    }
}
