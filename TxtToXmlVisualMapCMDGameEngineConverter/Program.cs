using System.IO;

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

            }
            finally
            {
                Console.WriteLine("\ntxtPath.xml was created succesfully!");
            }

        }

        static void Convert(string? filePath)
        {
            string [] lines = GetLinesFromTxt(filePath);

            Dictionary<int, Dictionary<int, char>> charsDictionary = GetDictionaryWithChars(lines);

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

        static Dictionary<int, Dictionary<int, char>> GetDictionaryWithChars(string[] lines)
        {
            Dictionary<int, Dictionary<int, char>> dictionary = new Dictionary<int, Dictionary<int, char>>();

            int y = 0;

            foreach (string line in lines)
            {
                int x = 0;

                foreach (char c in line)
                {
                    if (c != ' ')
                    {
                        dictionary[x][y] = c;
                    }

                    x++;
                }

                y++;
            }

            return dictionary;
        }

        static void WriteFileFromCharsDictionary(Dictionary<int, Dictionary<int, char>> charsDictionary)
        {

        }
    }
}
