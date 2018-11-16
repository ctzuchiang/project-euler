using System;
using CodeWar.Kata.kyu8;
using NUnit.Framework;

namespace CodeWarTests.Kata.kyu8
{
    [TestFixture()]
    public class kyu8_BasicMathematicalOperationsTests
    {
        [TestCase('+', 4, 7, ExpectedResult = 11)]
        [TestCase('-', 15, 18, ExpectedResult = -3)]
        [TestCase('*', 5, 5, ExpectedResult = 25)]
        [TestCase('/', 49, 7, ExpectedResult = 7)]
        public double basicOp_Success_Test(char operation, double value1, double value2)
        {
            var target = new kyu8_BasicMathematicalOperations();

            var actual = target.basicOp(operation, value1, value2);

            return actual;
        }

        [Test]
        public void basicOp_Error_Test()
        {
            var target = new kyu8_BasicMathematicalOperations();

            Assert.That(() => target.basicOp('%', 1, 1), Throws.TypeOf<ArgumentException>());
        }
    }
}