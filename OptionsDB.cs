using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Calculate_Conversions
{

    public class OptionsDB
    {

        // defines the path for the Options.xml file
        private const string path = @"E:\CGTC\C# Programming II Summer 2017\Project\Files\Options.xml";

        public static List<Options> GetConversions()
        {
            // create the list
            List<Options> options = new List<Options>();

            // create the XmlReaderSettings object
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreWhitespace = true;
            settings.IgnoreComments = true;

            // create the XmlReader object
            XmlReader xmlIn = XmlReader.Create(path, settings);

            // read past all nodes to the first Conversion node
            xmlIn.ReadToDescendant("Conversion");

            // create one Conversion object for each Conversion node
            do
            {
                Options o = new Options();
                xmlIn.ReadStartElement("Conversion");
                o.From = xmlIn.ReadElementContentAsString();
                o.To = xmlIn.ReadElementContentAsString();
                o.ConNum = xmlIn.ReadElementContentAsDecimal();
                options.Add(o);
            }
            while (xmlIn.ReadToNextSibling("Conversion"));


            xmlIn.Close();

            return options;
        }

        public static void SaveConversions(List<Options> options)
        {

            // creates the XmlWriterSettings object
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = ("     ");

            // create the XmlWriter object
            XmlWriter xmlOut = XmlWriter.Create(path, settings);

            // write the start of the element
            xmlOut.WriteStartDocument();
            xmlOut.WriteStartElement("Conversions");

            // write each Conversion object to the xml file
            foreach (Options o in options)
            {
                xmlOut.WriteStartElement("Conversion");
                xmlOut.WriteElementString("From", o.From);
                xmlOut.WriteElementString("To", o.To);
                xmlOut.WriteElementString("ConNum", 
                    Convert.ToString(o.ConNum));
                xmlOut.WriteEndElement();
            }

            // write the end tag for the root element
            xmlOut.WriteEndElement();

            // close the XmlWriter object
            xmlOut.Close();
        }    
    }
}
