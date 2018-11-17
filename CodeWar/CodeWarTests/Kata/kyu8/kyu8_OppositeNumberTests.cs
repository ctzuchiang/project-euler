using CodeWar.Kata.kyu8;
using NUnit.Framework;

namespace CodeWarTests.Kata.kyu8
{
    [TestFixture()]
    public class kyu8_OppositeNumberTests
    {
        [TestCase(1, -1)]
        [TestCase(-1, 1)]
        [TestCase(0, 0)]
        public void OppositeTest(int num, int expected)
        {
            var target = new kyu8_OppositeNumber();

            var actual = target.Opposite(num);

            Assert.AreEqual(expected, actual);
        }
    }
}