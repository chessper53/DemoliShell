using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoliShell.Filesystem
{
    internal class Directory : FilesystemItem
    {
        public List<FilesystemItem> FilesystemItems { get; set; }
        public Directory() { }
    }
}
