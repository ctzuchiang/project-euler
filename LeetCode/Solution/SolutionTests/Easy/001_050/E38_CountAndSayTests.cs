using NUnit.Framework;
using Solution.Easy._001_050;

namespace SolutionTests.Easy._001_050
{
    [TestFixture]
    public class E38_CountAndSayTests
    {
        private E38_CountAndSay _Target;

        [SetUp]
        public void SetUp()
        {
            _Target = new E38_CountAndSay();
        }

        [TestCase(1, ExpectedResult = "1")]
        [TestCase(2, ExpectedResult = "11")]
        [TestCase(3, ExpectedResult = "21")]
        [TestCase(4, ExpectedResult = "1211")]
        [TestCase(5, ExpectedResult = "111221")]
        [TestCase(6, ExpectedResult = "312211")]
        public string CountAndSayTests(int n)
        {
            return _Target.CountAndSay(n);
        }
    }
}