using System.Text;

namespace StringParserAssignment.Repository
{
    internal class CsvParser : Parser
    {
        internal override string Parse(string input)
        {
            var text = base.GetOutPut(input);

            var maxWord = 0;
            var sentenceCounter = 0;
            StringBuilder csvDataSB = new StringBuilder();
            foreach (var sentence in text.Sentences)
            {
                if (sentence.Words.Length > maxWord)
                    maxWord = sentence.Words.Length;
                sentenceCounter ++;
                csvDataSB.AppendFormat("{0} {1}", sentence.GetType().Name, sentenceCounter);
                foreach (var word in sentence.Words)
                {
                    csvDataSB.AppendFormat(", {0}", word);
                }
                csvDataSB.AppendLine();
            }

            var result = new StringBuilder();
            for(int w = 1; w<= maxWord; w++)
            {
                result.AppendFormat(", Word {0}", w);
            }
            result.AppendLine();
            result.Append(csvDataSB.ToString());

            return result.ToString();
        }
    }
}
