using NUnit.Framework;
using Solution.Easy._051_100;

namespace SolutionTests.Easy._051_100
{
    [TestFixture()]
    public class E67_AddBinaryTests
    {
        private E67_AddBinary _Target;

        [SetUp]
        public void SetUp()
        {
            _Target = new E67_AddBinary();
        }

        [TestCase("0", "0", ExpectedResult = "0")]
        [TestCase("11", "1", ExpectedResult = "100")]
        [TestCase("10100000100100110110010000010101111011011001101110111111111101000000101111001110001111100001101",
            "110101001011101110001111100110001010100001101011101010000011011011001011101111001100000011011110011",
            ExpectedResult = "110111101100010011000101110110100000011101000101011001000011011000001100011110011010010011000000000")]
        public string AddBinaryTests(string binaryStr1, string binaryStr2)
        {
            return _Target.AddBinary(binaryStr1, binaryStr2);
        }
    }
}
