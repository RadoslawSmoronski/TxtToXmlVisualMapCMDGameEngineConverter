using System.IO;
using System.Xml;

namespace TxtToXmlVisualMapCMDGameEngineConverter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Txt to XML VisualMap converter\nfor CMDGameEngine\n\n");
            Console.Write("File path to file to convert: ");

            string txtPath = Console.ReadLine();

            try
            {
                Convert(txtPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("\ntxtPath.xml was created succesfully!");
            }

        }

        static void Convert(string? filePath)
        {
            string [] lines = GetLinesFromTxt(filePath);

            List <VisualElement> visualElements = GetVisualElementsFromTxtLines(lines);

            WriteFileFromCharsDictionary(charsDictionary);

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
                    if (c != ' ')
                    {
                        visualElements.Add(new VisualElement(x, y, sign));
                    }

                    x++;
                }

                y++;
            }

            return dictionary;
        }

        static void WriteFileFromCharsDictionary(Dictionary<int, Dictionary<int, char>> charsDictionary)
        {
            XmlDocument doc = new XmlDocument();
            XmlElement root = doc.CreateElement("objectVisualMap");
            doc.AppendChild(root);

            foreach (var outerPair in charsDictionary)
            {
                int x = outerPair.Key;

                XmlElement element = doc.CreateElement("element");
                element.SetAttribute("x", x.ToString());


                Dictionary<int, char> innerDictionary = outerPair.Value;
                foreach (var innerPair in innerDictionary)
                {
                    int y = innerPair.Key;
                    char value = innerPair.Value;

                    element.SetAttribute("y", y.ToString());
                    element.SetAttribute("sign", value.ToString());
                    root.AppendChild(element);
                }
            }

            string filePath = "file.xml";

            using (XmlWriter writer = XmlWriter.Create(filePath, new XmlWriterSettings { Indent = true }))
            {
                doc.Save(writer);
            }
        }
    }
}
