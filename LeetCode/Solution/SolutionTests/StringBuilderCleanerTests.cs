using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solution;
using System;
using System.Diagnostics;

namespace SolutionTests
{
    [Ignore]
    [TestClass]
    public class StringBuilderCleanerTests
    {
        private Stopwatch _Stopwatch;
        private StringBuilderCleaner _Target;

        private delegate void StringBulderRunner();

        [TestInitialize]
        public void SetUp()
        {
            _Stopwatch = new Stopwatch();

            var loopCount = 10;
            var appendString = @"ABCDEFGHIJKLMNOPQRSTUVWXYZ
                                 ABCDEFGHIJKLMNOPQRSTUVWXYZ
                                 ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            _Target = new StringBuilderCleaner(loopCount, appendString);
        }

        [TestMethod]
        public void StringBuilder_Performance_Test()
        {
            Timer(_Target.StringBuilder_Clear);
            Timer(_Target.StringBuilder_Remove);
            Timer(_Target.StringBuilder_Replace);
            Timer(_Target.StringBuilder_Length_0);
        }

        private void Timer(StringBulderRunner runner)
        {
            _Stopwatch.Restart();
            runner();
            _Stopwatch.Stop();
            Console.WriteLine(_Stopwatch.Elapsed);
        }
    }
}