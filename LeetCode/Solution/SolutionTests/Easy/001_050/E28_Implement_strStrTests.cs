using NUnit.Framework;
using Solution.Easy._001_050;

namespace SolutionTests.Easy._001_050
{
    [TestFixture]
    public class E28_Implement_strStrTests
    {
        private E28_Implement_strStr _Target;

        [SetUp]
        public void SetUp()
        {
            _Target = new E28_Implement_strStr();
        }

        [TestCase("", "", ExpectedResult = 0, TestName = "Give empty string and find empty string")]
        [TestCase("", "a", ExpectedResult = -1, TestName = "Give empty string and find \"a\"")]
        public int RemoveDuplicatesfromSortedArrayTests(string haystack, string needle)
        {
            return _Target.StrStr(haystack, needle);
        }

        [TestCase("", "", ExpectedResult = 0, TestName = "Give empty string and find empty string")]
        [TestCase("", "a", ExpectedResult = -1, TestName = "Give empty string and find \"a\"")]
        public int RemoveDuplicatesfromSortedArrayTests2(string haystack, string needle)
        {
            return _Target.StrStr2(haystack, needle);
        }
    }
}