using NUnit.Framework;
using Solution.Easy._401_450;

namespace SolutionTests.Easy._401_450
{
    [TestFixture]
    public class E414_ThirdMaximumNumberTests
    {
        private E414_ThirdMaximumNumber _Target;

        [SetUp]
        public void SetUp()
        {
            _Target = new E414_ThirdMaximumNumber();
        }

        [TestCase(new[] { 3, 2, 1 }, ExpectedResult = 1, TestName = "Give nums 3,2,1 should return 1")]
        [TestCase(new[] { 1, 2 }, ExpectedResult = 2, TestName = "Give nums 1,2 should return 2")]
        [TestCase(new[] { 2, 2, 3, 1 }, ExpectedResult = 1, TestName = "Give nums 2,2,3,1 should return 1")]
        [TestCase(new[] { 1, 1, 1 }, ExpectedResult = 1, TestName = "Give nums 1,1,1 should return 1")]
        public int ThirdMaximumNumberTests(int[] inputArray)
        {
            return _Target.ThirdMax(inputArray);
        }

    }
}