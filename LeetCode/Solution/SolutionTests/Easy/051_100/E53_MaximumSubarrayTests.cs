using NUnit.Framework;
using Solution.Easy._051_100;

namespace SolutionTests.Easy._051_100
{
    [TestFixture()]
    public class E53_MaximumSubarrayTests
    {
        private E53_MaximumSubarray _Target;

        [SetUp]
        public void SetUp()
        {
            _Target = new E53_MaximumSubarray();
        }

        [Ignore]
        [TestCase(new[] { 1 }, ExpectedResult = 1)]
        [TestCase(new[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 }, ExpectedResult = 6)]
        public int MaxSubArrayTests(int[] nums)
        {
            return _Target.MaxSubArray(nums);
        }
    }
}
