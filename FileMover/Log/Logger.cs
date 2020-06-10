using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileMover.Log
{
    public class Logger
    {
        public string FileName { get; }

        public string FilePath { get; }

        public Logger()
        {
            FileName = $"{Guid.NewGuid()}.log";
            FilePath = Path.Combine(Directory.GetCurrentDirectory(),"logs", FileName);
            Directory.CreateDirectory(Path.GetDirectoryName(FilePath));            
        }

        public void Log(string text)
        {
            text = $"{DateTime.Now} : {text}";
            Console.WriteLine(text);
            using (var writer = new StreamWriter(FilePath, true, Encoding.UTF8))
            {
                writer.WriteLine(text);
                writer.Close();
            }
        }
    }
}
