using System.IO;
using System.Xml;

namespace TxtToXmlVisualMapCMDGameEngineConverter
{
    internal class Program
    {
        static string version = "1.0.0";

        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("  Error: No command given.");
                return;
            }

            switch(args[0])
            {
                case "convert":
                    if(args.Length > 1)
                    {
                        Convert(args[1]);
                    }
                    break;
                case "help":
                    Console.WriteLine(
                        "\n  Help - Txt To Xml VisualMap CMDGameEngine Converter\n" +
                        "   convert <filePath> - convertion txt file to VisualMap xml file\n" +
                        "   version - version of program\n");
                    break;
                case "version":
                    Console.WriteLine(
                        $"\n  Txt To Xml VisualMap CMDGameEngine Converter" +
                        $"\n  ver. {version}");
                    break;
                default:
                    Console.WriteLine("  Error: this command doesn't exist, check help.");
                    break;
            }

        }

        static void Convert(string? filePath)
        {
            try
            {
                string[] lines = GetLinesFromTxt(filePath);
                List<VisualElement> visualElements = GetVisualElementsFromTxtLines(lines);
                WriteXMLFile(visualElements);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            finally
            {
                Console.WriteLine("\nConverted file was created succesfully!");
            }

        }

        static string[] GetLinesFromTxt(string? filePath)
        {

            if (filePath == null)
            {
                throw new NullReferenceException("filePath is null");
            }
           
            try
            {
                return File.ReadAllLines(filePath);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        static List<VisualElement> GetVisualElementsFromTxtLines(string[] lines)
        {
            List <VisualElement> visualElements = new List<VisualElement> ();

            int y = 0;

            foreach (string line in lines)
            {
                int x = 0;

                foreach (char sign in line)
                {
                    if (sign != ' ')
                    {
                        visualElements.Add(new VisualElement(x, y, sign));
                    }

                    x++;
                }

                y++;
            }

            return visualElements;
        }

        static void WriteXMLFile(List<VisualElement> visualElements)
        {
            XmlDocument doc = new XmlDocument();
            XmlElement root = doc.CreateElement("objectVisualMap");
            doc.AppendChild(root);


            foreach (VisualElement visualElement in visualElements)
            {
                XmlElement element = doc.CreateElement("element");
                element.SetAttribute("x", visualElement.X.ToString());
                element.SetAttribute("y", visualElement.Y.ToString());
                element.SetAttribute("sign", visualElement.Sign.ToString());
                root.AppendChild(element);
            }


            string filePathName = "convertedTxt";
            string filePath = "convertedTxt.xml";

            int x = 2;

            while(true)
            {
                if (File.Exists(filePath))
                    filePath = filePathName + $"({x})" + ".xml";
                else
                    break;

                x++;
            }

            using (XmlWriter writer = XmlWriter.Create(filePath, new XmlWriterSettings { Indent = true }))
            {
                doc.Save(writer);
            }
        }
    }
}
