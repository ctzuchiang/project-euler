using CodeWar.Kata.kyu8;
using NUnit.Framework;

namespace CodeWarTests.Kata.kyu8
{
    [TestFixture()]
    public class kyu8_ReversedSequenceTests
    {
        [TestCase(1, ExpectedResult = new[] { 1 })]
        [TestCase(3, ExpectedResult = new[] { 3, 2, 1 })]
        [TestCase(5, ExpectedResult = new[] { 5, 4, 3, 2, 1 })]
        public int[] ReverseSeqTest(int n)
        {
            var target = new kyu8_ReversedSequence();

            var actual = target.ReverseSeq(n);

            return actual;
        }
    }
}