using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoliShell.Filesystem
{
    internal class Drive
    {
        public string RootDirectory { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public double Size { get; set; }
        public string FilesystemType { get; set; }
        public string DriveType { get; set; }

        public Drive() { }  
    }
}
