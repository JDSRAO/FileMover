using System;
using System.IO;

namespace FileMover
{
    class Program
    {
        private static string scanDirectory = "";
        private static string outputDirectory = "";
        private static string[] extensions = new string[] { "m3u8" };

        static void Main(string[] args)
        {
            Console.WriteLine("Starting the file mover");

            foreach (var extension in extensions)
            {
                var filePaths = Directory.GetFiles(scanDirectory, extension);
                foreach (var filePath in filePaths)
                {
                    var fileName = Path.GetFileName(filePath);
                    var outputFilePath = Path.Combine(outputDirectory, fileName);
                    File.Move(filePath, outputFilePath);
                }
            }
        }
    }
}
