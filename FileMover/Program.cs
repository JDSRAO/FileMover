using FileMover.Log;
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
        private static bool onlyLog = true;
        private static Logger logger = new Logger();

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Scanning files started");
                logger.Log("Scanning files started");
                foreach (var extension in extensions)
                {
                    var filePaths = Directory.GetFiles(scanDirectory, $"*{extension}*");
                    logger.Log($"\t Found below files with {extension} extension");
                    foreach (var filePath in filePaths)
                    {
                        logger.Log($"\t \t Moving file : {filePath}");
                        var fileName = Path.GetFileName(filePath);
                        var outputFilePath = Path.Combine(outputDirectory, fileName);
                        if(!onlyLog)
                        {
                            File.Move(filePath, outputFilePath);
                        }
                        if (moveFolder)
                        {
                            var fileNameWithContents = $"{fileName}_contents";
                            var sourceFolderPath = Path.Combine(scanDirectory, fileNameWithContents);
                            var outputPath = Path.Combine(outputDirectory, fileNameWithContents);
                            if (Directory.Exists(sourceFolderPath))
                            {
                                logger.Log($"\t \t Moving folder : {sourceFolderPath}");
                                if (!onlyLog)
                                {
                                    Directory.Move(sourceFolderPath, outputPath);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var message = $"Error occurred in the program : {ex.Message}";
                Console.WriteLine(message);
                logger.Log(message);
            }

            Console.WriteLine("Completed moving files, press enter to exit");
            logger.Log("Completed moving files, press enter to exit");
            Console.ReadLine();

        }
    }
}
