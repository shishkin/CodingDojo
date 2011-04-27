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
            new FizzBuzz().Test(1)
                .ShouldEqual("1");
        }
    }

    public class FizzBuzz
    {
        public string Test(int number)
        {
            return "1";
        }
    }
}
