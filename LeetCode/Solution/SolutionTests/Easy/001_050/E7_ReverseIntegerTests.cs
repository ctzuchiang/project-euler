using NUnit.Framework;
using Solution.Easy._001_050;

namespace SolutionTests.Easy._001_050
{
    [TestFixture]
    public class E7_ReverseIntegerTests
    {
        [SetUp]
        public void SetUp()
        {
            _Target = new E7_ReverseInteger();
        }

        private E7_ReverseInteger _Target;

        [TestCase(0, ExpectedResult = 0, TestName = "Give 0 should return 0")]
        [TestCase(123, ExpectedResult = 321, TestName = "Give 123 should return 321")]
        [TestCase(-123, ExpectedResult = -321, TestName = "Give -123 should return -321")]
        [TestCase(-2147483412, ExpectedResult = -2143847412, TestName = "Give -2147483412 should return -2143847412")]
        [TestCase(1534236469, ExpectedResult = 0, TestName = "Give 1534236469 should return 0 due to overflow")]
        [TestCase(-2147483648, ExpectedResult = 0, TestName = "Give -2147483648 should return 0 due to overflow")]
        public int ReverseIntegerTests(int input)
        {
            return _Target.Reverse(input);
        }
    }
}