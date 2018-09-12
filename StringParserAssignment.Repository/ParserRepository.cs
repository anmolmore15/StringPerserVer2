using System.Collections.Generic;
using System.Linq;

namespace StringParserAssignment.Repository
{
    public class ParserRepository
    {
        static readonly Dictionary<string, Parser> parsers = new Dictionary<string, Parser>() {
            { "Xml", new XmlParser() },
            { "Csv", new CsvParser() }
        };

        public static string[] GetAllParsers()
        {
            return parsers.Keys.ToArray();
        }

        public static Parser GetParser(string parserType)
        {
            return parsers[parserType];
        }

        public static string Parse(Parser parser, string input)
        {
            return parser.Parse(input);
        }
    }
}
