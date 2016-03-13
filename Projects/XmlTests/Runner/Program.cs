namespace Runner
{
    using System;
    using System.Xml;

    using XmlDomManager;

    public class Program
    {
        public static void Main(string[] args)
        {

            if (args.Length < 1)
            {
                Environment.Exit(1);
            }

            string inputFileName = args[0];
            XmlDocument document = new XmlDocument
            {
                PreserveWhitespace = true
            };

            try
            {
                document.Load(inputFileName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Environment.Exit(2);
            }

            var tagger = new XmlTagger();

            tagger.WrapTextInTag(document, "xx", "x");

            Console.WriteLine(document.OuterXml);
        }
    }
}