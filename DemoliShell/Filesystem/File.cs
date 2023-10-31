using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoliShell.Filesystem
{
    internal class File : FilesystemItem
    {
        public string FileContent { get; set; }
        public File() { }
    }
}
