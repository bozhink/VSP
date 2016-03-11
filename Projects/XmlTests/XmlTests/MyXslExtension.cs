using System.Xml;

namespace XmlTests
{
    public class MyXslExtension
    {
        public string FormatName(string name)
        {
            return "Mr. " + name;
        }

        public XmlNode CreateNode(string name)
        {
            XmlDocument xml = new XmlDocument();
            XmlDocumentFragment fragment = xml.CreateDocumentFragment();
            fragment.InnerXml = "x1 <strong>" + name + "</strong>";
            return fragment;
        }
    }
}
