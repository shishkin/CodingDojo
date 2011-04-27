namespace UGRR_FizzBuzz
{
    using Should;

    using Xunit.Extensions;

    public class FizzBuzzTest
    {
        [Theory]
        [InlineData(1, "1", "One is one")]
        [InlineData(2, "2", "Two is two")]
        [InlineData(3, "Fizz", "Three is Fizz")]
        [InlineData(4, "4", "Four is Four")]
        [InlineData(5, "Buzz", "Five is Buzz")]
        public void NumberIsNumber(
            int number,
            string result,
            string message)
        {
            new FizzBuzz()
                .Test(number)
                .ShouldEqual(result, message);
        }
    }

    public class FizzBuzz
    {
        public string Test(int number)
        {
            if (number == 3)
            {
                return "Fizz";
            }
            if (number == 5)
            {
                return "Buzz";
            }
            return number.ToString();
        }
    }
}
