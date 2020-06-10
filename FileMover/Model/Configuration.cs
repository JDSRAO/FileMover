using System;
using System.Collections.Generic;
using System.Text;

namespace FileMover.Model
{
    public class Configuration
    {
        public string ScanDirectory { get; set; }
        public string OutputDirectory { get; set; }
        public string[] Extensions { get; set; }
        public bool OnlyLog { get; set; }
    }
}
