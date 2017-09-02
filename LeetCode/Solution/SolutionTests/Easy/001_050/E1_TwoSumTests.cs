using ExpectedObjects;
using NUnit.Framework;
using Solution.Easy._001_050;

namespace SolutionTests.Easy._001_050
{
    [TestFixture]
    public class E1_TwoSumTests
    {
        /// <summary>
        ///     Given nums = [2, 7, 11, 15], target = 9,
        ///     Because nums[0] + nums[1] = 2 + 7 = 9,
        ///     return [0, 1].
        /// </summary>
        private E1_TwoSum _Target;

        [SetUp]
        public void SetUp()
        {
            _Target = new E1_TwoSum();
        }

        [Test]
        public void Give_nums_2_7_11_15_taregt_9_should_get_0_1()
        {
            var actual = _Target.Sum(new[] { 2, 7, 11, 15 }, 9);

            var expected = new[] { 0, 1 };

            expected.ToExpectedObject().ShouldEqual(actual);
        }

        [Test]
        public void Give_nums_3_2_4_taregt_9_should_get_1_2()
        {
            var actual = _Target.Sum(new[] { 3, 2, 4 }, 6);

            var expected = new[] { 1, 2 };

            expected.ToExpectedObject().ShouldEqual(actual);
        }
    }
}