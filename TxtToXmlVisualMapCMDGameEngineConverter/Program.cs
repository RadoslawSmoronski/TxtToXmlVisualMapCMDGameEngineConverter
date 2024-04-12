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
           
        }

        static void FileHandling(string filePath)
        {

        }
    }
}
