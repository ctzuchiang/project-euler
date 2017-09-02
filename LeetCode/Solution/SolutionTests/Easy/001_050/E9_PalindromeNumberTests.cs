using NUnit.Framework;
using Solution.Easy._001_050;

namespace SolutionTests.Easy._001_050
{
    [TestFixture]
    public class E9_PalindromeNumberTests
    {
        private E9_PalindromeNumber _Target;

        [SetUp]
        public void SetUp()
        {
            _Target = new E9_PalindromeNumber();
        }

        [TestCase(121, ExpectedResult = true, TestName = "Give 121 should return true")]
        [TestCase(-121, ExpectedResult = false, TestName = "Give negative should return false")]
        public bool PalindromeNumberTests(int input)
        {
            return _Target.IsPalindrome(input);
        }
    }
}
