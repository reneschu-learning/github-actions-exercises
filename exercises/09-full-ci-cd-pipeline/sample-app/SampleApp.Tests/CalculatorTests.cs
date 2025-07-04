using Xunit;
using SampleApp;

namespace SampleApp.Tests
{
    public class CalculatorTests
    {
        private readonly Calculator _calculator;
        
        public CalculatorTests()
        {
            _calculator = new Calculator();
        }
        
        [Fact]
        public void Add_TwoPositiveNumbers_ReturnsCorrectSum()
        {
            // Arrange
            int a = 5;
            int b = 3;
            int expected = 8;
            
            // Act
            int result = _calculator.Add(a, b);
            
            // Assert
            Assert.Equal(expected, result);
        }
        
        [Fact]
        public void Add_PositiveAndNegativeNumber_ReturnsCorrectSum()
        {
            // Arrange
            int a = 10;
            int b = -3;
            int expected = 7;
            
            // Act
            int result = _calculator.Add(a, b);
            
            // Assert
            Assert.Equal(expected, result);
        }
        
        [Fact]
        public void Subtract_TwoPositiveNumbers_ReturnsCorrectDifference()
        {
            // Arrange
            int a = 10;
            int b = 4;
            int expected = 6;
            
            // Act
            int result = _calculator.Subtract(a, b);
            
            // Assert
            Assert.Equal(expected, result);
        }
        
        [Fact]
        public void Multiply_TwoPositiveNumbers_ReturnsCorrectProduct()
        {
            // Arrange
            int a = 6;
            int b = 7;
            int expected = 42;
            
            // Act
            int result = _calculator.Multiply(a, b);
            
            // Assert
            Assert.Equal(expected, result);
        }
        
        [Fact]
        public void Divide_TwoPositiveNumbers_ReturnsCorrectQuotient()
        {
            // Arrange
            double a = 15;
            double b = 3;
            double expected = 5;
            
            // Act
            double result = _calculator.Divide(a, b);
            
            // Assert
            Assert.Equal(expected, result);
        }
        
        [Fact]
        public void Divide_ByZero_ThrowsDivideByZeroException()
        {
            // Arrange
            double a = 10;
            double b = 0;
            
            // Act & Assert
            Assert.Throws<DivideByZeroException>(() => _calculator.Divide(a, b));
        }
        
        [Theory]
        [InlineData(2, true)]
        [InlineData(3, false)]
        [InlineData(0, true)]
        [InlineData(-4, true)]
        [InlineData(-3, false)]
        public void IsEven_VariousNumbers_ReturnsCorrectResult(int number, bool expected)
        {
            // Act
            bool result = _calculator.IsEven(number);
            
            // Assert
            Assert.Equal(expected, result);
        }
        
        [Theory]
        [InlineData(0, 1)]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        [InlineData(3, 6)]
        [InlineData(4, 24)]
        [InlineData(5, 120)]
        public void Factorial_ValidInput_ReturnsCorrectResult(int input, int expected)
        {
            // Act
            int result = _calculator.Factorial(input);
            
            // Assert
            Assert.Equal(expected, result);
        }
        
        [Fact]
        public void Factorial_NegativeNumber_ThrowsArgumentException()
        {
            // Arrange
            int input = -1;
            
            // Act & Assert
            Assert.Throws<ArgumentException>(() => _calculator.Factorial(input));
        }
    }
}
