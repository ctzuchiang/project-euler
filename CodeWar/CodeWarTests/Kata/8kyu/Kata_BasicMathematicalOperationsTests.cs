using CodeWar.Kata._8kyu;
using NUnit.Framework;
using System;

namespace CodeWarTests.Kata._8kyu
{
    [TestFixture()]
    public class Kata_BasicMathematicalOperationsTests
    {
        [TestCase('+', 4, 7, ExpectedResult = 11)]
        [TestCase('-', 15, 18, ExpectedResult = -3)]
        [TestCase('*', 5, 5, ExpectedResult = 25)]
        [TestCase('/', 49, 7, ExpectedResult = 7)]
        public double basicOp_Success_Test(char operation, double value1, double value2)
        {
            var target = new Kata_BasicMathematicalOperations();

            var actual = target.basicOp(operation, value1, value2);

            return actual;
        }

        [Test]
        public void basicOp_Error_Test()
        {
            var target = new Kata_BasicMathematicalOperations();

            Assert.That(() => target.basicOp('%', 1, 1), Throws.TypeOf<ArgumentException>());
        }
    }
}