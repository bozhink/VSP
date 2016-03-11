using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace XMLTest
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 1) return;
            XmlTextReader r = new XmlTextReader(args[0]);

            r.MoveToElement();
            
        }
    }
}
