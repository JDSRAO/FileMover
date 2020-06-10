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
            File.Create(FilePath);
        }

        public void Log(string text)
        {
            text = $"{DateTime.Now} : {text}";
            File.AppendAllText(FilePath, text, Encoding.UTF8);
        }

    }
}
