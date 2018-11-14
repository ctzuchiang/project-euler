using CodeWar.Kata._8kyu;
using NUnit.Framework;

namespace CodeWarTests.Kata._8kyu
{
    [TestFixture()]
    public class Kata_TransportationOnVacationTests
    {
        [TestCase(0, ExpectedResult = 0)]
        [TestCase(1, ExpectedResult = 40)]
        [TestCase(3, ExpectedResult = 100)]
        [TestCase(7, ExpectedResult = 230)]
        [TestCase(10, ExpectedResult = 350)]
        [TestCase(17, ExpectedResult = 630)]
        public int RentalCarCostTest(int day)
        {
            var target = new Kata_TransportationOnVacation();

            var actual = target.RentalCarCost(day);

            return actual;
        }
    }
}