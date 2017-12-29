using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate_Conversions
{
    public class ConversionDB
    {
        private const string dir = @"E:\CGTC\C# Programming II Summer 2017\Project\Files\";
        private const string path = dir + "Conversions.txt";
        private const string path2 = dir + "ConversionsDefault.txt";

        public static List<Conversions> GetConversions()
        {
            // if the directory doesn't exist, create it
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            //creates an object to read input from a text file
            StreamReader textIn = 
                new StreamReader(
                new FileStream(path2, FileMode.OpenOrCreate, FileAccess.Read));

            //creates an array list for conversions
            List<Conversions> conversions = new List<Conversions>();

            // read the data from 
            while (textIn.Peek() != -1)
            {
                string row = textIn.ReadLine();
                string[] columns = row.Split('|');
                Conversions conversion = new Conversions();     //creates an object of the Conversions class
                conversion.From = columns[0];
                conversion.To = columns[1];
                conversion.ConNum = Convert.ToDecimal(columns[2]);
                conversions.Add(conversion);
            }
            textIn.Close();

            return conversions;
        }

        public static void SaveConversions(List<Conversions> conversions)
        {
            StreamWriter textOut =
                new StreamWriter(
                new FileStream(path, FileMode.Create, FileAccess.Write));

            foreach (Conversions conversion in conversions)
            {
                textOut.Write(conversion.From + "|");
                textOut.Write(conversion.To + "|");
                textOut.WriteLine(conversion.ConNum);
            }
            textOut.Close();
        }
    }
}
