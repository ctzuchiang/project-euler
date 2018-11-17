using CodeWar.Kata.kyu8;
using NUnit.Framework;

namespace CodeWarTests.Kata.kyu8
{
    [TestFixture()]
    public class kyu8_WilsonPrimesTests
    {
        [TestCase(5, true)]
        [TestCase(6, false)]
        [TestCase(9, false)]
        [TestCase(11, false)]
        [TestCase(13, true)]
        [TestCase(17, false)]
        [TestCase(25, false)]
        [TestCase(31, false)]
        [TestCase(54, false)]
        [TestCase(59, false)]
        [TestCase(64, false)]
        [TestCase(84, false)]
        [TestCase(91, false)]
        [TestCase(563, true)]
        public void AmIWilsonTest(int num, bool expected)
        {
            var target = new kyu8_WilsonPrimes();

            var actual = target.AmIWilson(num);

            Assert.AreEqual(expected, actual);
        }
    }
}