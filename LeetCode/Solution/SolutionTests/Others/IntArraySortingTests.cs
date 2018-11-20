using NUnit.Framework;
using Solution.Others;
using System;
using System.Diagnostics;

namespace SolutionTests.Others
{
    [TestFixture()]
    public class IntArraySortingTests
    {
        private int[] _testData;
        private int[] _expectedData;
        private Stopwatch _stopwatch;

        private delegate void IntArraySortingRunner();

        [SetUp]
        public void SetUp()
        {
            _testData = new int[]
            {
                28,48,72,11,18,34,33,46,40, 2,
                62,87,84,59,72,61,95,39,38,80,
                74,25,10,61,78,92,32,60,45,81,
                18,20,68,32,53,81,39,21,71,81,
                11,99,96,42,45,16,98,62,56,64,
                31, 4,96,62,41,95, 2,21,63,81,
                 1,91,92,99,28,90,19,87,18,67,
                91,65,89,17,13, 7,21,59,71, 3,
                69,43,98,64,86,84,75,35,23,28,
                13,21, 8,79,49,63,28,98,22,66
            };

            _expectedData = new int[]
            {
                 1, 2, 2, 3, 4, 7, 8,10,11,11,
                13,13,16,17,18,18,18,19,20,21,
                21,21,21,22,23,25,28,28,28,28,
                31,32,32,33,34,35,38,39,39,40,
                41,42,43,45,45,46,48,49,53,56,
                59,59,60,61,61,62,62,62,63,63,
                64,64,65,66,67,68,69,71,71,72,
                72,74,75,78,79,80,81,81,81,81,
                84,84,86,87,87,89,90,91,91,92,
                92,95,95,96,96,98,98,98,99,99
            };

            _stopwatch = new Stopwatch();
        }

        [Test]
        public void ForLoopSorting_Success_Test()
        {
            var target = new IntArraySorting();

            var actual = target.ForLoopSorting(_testData);

            Assert.AreEqual(_expectedData, actual);
        }

        [Test]
        public void BucketSorting_Success_Test()
        {
            var target = new IntArraySorting();

            var actual = target.BucketSorting(_testData);

            Assert.AreEqual(_expectedData, actual);
        }

        [Test]
        public void QuickSorting_Success_Test()
        {
            var target = new IntArraySorting();

            var actual = target.QuickSorting(_testData);

            Assert.AreEqual(_expectedData, actual);
        }

        [Test]
        public void ForLoopSorting_Time_Runner()
        {
            Timer(ForLoopSorting_Success_Test);
            Timer(BucketSorting_Success_Test);
            Timer(QuickSorting_Success_Test);
        }

        private void Timer(IntArraySortingRunner runner)
        {
            _stopwatch.Restart();
            runner();
            _stopwatch.Stop();
            Console.WriteLine($"{runner.Method.Name.PadLeft(30)}: {_stopwatch.Elapsed}");
        }
    }
}