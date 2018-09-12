using System.IO;
using System.Xml.Serialization;
using System.Text;
using System.Xml;

namespace StringParserAssignment.Repository
{
    public sealed class Utf8StringWriter : StringWriter
    {
        public override Encoding Encoding { get { return Encoding.UTF8; } }
    }

    internal class XmlParser : Parser
    {
        internal override string Parse(string input)
        {
            string result = string.Empty;
            XmlSerializer xmlSerializer;
            StringWriter stringWriter;

           

            try
            {
                var text = base.GetOutPut(input);

                var sw = new Utf8StringWriter();
                var xmlWriter = XmlWriter.Create(sw, new XmlWriterSettings { Indent = true });
                xmlWriter.WriteStartDocument(true);

                var ns = new XmlSerializerNamespaces();
                ns.Add(string.Empty, string.Empty);                

                xmlSerializer = new XmlSerializer(text.GetType());
                //stringWriter = new StringWriter();


                //xmlSerializer.Serialize(stringWriter, text, ns);

                xmlSerializer.Serialize(xmlWriter, text, ns);

                result = sw.ToString();
            }
            finally
            {
                xmlSerializer = null;
                stringWriter = null;
            }
            return result;
        }
    }
}
