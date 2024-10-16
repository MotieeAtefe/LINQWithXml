using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LINQWithXml
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputFilePath = "input.xml";
            string outputFilePath = "output.xml";
            XElement inputXml = XElement.Load(inputFilePath);

            var modifiedData = from element in inputXml.Elements("Person")
                               where (int)element.Element("Age") > 25
                               select new XElement("ModifiedPerson", new XElement("Name", element.Element("Name").Value), new XElement("Age", (int)element.Element("Age") + 5)
                               );
            XElement outputXml = new XElement("modifiedData", modifiedData);  
            outputXml.Save(outputFilePath);
            Console.WriteLine("Data tranfer LINQ to XML", outputFilePath);

        }
    }
}
