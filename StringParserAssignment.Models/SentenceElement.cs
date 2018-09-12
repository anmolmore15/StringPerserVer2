using System.Xml.Serialization;

namespace StringParserAssignment.Models
{
    public class text
    {
        [XmlElement("Sentence")]
        public Sentence[] Sentences { get; set; }
    }
}
