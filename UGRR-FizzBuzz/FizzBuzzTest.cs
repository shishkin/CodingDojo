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
        [InlineData(6, "Fizz", "Six is Fizz")]
        [InlineData(10, "Buzz", "Ten is Buzz")]
        [InlineData(15, "FizzBuzz", "Fifteen is FizzBuzz")]
        [InlineData(13, "Fizz", "Thirteen contains 3 and is Fizz")]
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
            var result = "";
            if (IsFizz(number))
            {
                result += "Fizz";
            }
            if (IsBuzz(number))
            {
                result += "Buzz";
            }
            if (!IsFizz(number) && !IsBuzz(number))
            {
                result = number.ToString();
            }
            return result;
        }

        private bool IsBuzz(int number)
        {
            return number % 5 == 0;
        }

        private bool IsFizz(int number)
        {
            return number % 3 == 0 ||
                number.ToString().Contains("3");
        }
    }
}
