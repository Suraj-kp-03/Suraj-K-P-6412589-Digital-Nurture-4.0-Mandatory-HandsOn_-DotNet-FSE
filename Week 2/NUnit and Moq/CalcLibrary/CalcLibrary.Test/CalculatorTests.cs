using NUnit.Framework;
using CalcLibrary;


namespace CalcLibrary.Test
{
    [TestFixture]
    public class CalculatorTests
    {
        private SimpleCalculator _calc;

        [SetUp] // This method runs before each test in this class. Preparing the testcase environment.
        public void Setup()
        {
            _calc = new SimpleCalculator();
        }

        [TearDown] // Clears the result stored during testcases
        public void TearDown()
        {
            _calc.AllClear();
        }

        [TestCase(2.0, 3.0, 5.0)]
        [TestCase(0, 0, 0.0)]
        [TestCase(-1.5, 1.5, 0.0)]
        public void AdditionSum(double a, double b, double expected)
        {
            double result = _calc.Addition(a, b);
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(5.0, 3.0, 2.0)]
        [TestCase(-2.0, -3.0, 1.0)]
        [TestCase(10.5, 5.5, 5.0)]
        public void SubtractionDiff(double a, double b, double expected)
        {
            double result = _calc.Subtraction(a, b);
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(2.0, 3.0, 6.0)]
        [TestCase(-2.0, 3.0, -6.0)]
        [TestCase(0, 10, 0.0)]
        [TestCase(1.5, 2.0, 3.0)]
        public void MultiplicationProd(double a, double b, double expected)
        {
            double result = _calc.Multiplication(a, b);
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(10.0, 2.0, 5.0)]
        [TestCase(5.0, 0, double.NaN)]
        [TestCase(10.0, -2.0, -5.0)]
        [TestCase(0.0, 1.0, 0.0)]
        public void DivisionQuo(double a, double b, double expected)
        {
            if (b == 0)
            {
                Assert.Throws<System.DivideByZeroException>(() => _calc.Division(a, b));
            }
            else
            {
                double result = _calc.Division(a, b);
                Assert.That(result, Is.EqualTo(expected));
            }
        }

    }
}
