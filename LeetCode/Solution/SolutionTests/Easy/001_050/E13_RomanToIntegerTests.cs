using NUnit.Framework;
using Solution.Easy._001_050;

namespace SolutionTests.Easy._001_050
{
    [TestFixture]
    public class E13_RomanToIntegerTests
    {
        [SetUp]
        public void SetUp()
        {
            _Target = new E13_RomanToInteger();
        }

        private E13_RomanToInteger _Target;

        [TestCase("I", ExpectedResult = 1, TestName = "I = 1")]
        [TestCase("II", ExpectedResult = 2, TestName = "II = 2")]
        [TestCase("IV", ExpectedResult = 4, TestName = "IV = 4")]
        [TestCase("VI", ExpectedResult = 6, TestName = "VI = 6")]
        [TestCase("IX", ExpectedResult = 9, TestName = "IX = 9")]
        [TestCase("XIX", ExpectedResult = 19, TestName = "XIX = 19")]
        [TestCase("CMXCIX", ExpectedResult = 999, TestName = "CMXCIX = 999")]
        [TestCase("MCMXCVI", ExpectedResult = 1996, TestName = "MCMXCVI = 1996")]
        public int RomanToIntTest(string inputString)
        {
            return _Target.RomanToInt(inputString);
        }
    }
}
