namespace StringCalculator
{
    using System;
    using System.Linq;

    using Should;

    using Xunit.Extensions;

    public class Tests
    {
        [Theory]
        [InlineData("Evaluate constant", "3,14", 3.14)]
        [InlineData("Evaluate simple addition", "3+4", 7)]
        [InlineData("Ignore whitespaces", " 2,5 + \n 6\t", 8.5)]
        [InlineData("Multiplication", "6 * 1,5", 9)]
        [InlineData("Substraction", "6 - 3,5", 2.5)]
        [InlineData("Division", "10 / 8", 1.25)]
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
        private static readonly Func<string, double> Parse = double.Parse;

        private static readonly Func<string, double> Pipeline = Parse
            .Wrap('+', (a, b) => a + b)
            .Wrap('-', (a, b) => a - b)
            .Wrap('/', (a, b) => a / b)
            .Wrap('*', (a, b) => a * b);

        public double Evaluate(string expression)
        {
            return Pipeline(expression);
        }
    }

    public static class PipelineExtensions
    {
        public static Func<string, double> Wrap(
            this Func<string, double> inner,
            char split,
            Func<double, double, double> aggregate)
        {
            return expression => expression
                .Split(split)
                .Select(inner)
                .Aggregate(aggregate);
        }
    }
}
