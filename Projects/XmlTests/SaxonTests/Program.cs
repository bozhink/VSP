/// <summary>
/// See http://www.xmlplease.com/saxonaspnet
/// </summary>
namespace SaxonTests
{
    using System;
    using Saxon.Api;

    public class Program
    {
        public static void Main(string[] args)
        {
            ExampleSimple2("c:/temp/test.xml", "c:/temp/test.xsl");
        }

        public static void ExampleSimple1(string sourceUri, string xsltUri)
        {
            // Create a Processor instance.
            Processor processor = new Processor();

            // Load the source document.
            XdmNode input = processor.NewDocumentBuilder().Build(new Uri(sourceUri));

            // Create a transformer for the stylesheet.
            XsltTransformer transformer = processor.NewXsltCompiler().Compile(new Uri(xsltUri)).Load();

            // Set the root node of the source document to be the initial context node.
            transformer.InitialContextNode = input;

            // BaseOutputUri is only necessary for xsl:result-document.
            transformer.BaseOutputUri = new Uri(xsltUri);

            // transformer.SetParameter(new QName("", "", "a-param"), new XdmAtomicValue("hello to you!"));
            // transformer.SetParameter(new QName("", "", "b-param"), new XdmAtomicValue(someVariable));

            // Create a serializer.
            Serializer serializer = new Serializer();
            serializer.SetOutputWriter(Console.Out);

            // Transform the source XML to System.out.
            transformer.Run(serializer);
        }

        public static void ExampleSimple2(string sourceUri, string xsltUri)
        {
            Processor processor = new Processor();

            XdmNode input = processor.NewDocumentBuilder().Build(new Uri(sourceUri));

            XQueryEvaluator transformer = processor.NewXQueryCompiler().Compile("for $x in //product return data($x)").Load();

            transformer.ContextItem = input;

            Serializer serializer = new Serializer();
            serializer.SetOutputWriter(Console.Out);

            transformer.Run(serializer);
        }
    }
}