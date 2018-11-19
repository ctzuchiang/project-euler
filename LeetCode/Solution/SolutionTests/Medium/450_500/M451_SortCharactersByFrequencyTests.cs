using NUnit.Framework;
using Solution.Medium._450_500;
using System;
using System.Diagnostics;

namespace SolutionTests.Medium._450_500
{
    [TestFixture()]
    public class M451_SortCharactersByFrequencyTests
    {
        private string _inputStr;
        private string _expected;
        private Stopwatch _stopwatch;

        private delegate void FrequencySortRunner();

        [SetUp]
        public void SetUp()
        {
            _inputStr = "aaaaaaaaaaaaaaabbbbbbbbbbbbbbbbbbbbbccccccccccccccccccddddddddddddddddddd";
            _expected = "bbbbbbbbbbbbbbbbbbbbbdddddddddddddddddddccccccccccccccccccaaaaaaaaaaaaaaa";

            _stopwatch = new Stopwatch();
        }

        [Test]
        public void FrequencySort_Success_Test()
        {
            var target = new M451_SortCharactersByFrequency();

            var actual = target.FrequencySort(_inputStr);

            Assert.AreEqual(_expected, actual);
        }

        [Test]
        public void FrequencySort_Success2_Test()
        {
            var target = new M451_SortCharactersByFrequency();

            var actual = target.FrequencySort2(_inputStr);

            Assert.AreEqual(_expected, actual);
        }

        [Test]
        public void FrequencySort_Time_Runner()
        {
            Timer(FrequencySort_Success_Test);
            Timer(FrequencySort_Success2_Test);
        }

        private void Timer(FrequencySortRunner runner)
        {
            _stopwatch.Restart();
            runner();
            _stopwatch.Stop();
            Console.WriteLine(_stopwatch.Elapsed);
        }
    }
}
