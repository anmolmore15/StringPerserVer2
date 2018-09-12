using StringParserAssignment.Models;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringParserAssignment.Repository
{
    public abstract class Parser
    {
        internal abstract string Parse(string input);

        protected virtual text GetOutPut(string inputText)
        {
            inputText = Regex.Replace(inputText, @"\r\n", " ");
            inputText = Regex.Replace(inputText, @",", " ");

            var setences = inputText.Split(new[] { '.' }).Where(a => !string.IsNullOrWhiteSpace(a)).Select((s) =>
            {
                var words = s.Split(new[] { ' ' }).Where(a => !string.IsNullOrWhiteSpace(a)).OrderBy(o => o).ToArray();

                var sentence = new Sentence { Words = words };
                return sentence;

            }).ToArray();

            var text = new text { Sentences = setences };
            return text;
        }
    }
}
