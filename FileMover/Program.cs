using System;
using System.IO;

namespace FileMover
{
    class Program
    {
        private static string scanDirectory = @"C:\Users\SrinivasRao\Downloads\Temp soft";
        private static string outputDirectory = @"C:\Users\SrinivasRao\Downloads\Outputs";
        private static string[] extensions = new string[] { ".m3u8" };
        private static bool moveFolder = true;

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Starting the file mover");

                Console.WriteLine("Scanning files started");
                foreach (var extension in extensions)
                {
                    var filePaths = Directory.GetFiles(scanDirectory, $"*{extension}*");
                    foreach (var filePath in filePaths)
                    {
                        var fileName = Path.GetFileName(filePath);
                        var outputFilePath = Path.Combine(outputDirectory, fileName);
                        File.Move(filePath, outputFilePath);
                        if (moveFolder)
                        {
                            var fileNameWithContents = $"{fileName}_contents";
                            var sourceFolderPath = Path.Combine(scanDirectory, fileNameWithContents);
                            var outputPath = Path.Combine(outputDirectory, fileNameWithContents);
                            if (Directory.Exists(sourceFolderPath))
                            {
                                Directory.Move(sourceFolderPath, outputPath);
                            }
                        }
                    }
                }

                Console.WriteLine("Completed moving files, press enter to exit");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred in the program : {ex.Message}");
            }
            
        }
    }
}
