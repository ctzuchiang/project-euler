using ExpectedObjects;
using NUnit.Framework;
using Solution.Easy._001_050;

namespace SolutionTests.Easy._001_050
{
    [TestFixture]
    public class E26_RemoveDuplicatesfromSortedArrayTests
    {
        private E26_RemoveDuplicatesfromSortedArray _Target;

        [SetUp]
        public void SetUp()
        {
            _Target = new E26_RemoveDuplicatesfromSortedArray();
        }

        [TestCase(new int[] { }, ExpectedResult = 0, TestName = "Give empty int array should return 0")]
        [TestCase(new int[] { 1, 1, 2 }, ExpectedResult = 2, TestName = "Give nums 1,1,2 should return 2")]
        [TestCase(new int[] { -1, 0, 0, 0, 0, 3, 3 }, ExpectedResult = 3, TestName = "Give nums -1,0,0,0,0,3,3 should return 3")]
        public int RemoveDuplicatesfromSortedArrayTests(int[] input)
        {
            return _Target.RemoveDuplicates(input);
        }

        [TestCase(new int[] { }, ExpectedResult = 0, TestName = "Give empty int array should return 0")]
        [TestCase(new int[] { 1, 1, 2 }, ExpectedResult = 2, TestName = "Give nums 1,1,2 should return 2")]
        [TestCase(new int[] { -1, 0, 0, 0, 0, 3, 3 }, ExpectedResult = 3, TestName = "Give nums -1,0,0,0,0,3,3 should return 3")]
        public int RemoveDuplicatesfromSortedArrayTests2(int[] input)
        {
            return _Target.RemoveDuplicates2(input);
        }
    }
}
