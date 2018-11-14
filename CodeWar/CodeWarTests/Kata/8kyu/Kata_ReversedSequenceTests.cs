using CodeWar.Kata._8kyu;
using NUnit.Framework;

namespace CodeWarTests.Kata._8kyu
{
    [TestFixture()]
    public class Kata_ReversedSequenceTests
    {
        [TestCase(1, ExpectedResult = new[] { 1 })]
        [TestCase(3, ExpectedResult = new[] { 3, 2, 1 })]
        [TestCase(5, ExpectedResult = new[] { 5, 4, 3, 2, 1 })]
        public int[] ReverseSeqTest(int n)
        {
            var target = new Kata_ReversedSequence();

            var actual = target.ReverseSeq(n);

            return actual;
        }
    }
}