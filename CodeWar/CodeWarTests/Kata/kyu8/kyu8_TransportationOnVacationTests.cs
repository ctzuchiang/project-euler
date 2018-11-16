using CodeWar.Kata.kyu8;
using NUnit.Framework;

namespace CodeWarTests.Kata.kyu8
{
    [TestFixture()]
    public class kyu8_TransportationOnVacationTests
    {
        [TestCase(0, ExpectedResult = 0)]
        [TestCase(1, ExpectedResult = 40)]
        [TestCase(3, ExpectedResult = 100)]
        [TestCase(7, ExpectedResult = 230)]
        [TestCase(10, ExpectedResult = 350)]
        [TestCase(17, ExpectedResult = 630)]
        public int RentalCarCostTest(int day)
        {
            var target = new kyu8_TransportationOnVacation();

            var actual = target.RentalCarCost(day);

            return actual;
        }
    }
}