using CodeWar.Kata;
using NUnit.Framework;

namespace CodeWarTests.Kata
{
    [TestFixture]
    public class Kata_StringAverageTests
    {
        [TestCase("zero nine five two", ExpectedResult = "four", TestName = "Input \"zero nine five two\" should return \"four\"")]
        [TestCase("four six two three", ExpectedResult = "three", TestName = "Input \"four six two three\" should return \"three\"")]
        [TestCase("one two three four five", ExpectedResult = "three", TestName = "Input \"one two three four five\" should return \"three\"")]
        [TestCase("five four", ExpectedResult = "four", TestName = "Input \"five four\" should return \"four\"")]
        [TestCase("zero zero zero zero zero", ExpectedResult = "zero", TestName = "Input \"zero zero zero zero zero\" should return \"zero\"")]
        [TestCase("one one eight one", ExpectedResult = "two", TestName = "Input \"one one eight one\" should return \"two\"")]
        [TestCase("", ExpectedResult = "n/a", TestName = "Input \"\" should return \"n/a\"")]
        [TestCase("zero", ExpectedResult = "zero", TestName = "Input \"zero\" should return \"zero\"")]
        public string AverageStringTest(string input)
        {
            return Kata_StringAverage.AverageString(input);
        }
    }
}
