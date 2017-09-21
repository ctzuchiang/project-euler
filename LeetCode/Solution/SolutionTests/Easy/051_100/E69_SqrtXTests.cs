using NUnit.Framework;
using Solution.Easy._051_100;

namespace SolutionTests.Easy._051_100
{
    [TestFixture()]
    public class E69_SqrtXTests
    {
        private E69_SqrtX _Target;

        [SetUp]
        public void SetUp()
        {
            _Target = new E69_SqrtX();
        }

        [TestCase(0, ExpectedResult = 0)]
        public int MySqrtTests(int number)
        {
            return _Target.MySqrt(number);
        }
    }
}
