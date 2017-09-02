using NUnit.Framework;
using Solution.Easy._001_050;

namespace SolutionTests.Easy._001_050
{
    [TestFixture]
    public class E20_ValidParenthesesTests
    {
        [SetUp]
        public void SetUp()
        {
            _Targer = new E20_ValidParentheses();
        }

        private E20_ValidParentheses _Targer;

        [TestCase("(){}[]", ExpectedResult = true, TestName = "(){}[] is true")]
        [TestCase("{[()]}", ExpectedResult = true, TestName = "{[()]} is true")]
        [TestCase("[([]])", ExpectedResult = false, TestName = "[([]]) is false")]
        [TestCase("([)", ExpectedResult = false, TestName = "([) is false")]
        public bool ValidParenthesesTests(string input)
        {
            return _Targer.IsValid(input);
        }
    }
}