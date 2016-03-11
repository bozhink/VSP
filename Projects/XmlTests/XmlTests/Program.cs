using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace XmlTests
{
    class Program
    {
        private const string filename = "number.xml";
        private const string stylesheet = "calc.xsl";

        static void Main(string[] args)
        {
            {
                XmlDocument xml = new XmlDocument();
                xml.PreserveWhitespace = true;
                Console.WriteLine(">> " + xml.OuterXml);
            }

            {
                // http://stackoverflow.com/questions/1872568/how-to-enable-xslt-scripting-in-c-sharp
                XsltSettings xsltSettings = new XsltSettings();
                xsltSettings.EnableScript = true;

                //Create the XslTransform and load the style sheet.
                XslCompiledTransform xslt = new XslCompiledTransform(true);
                xslt.Load(stylesheet, xsltSettings, new XmlUrlResolver());

                //Load the XML data file.
                XPathDocument doc = new XPathDocument(filename);

                //Create an XmlTextWriter to output to the console.             
                XmlTextWriter writer = new XmlTextWriter(Console.Out);
                writer.Formatting = Formatting.Indented;

                //Transform the file.
                xslt.Transform(doc, null, writer, null);
                writer.Close();
            }

            {
                // http://stackoverflow.com/questions/11772063/alter-xml-file-by-calling-a-c-sharp-function-in-xslt
                XsltArgumentList arguments = new XsltArgumentList();
                arguments.AddExtensionObject("pda:MyUtils", new MyXslExtension());

                using (StreamWriter writer = new StreamWriter("books1.xml"))
                {
                    XslCompiledTransform transform = new XslCompiledTransform();
                    transform.Load("transform.xsl");
                    transform.Transform("books.xml", arguments, writer);
                }
            }
        }
    }
}
