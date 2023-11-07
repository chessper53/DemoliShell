using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoliShell.Filesystem
{
    public abstract class FilesystemItem
    {
        public string Name { get; set; }
        public long Size { get; set; }
        public DateTime CreatedOn { get; set; }
        public Directory ParentDirectory { get; set; }
    }
}
