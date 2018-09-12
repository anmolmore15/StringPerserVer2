using System.Xml.Serialization;

namespace StringParserAssignment.Models
{
    public class Sentence
    {
        [XmlElement("Word")]
        public string[] Words { get; set; }
    }
}
