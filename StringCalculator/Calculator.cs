namespace StringCalculator
{
    using System.Linq;

    using Should;

    using Xunit.Extensions;

    public class Tests
    {
        [Theory]
        [InlineData("Evaluate constant", "3,14", 3.14)]
        [InlineData("Evaluate simple addition", "3+4", 7)]
        public void Examples(
            string scenario,
            string expression,
            double expectedResult)
        {
            new Calculator()
                .Evaluate(expression)
                .ShouldEqual(expectedResult, scenario);
        }
    }

    public class Calculator
    {
        public double Evaluate(string expression)
        {
            return expression
                .Split('+')
                .Select(x => double.Parse(x))
                .Aggregate((a, b) => a + b);
        }
    }
}
