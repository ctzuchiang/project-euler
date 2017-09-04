using System.Collections.Generic;
using ExpectedObjects;
using NUnit.Framework;
using Solution.Medium._001_050;

namespace SolutionTests.Medium._001_050
{
    [TestFixture]
    public class M15_3SumTests
    {
        private M15_3Sum _Target;

        [SetUp]
        public void SetUp()
        {
            _Target = new M15_3Sum();
        }

        [Test()]
        public void ThreeSumTest()
        {
            var actual = _Target.ThreeSum(new[] { -1, 0, 1, 2, -1, -4 });

            var expected = new List<IList<int>>()
            {
                new List<int>{-1, -1, 2},
                new List<int>{-1, 0, 1}
            };
            expected.ToExpectedObject().ShouldEqual(actual);
        }
    }
}