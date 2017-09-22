using NUnit.Framework;
using Solution.Easy._051_100;

namespace SolutionTests.Easy._051_100
{
    [TestFixture()]
    public class E70_ClimbingStairsTests
    {
        private E70_ClimbingStairs _Target;

        [SetUp]
        public void SetUp()
        {
            _Target = new E70_ClimbingStairs();
        }

        [TestCase(1, ExpectedResult = 1)]
        [TestCase(2, ExpectedResult = 2)]
        [TestCase(3, ExpectedResult = 3)]
        [TestCase(4, ExpectedResult = 5)]
        [TestCase(5, ExpectedResult = 8)]
        public int ClimbStairsTests(int steps)
        {
            return _Target.ClimbStairs(steps);
        }
    }
}
