using CodeWar.Kata;
using NUnit.Framework;

namespace CodeWarTests.Kata
{
    [TestFixture()]
    public class kyu_BandNameGeneratorTests
    {
        [TestCase("knife", ExpectedResult = "The Knife",TestName = "Input \"knife\" should return \"The Knife\"")]
        [TestCase("tart", ExpectedResult = "Tartart", TestName = "Input \"tart\" should return \"Tartart\"")]
        [TestCase("sandles", ExpectedResult = "Sandlesandles", TestName = "Input \"sandles\" should return \"Sandlesandles\"")]
        [TestCase("bed", ExpectedResult = "The Bed", TestName = "Input \"bed\" should return \"The Bed\"")]
        public string BandNameGeneratorTest(string inputName)
        {
            return kyu_BandNameGenerator.BandNameGenerator(inputName);
        }
    }
}
