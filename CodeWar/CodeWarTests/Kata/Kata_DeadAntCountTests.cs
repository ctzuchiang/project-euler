using CodeWar.Kata;
using NUnit.Framework;

namespace CodeWarTests.Kata
{
    [TestFixture]
    public class Kata_DeadAntCountTests
    {
        [TestCase("ant ant ant ant", ExpectedResult = 0)]
        [TestCase(null, ExpectedResult = 0)]
        [TestCase("ant anantt aantnt", ExpectedResult = 2)]
        [TestCase("ant ant .... a nt", ExpectedResult = 1)]
        public int DeadAntCountTests(string ants)
        {
            return Kata_DeadAntCount.DeadAntCount(ants);
        }
    }
}