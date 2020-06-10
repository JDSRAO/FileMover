using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileMover.Model
{
    public class Configuration
    {
        public string ScanDirectory { get; set; }
        public string OutputDirectory { get; set; }
        public bool MoveFolder { get; set; }
        public string[] Extensions { get; set; }
        public bool OnlyLog { get; set; }

        public static Configuration GetConfiguration()
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "config.json");
            var configText = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<Configuration>(configText);
        }
    }
}
