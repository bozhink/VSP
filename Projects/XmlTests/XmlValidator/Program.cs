namespace XmlValidator
{
    using System;
    using System.Xml;
    using System.Xml.Schema;

    public class Program
    {
        public static void Main()
        {
            ValidateXsd();
        }

        /// <summary>
        /// See https://msdn.microsoft.com/en-us/library/system.xml.xmlnodereader%28v=vs.110%29.aspx
        /// </summary>
        public static void ValidateXsd()
        {
            // Create and load the XML document.
            XmlDocument document = new XmlDocument();
            document.Load("books.xml");

            // Make changes to the document.
            XmlElement book = (XmlElement)document.DocumentElement.FirstChild;
            book.SetAttribute("publisher", "Worldwide Publishing");

            // Create an XmlNodeReader using the XML document.
            XmlNodeReader nodeReader = new XmlNodeReader(document);

            // Set the validation settings on the XmlReaderSettings object.
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.ValidationType = ValidationType.Schema;
            settings.Schemas.Add("urn:bookstore-schema", "books.xsd");
            settings.ValidationEventHandler += new ValidationEventHandler(ValidationCallBack);

            // Create a validating reader that wraps the XmlNodeReader object.
            XmlReader reader = XmlReader.Create(nodeReader, settings);

            // Parse the XML file.
            while (reader.Read())
            {
            }
        }

        /// <summary>
        /// See https://msdn.microsoft.com/library/z2adhb2f%28v=vs.100%29.aspx
        /// </summary>
        public static void ValidateDtd()
        {
            // Set the validation settings.
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.DtdProcessing = DtdProcessing.Parse;
            settings.ValidationType = ValidationType.DTD;
            settings.ValidationEventHandler += new ValidationEventHandler(ValidationCallBack);

            // Create the XmlReader object.
            XmlReader reader = XmlReader.Create("itemDTD.xml", settings);

            // Parse the file.
            while (reader.Read())
            {
            }
        }

        // Display any validation errors.
        private static void ValidationCallBack(object sender, ValidationEventArgs e)
        {
            Console.WriteLine("Validation Error: {0}", e.Message);
        }
    }
}