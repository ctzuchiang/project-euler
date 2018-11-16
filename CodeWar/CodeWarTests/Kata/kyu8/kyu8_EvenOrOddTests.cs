﻿using CodeWar.Kata.kyu8;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWar.Kata.kyu8.Tests
{
    [TestFixture()]
    public class kyu8_EvenOrOddTests
    {
        [TestCase(0, "Even")]
        [TestCase(1, "Odd")]
        [TestCase(2, "Even")]
        [TestCase(7, "Odd")]
        public void EvenOrOddTest(int num, string expected)
        {
            var target = new kyu8_EvenOrOdd();

            var actual = target.EvenOrOdd(num);

            Assert.AreEqual(expected, actual);
        }
    }
}