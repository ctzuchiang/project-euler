using CodeWar.Kata.kyu8;
using NUnit.Framework;

namespace CodeWarTests.Kata.kyu8
{
    [TestFixture()]
    public class kyu8_YouOnlyNeedOne_BeginnerTests
    {
        [TestCase(new object[] { 66, 101 }, 66, true)]
        [TestCase(new object[] { 80, 117, 115, 104, 45, 85, 112, 115 }, 45, true)]
        [TestCase(new object[] { 't', 'e', 's', 't' }, 'e', true)]
        [TestCase(new object[] { "what", "a", "great", "kata" }, "kat", false)]
        public void CheckTest(object[] array, object stick, bool expected)
        {
            var target = new kyu8_YouOnlyNeedOne_Beginner();

            var actual = target.Check(array, stick);

            Assert.AreEqual(expected, actual);
        }
    }
}