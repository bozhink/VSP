namespace XmlDomManager
{
    using System.Text;
    using System.Xml;
    using System.Xml.Schema;

    public class XmlTagger
    {
        public void WrapTextInTag(XmlDocument document, string text, string tagName)
        {
            XmlReaderSettings settings = new XmlReaderSettings
            {
                Async = false,
                CheckCharacters = true,
                CloseInput = true,
                DtdProcessing = DtdProcessing.Ignore,
                IgnoreComments = false,
                IgnoreProcessingInstructions = false,
                IgnoreWhitespace = false,
                ValidationType = ValidationType.None,
                ValidationFlags = XmlSchemaValidationFlags.None
            };

            var nodeReader = new XmlNodeReader(document);
            XmlReader reader = XmlReader.Create(nodeReader, settings);
            StringBuilder stringBuilder = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(stringBuilder);

            while (reader.Read())
            {
                writer.WriteNode(reader, true);
            }

            writer.WriteEndDocument();
            writer.Flush();

            document.LoadXml(stringBuilder.ToString());
        }
    }
}