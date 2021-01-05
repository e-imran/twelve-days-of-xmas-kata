using NUnit.Framework;
using NSubstitute;

namespace TwelveDays.Tests
{
    [TestFixture]
    public class TwelveDaysOfChristmasTests
    {
        private ITwelveDaysOfChristmas twelveDaysOfChristmas;
        private IIOHelper helper;

        [SetUp]
        public void Init()
        {
            helper = new IOHelper();
            twelveDaysOfChristmas = new TwelveDaysOfChristmas(helper);
        }
        public const string expectedFirstVerse = "On the first day of Christmas my true love gave to me\r\nA partridge in a pear tree";
        public const string expectedSecondVerse = "On the second day of Christmas my true love gave to me\r\nTwo turtle doves";
        public const string expectedThirdVerse = "On the third day of Christmas my true love gave to me\r\nThree French hens";
        public const string expectedFourthVerse = "On the fourth day of Christmas my true love gave to me\r\nFour calling birds";
        public const string expectedFifthVerse = "On the fifth day of Christmas my true love gave to me\r\nFive GOLDEN rings";
        public const string expectedSixthVerse = "On the sixth day of Christmas my true love gave to me\r\nSix geese a laying";
        public const string expectedSeventhVerse = "On the seventh day of Christmas my true love gave to me\r\nSeven swans a swimming";
        public const string expectedEighthVerse = "On the eighth day of Christmas my true love gave to me\r\nEight maids a milking";
        public const string expectedNinthVerse = "On the ninth day of Christmas my true love gave to me\r\nNine ladies dancing";
        public const string expectedTenthVerse = "On the tenth day of Christmas my true love gave to me\r\nTen lords a leaping";
        public const string expectedEleventhVerse = "On the eleventh day of Christmas my true love gave to me\r\nEleven pipers piping";
        public const string expectedTwelthVerse = "On the twelth day of Christmas my true love gave to me\r\nTwelve drummers drumming";

        [Test]
        public void GivenAnInvalidId_WhenGettingAVerse_ThenReturnErrorMessage()
        {
            var expected = "Index was out of range. Must be non-negative and less than the size of the collection. (Parameter 'index')";

            var actual = twelveDaysOfChristmas.GetVerse(0);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, expectedFirstVerse)]
        [TestCase(2, expectedSecondVerse)]
        [TestCase(3, expectedThirdVerse)]
        [TestCase(4, expectedFourthVerse)]
        [TestCase(5, expectedFifthVerse)]
        [TestCase(6, expectedSixthVerse)]
        [TestCase(7, expectedSeventhVerse)]
        [TestCase(8, expectedEighthVerse)]
        [TestCase(9, expectedNinthVerse)]
        [TestCase(10, expectedTenthVerse)]
        [TestCase(11, expectedEleventhVerse)]
        [TestCase(12, expectedTwelthVerse)]
        public void GivenASpecificId_ReturnCorrelatingVerseOfTwelveDaysOfChristmasSong(int verseNumber, string expected)
        {
            var actual = twelveDaysOfChristmas.GetVerse(verseNumber);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ReturnTwelveDaysOfChristmasSong()
        {
            var ioHelper = Substitute.For<IIOHelper>();
            var logOutputToTextFileMethodWasCalled = false;

            ioHelper
                .When(x => x.LogOutputToTextFile(Arg.Any<string>()))
                .Do(x => logOutputToTextFileMethodWasCalled = true);

            var expected = "On the first day of Christmas my true love gave to me\r\nA partridge in a pear tree\r\n\r\nOn the second day of Christmas my true love gave to me\r\nTwo turtle doves\r\nAnd a partridge in a pear tree\r\n\r\nOn the third day of Christmas my true love gave to me\r\nThree French hens\r\nTwo turtle doves\r\nAnd a partridge in a pear tree\r\n\r\nOn the fourth day of Christmas my true love gave to me\r\nFour calling birds\r\nThree French hens\r\nTwo turtle doves\r\nAnd a partridge in a pear tree\r\n\r\nOn the fifth day of Christmas my true love gave to me\r\nFive GOLDEN rings\r\nFour calling birds\r\nThree French hens\r\nTwo turtle doves\r\nAnd a partridge in a pear tree\r\n\r\nOn the sixth day of Christmas my true love gave to me\r\nSix geese a laying\r\nFive GOLDEN rings\r\nFour calling birds\r\nThree French hens\r\nTwo turtle doves\r\nAnd a partridge in a pear tree\r\n\r\nOn the seventh day of Christmas my true love gave to me\r\nSeven swans a swimming\r\nSix geese a laying\r\nFive GOLDEN rings\r\nFour calling birds\r\nThree French hens\r\nTwo turtle doves\r\nAnd a partridge in a pear tree\r\n\r\nOn the eighth day of Christmas my true love gave to me\r\nEight maids a milking\r\nSeven swans a swimming\r\nSix geese a laying\r\nFive GOLDEN rings\r\nFour calling birds\r\nThree French hens\r\nTwo turtle doves\r\nAnd a partridge in a pear tree\r\n\r\nOn the ninth day of Christmas my true love gave to me\r\nNine ladies dancing\r\nEight maids a milking\r\nSeven swans a swimming\r\nSix geese a laying\r\nFive GOLDEN rings\r\nFour calling birds\r\nThree French hens\r\nTwo turtle doves\r\nAnd a partridge in a pear tree\r\n\r\nOn the tenth day of Christmas my true love gave to me\r\nTen lords a leaping\r\nNine ladies dancing\r\nEight maids a milking\r\nSeven swans a swimming\r\nSix geese a laying\r\nFive GOLDEN rings\r\nFour calling birds\r\nThree French hens\r\nTwo turtle doves\r\nAnd a partridge in a pear tree\r\n\r\nOn the eleventh day of Christmas my true love gave to me\r\nEleven pipers piping\r\nTen lords a leaping\r\nNine ladies dancing\r\nEight maids a milking\r\nSeven swans a swimming\r\nSix geese a laying\r\nFive GOLDEN rings\r\nFour calling birds\r\nThree French hens\r\nTwo turtle doves\r\nAnd a partridge in a pear tree\r\n\r\nOn the twelth day of Christmas my true love gave to me\r\nTwelve drummers drumming\r\nEleven pipers piping\r\nTen lords a leaping\r\nNine ladies dancing\r\nEight maids a milking\r\nSeven swans a swimming\r\nSix geese a laying\r\nFive GOLDEN rings\r\nFour calling birds\r\nThree French hens\r\nTwo turtle doves\r\nAnd a partridge in a pear tree\r\n";

            var actual = new TwelveDaysOfChristmas(ioHelper).GetSong();

            Assert.AreEqual(expected, actual);
            Assert.IsTrue(logOutputToTextFileMethodWasCalled);
        }
    }
}