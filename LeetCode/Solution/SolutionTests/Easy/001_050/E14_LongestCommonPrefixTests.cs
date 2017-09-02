using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solution.Easy._001_050;

namespace SolutionTests.Easy._001_050
{
    [TestClass()]
    public class E14_LongestCommonPrefixTests
    {
        private E14_LongestCommonPrefix _Target;

        [TestInitialize]
        public void SetUp()
        {
            _Target = new E14_LongestCommonPrefix();
        }

        [TestMethod()]
        public void Input_ABCDD_ABC_ABCXX_should_return_ABC()
        {
            var input = new[] {"ABCDD", "ABC", "ABCXX"};

            var actual = _Target.LongestCommonPrefix(input);

            var expected = "ABC";

            Assert.AreEqual(expected,actual);
        }

        [TestMethod()]
        public void Input_ABCDD_ABCDX_ABCXX_should_return_ABC()
        {
            var input = new[] { "ABCDD", "ABCDX", "ABCXX" };

            var actual = _Target.LongestCommonPrefix(input);

            var expected = "ABC";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Input_emptyArray_should_return_emptyString()
        {
            var input = new string[]{};

            var actual = _Target.LongestCommonPrefix(input);

            var expected = "";

            Assert.AreEqual(expected, actual);
        }
    }
}
