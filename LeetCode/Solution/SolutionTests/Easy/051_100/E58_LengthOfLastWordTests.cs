using NUnit.Framework;
using Solution.Easy._051_100;

namespace SolutionTests.Easy._051_100
{
    [TestFixture()]
    public class E58_LengthOfLastWordTests
    {
        private E58_LengthOfLastWord _Target;

        [SetUp]
        public void SetUp()
        {
            _Target = new E58_LengthOfLastWord();
        }

        [TestCase("Hello World", ExpectedResult = 5, TestName = "input \"Hello World\" return 5")]
        [TestCase("a ", ExpectedResult = 1, TestName = "input \"a \" return 1")]
        public int LengthOfLastWordTests(string input)
        {
            return _Target.LengthOfLastWord(input);
        }

        [TestCase("Hello World", ExpectedResult = 5, TestName = "input \"Hello World\" return 5")]
        [TestCase("a ", ExpectedResult = 1, TestName = "input \"a \" return 1")]
        public int LengthOfLastWord2Tests(string input)
        {
            return _Target.LengthOfLastWord2(input);
        }
    }
}
