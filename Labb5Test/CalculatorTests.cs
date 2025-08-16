using UnitTestLabb5;

namespace Labb5Test
{
    public class CalculatorTests
    {
        private readonly Calculator _calculator;

        public CalculatorTests()
        {
            _calculator = new Calculator();
        }

        //  Test av addition 
        [Theory]
        [InlineData(2, 3, 5)]
        [InlineData(-1, 4, 3)]
        [InlineData(0, 0, 0)]
        [InlineData(2.5, 2.5, 5)]
        [InlineData(-2.5, -2.5, -5)]
        public void Add_ShouldReturnExpectedResult(double a, double b, double expected)
        {
            var result = _calculator.Add(a, b);
            Assert.Equal(expected, result);
        }

        //  Test av subtraktion
        [Theory]
        [InlineData(5, 3, 2)]
        [InlineData(0, 4, -4)]
        [InlineData(-3, -2, -1)]
        [InlineData(2.5, 1.2, 1.3)]
        [InlineData(10, 0, 10)]
        public void Subtract_ShouldReturnExpectedResult(double a, double b, double expected)
        {
            var result = _calculator.Subtract(a, b);
            Assert.Equal(expected, result, 2); // tolerans 2 decimaler
        }

        //
        // Test av multiplikation
        [Theory]
        [InlineData(2, 3, 6)]
        [InlineData(-2, 3, -6)]
        [InlineData(0, 100, 0)]
        [InlineData(2.5, 2, 5)]
        [InlineData(-1.5, -2, 3)]
        public void Multiply_ShouldReturnExpectedResult(double a, double b, double expected)
        {
            var result = _calculator.Multiply(a, b);
            Assert.Equal(expected, result, 2);
        }

        //  Test av division
        [Theory]
        [InlineData(6, 3, 2)]
        [InlineData(7, 2, 3.5)]
        [InlineData(-9, 3, -3)]
        [InlineData(5, 2.5, 2)]
        [InlineData(0, 4, 0)]
        public void Divide_ShouldReturnExpectedResult(double a, double b, double expected)
        {
            var result = _calculator.Divide(a, b);
            Assert.Equal(expected, result, 2);
        }

        //  Test av division med noll -> ska kasta undantag
        [Fact]
        public void Divide_ByZero_ShouldThrowException()
        {
            Assert.Throws<DivideByZeroException>(() => _calculator.Divide(5, 0));
        }

        //  Test av PerformCalculation + historik
        [Fact]
        public void PerformCalculation_ShouldSaveToHistory()
        {
            var calc = _calculator.PerformCalculation(5, 3, "+");

            Assert.Equal(8, calc.Result);
            Assert.Single(_calculator.GetHistory()); // ska ligga en beräkning i historiken
            Assert.Equal("5 + 3 = 8", _calculator.GetHistory()[0].ToString());
        }
    }
}

