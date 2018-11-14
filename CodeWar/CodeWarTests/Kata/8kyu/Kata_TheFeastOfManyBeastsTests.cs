using CodeWar.Kata._8kyu;
using NUnit.Framework;

namespace CodeWarTests.Kata._8kyu
{
    [TestFixture()]
    public class Kata_TheFeastOfManyBeastsTests
    {
        [TestCase("great blue heron", "garlic naan")]
        [TestCase("chickadee", "chocolate cake")]
        public void Feast_True_Test(string beast, string dish)
        {
            var target = new Kata_TheFeastOfManyBeasts();
            
            var actaul = target.Feast(beast, dish);

            Assert.IsTrue(actaul);
        }

        [TestCase("brown bear", "bear claw")]
        public void Feast_False_Test(string beast, string dish)
        {
            var target = new Kata_TheFeastOfManyBeasts();

            var actaul = target.Feast(beast, dish);

            Assert.IsFalse(actaul);
        }
    }
}