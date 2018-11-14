using NUnit.Framework;
using Solution.Easy._101_150;

namespace SolutionTests.Easy._101_150
{
    [TestFixture()]
    public class E136_Single_NumberTests
    {
        [TestCase(new[] { 1, 2, 2 }, ExpectedResult = 1)]
        [TestCase(new[] { 3, 2, 3 }, ExpectedResult = 2)]
        [TestCase(new[] { 4, 1, 2, 1, 2 }, ExpectedResult = 4)]
        public int SingleNumberTest(int[] nums)
        {
            var target = new E136_Single_Number();
            var actual = target.SingleNumber(nums);
            return actual;
        }
    }
}