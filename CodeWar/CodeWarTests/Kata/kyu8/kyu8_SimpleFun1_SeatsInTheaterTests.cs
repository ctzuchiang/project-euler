using CodeWar.Kata.kyu8;
using NUnit.Framework;

namespace CodeWarTests.Kata.kyu8
{
    [TestFixture()]
    public class kyu8_SimpleFun1_SeatsInTheaterTests
    {
        [TestCase(16, 11, 5, 3, ExpectedResult = 96)]
        [TestCase(1, 1, 1, 1, ExpectedResult = 0)]
        [TestCase(13, 6, 8, 3, ExpectedResult = 18)]
        [TestCase(60, 100, 60, 1, ExpectedResult = 99)]
        [TestCase(1000, 1000, 1000, 1000, ExpectedResult = 0)]
        public int SeatsInTheaterTest(int nCols, int nRows, int col, int row)
        {
            var target = new kyu8_SimpleFun1_SeatsInTheater();

            var actual = target.SeatsInTheater(nCols, nRows, col, row);

            return actual;
        }
    }
}