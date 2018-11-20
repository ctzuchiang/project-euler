using System;
using NUnit.Framework;
using Solution.Others;

namespace SolutionTests.Others
{
    [TestFixture]
    public class URLifyTests
    {
        [TestCase("Hello World   ", 11, ExpectedResult = "Hello%20World")]
        [TestCase("Hello  World   ", 12, ExpectedResult = "Hello%20%20World")]
        [TestCase("HelloWorld   ", 12, ExpectedResult = "HelloWorld%20%20")]
        [TestCase(" Hello World", 12, ExpectedResult = "%20Hello%20World")]
        [TestCase("Hello World  ", 9, ExpectedResult = "Hello%20Wor")]
        [TestCase("Hello World  ", 0, ExpectedResult = "")]
        public string ReplaceSpace_Tests(string input, int trueLength)
        {
            var target = new URLify();
            var actual = target.ReplaceSpace(input, trueLength);

            return actual;
        }

        [Test]
        public void ReplaceSpace_Null_Test()
        {
            var target = new URLify();
            Assert.That(() => target.ReplaceSpace(null, 1), Throws.TypeOf<ArgumentNullException>());
        }
    }
}
