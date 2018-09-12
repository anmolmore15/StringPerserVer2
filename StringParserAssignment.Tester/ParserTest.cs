using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringParserAssignment.Services;

namespace StringParserAssignment.Tester
{
    [TestClass]
    public class ParserTest
    {
        IParserService _parserService;
        public ParserTest(IParserService parserService)
        {
            _parserService = parserService;
        }


        public ParserTest() : this(new ParserService())
        {
        }


        [TestMethod]
        public void ParserTest_GetAllParsers_CheckIfParsersAreEqual()
        {
            var validParsers = new[] { "Xml", "Csv" };

            var storedParsers = _parserService.GetAllParsers();
            Assert.AreEqual(validParsers[0], storedParsers[0]);
            Assert.AreEqual(validParsers[1], storedParsers[1]);
        }

        [TestMethod]
        public void ParserTest_Parse_CheckIfValidXML()
        {
            var validXML = "<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n<SentenceElement>\r\n  <Sentence>\r\n    <Word>a</Word>\r\n    <Word>had</Word>\r\n    <Word>lamb</Word>\r\n    <Word>little</Word>\r\n    <Word>Mary</Word>\r\n  </Sentence>\r\n  <Sentence>\r\n    <Word>Aesop</Word>\r\n    <Word>and</Word>\r\n    <Word>called</Word>\r\n    <Word>came</Word>\r\n    <Word>for</Word>\r\n    <Word>Peter</Word>\r\n    <Word>the</Word>\r\n    <Word>wolf</Word>\r\n  </Sentence>\r\n  <Sentence>\r\n    <Word>Cinderella</Word>\r\n    <Word>likes</Word>\r\n    <Word>shoes</Word>\r\n  </Sentence>\r\n</SentenceElement>";

            var firstSentence = "Mary had a little lamb. Peter called for the wolf, and Aesop came.\r\nCinderella likes shoes.";
            var firstProcessedXML = _parserService.Parse(firstSentence, "Xml");
            Assert.AreEqual(validXML, firstProcessedXML);

            var secondSentence = "    Mary had a little lamb.\r\nPeter called for the wolf, and Aesop came.\r\nCinderella likes shoes.     ";
            var secondProcessedXML = _parserService.Parse(secondSentence, "Xml");
            Assert.AreEqual(validXML, secondProcessedXML);
        }

        [TestMethod]
        public void ParserTest_Parse_CheckIfValidCSV()
        {
            var valid = ", Word 1, Word 2, Word 3, Word 4, Word 5, Word 6, Word 7, Word 8\r\nWordElement 1, a, had, lamb, little, Mary\r\nWordElement 2, Aesop, and, called, came, for, Peter, the, wolf\r\nWordElement 3, Cinderella, likes, shoes\r\n";

            var firstSentence = "Mary had a little lamb. Peter called for the wolf, and Aesop came.\r\nCinderella likes shoes.";
            var firstProcessedCSV = _parserService.Parse(firstSentence, "Csv");
            Assert.AreEqual(valid, firstProcessedCSV);

            var secondSentence = "  Mary had a little lamb.\r\nPeter called for the wolf, and Aesop came.\r\nCinderella likes shoes.    ";
            var secondProcessedCSV = _parserService.Parse(secondSentence, "Csv");
            Assert.AreEqual(valid, secondProcessedCSV);
        }
    }
}
