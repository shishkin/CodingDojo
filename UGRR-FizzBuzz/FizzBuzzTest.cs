namespace UGRR_FizzBuzz
{
    using System;
    using System.Linq;

    using Should;

    using Xunit;

    public class FizzBuzzTest
    {
        [Fact]
        public void OneIsOne()
        {
            new FizzBuzz()
                .Test(1)
                .ShouldEqual("1");
        }

        [Fact]
        public void TwoIsTwo()
        {
            new FizzBuzz()
                .Test(2)
                .ShouldEqual("2");
        }
    }

    public class FizzBuzz
    {
        public string Test(int number)
        {
            return number.ToString();
        }
    }
}
