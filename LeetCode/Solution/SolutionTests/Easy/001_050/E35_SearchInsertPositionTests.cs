using NUnit.Framework;

namespace Solution.Easy._001_050.Tests
{
    [TestFixture]
    public class E35_SearchInsertPositionTests
    {
        private E35_SearchInsertPosition _Target;

        [SetUp]
        public void SetUp()
        {
            _Target = new E35_SearchInsertPosition();
        }


        [TestCase(new[] { 1, 3, 5, 6 }, 5, ExpectedResult = 2, TestName = "Int array 1,3,5,6 find 5's position should return 2")]
        [TestCase(new[] { 1, 3, 5, 6 }, 2, ExpectedResult = 1, TestName = "Int array 1,3,5,6 find 2's position should return 1")]
        [TestCase(new[] { 1, 3, 5, 6 }, 7, ExpectedResult = 4, TestName = "Int array 1,3,5,6 find 7's position should return 4")]
        [TestCase(new[] { 1, 3, 5, 6 }, 0, ExpectedResult = 0, TestName = "Int array 1,3,5,6 find 0's position should return 0")]
        public int SearchInsertTests(int[] numbers, int target)
        {
            return _Target.SearchInsert(numbers, target);
        }
    }
}