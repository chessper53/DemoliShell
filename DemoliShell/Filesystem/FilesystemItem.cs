using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoliShell.Filesystem
{
    abstract class FilesystemItem
    {
        public string Name { get; set; }
        public double Size { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
