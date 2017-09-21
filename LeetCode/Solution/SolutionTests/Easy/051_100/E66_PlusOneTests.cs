using ExpectedObjects;
using NUnit.Framework;
using Solution.Easy._051_100;

namespace SolutionTests.Easy._051_100
{
    [TestFixture]
    public class E66_PlusOneTests
    {
        private E66_PlusOne _Target;

        [SetUp]
        public void SetUp()
        {
            _Target = new E66_PlusOne();
        }

        [Test]
        public void PlusOneTest_input_0_return_1()
        {
            var input = new int[] { 0 };
            var actual = _Target.PlusOne(input);
            var expected = new int[] { 1 };

            expected.ToExpectedObject().ShouldEqual(actual);
        }

        [Test]
        public void PlusOneTest_input_9_return_1_0()
        {
            var input = new int[] { 9 };
            var actual = _Target.PlusOne(input);
            var expected = new int[] { 1, 0 };

            expected.ToExpectedObject().ShouldEqual(actual);
        }
    }
}