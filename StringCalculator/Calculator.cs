namespace StringCalculator
{
    using System;

    using Xunit;
    using Should;

    public class Tests
    {
        [Fact]
        public void Evaluate_decimal_constant()
        {
            new Calculator().Evaluate("3,14").ShouldEqual(3.14m);
        }
    }

    public class Calculator
    {
        public decimal Evaluate(string expression)
        {
            throw new NotImplementedException();
        }
    }
}
