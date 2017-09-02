using NUnit.Framework;
using Solution.Easy._001_050;

namespace SolutionTests.Easy._001_050
{
    [TestFixture]
    public class E27_RemoveElementTests
    {
        private E27_RemoveElement _Target;

        [SetUp]
        public void SetUp()
        {
            _Target = new E27_RemoveElement();
        }

        [TestCase(new int[] { 3, 2, 2, 3 }, 3, ExpectedResult = 2, TestName = "Give nums 3,2,2,3 and remove 3 should return 2")]
        public int RemoveDuplicatesfromSortedArrayTests(int[] inputArray,int removeElement)
        {
            return _Target.RemoveElement(inputArray, removeElement);
        }

        [TestCase(new int[] { 3, 2, 2, 3 }, 3, ExpectedResult = 2, TestName = "Give nums 3,2,2,3 and remove 3 should return 2")]
        public int RemoveDuplicatesfromSortedArrayTests2(int[] inputArray, int removeElement)
        {
            return _Target.RemoveElement2(inputArray, removeElement);
        }
    }
}