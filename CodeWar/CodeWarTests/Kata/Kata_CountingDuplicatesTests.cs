using CodeWar.Kata;
using NUnit.Framework;

namespace CodeWarTests.Kata
{
    [TestFixture]
    public class Kata_CountingDuplicatesTests
    {
        [TestCase("", ExpectedResult = 0)]
        [TestCase("abcde", ExpectedResult = 0)]
        [TestCase("aabbcde", ExpectedResult = 2)]
        [TestCase("aabBcde", ExpectedResult = 2)]
        [TestCase("Indivisibility", ExpectedResult = 1)]
        [TestCase("Indivisibilities", ExpectedResult = 2)]
        public int DuplicateCountTests(string str)
        {
            return Kata_CountingDuplicates.DuplicateCount(str);
        }
    }
}