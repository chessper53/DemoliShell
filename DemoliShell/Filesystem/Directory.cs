using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoliShell.Filesystem
{
    public class Directory : FilesystemItem
    {
        public List<FilesystemItem> FilesystemItems { get; set; } = new List<FilesystemItem> { };

        public Directory() { }
        public Directory(Directory parentDirectory)
        {
            ParentDirectory = parentDirectory;
        }

        public Directory(List<FilesystemItem> fileSystemItems, string name, DateTime createdOn)
        {
            FilesystemItems = fileSystemItems;
            Name = name;
            CreatedOn = createdOn;
        }

        public Directory Clone() { return (Directory)this.MemberwiseClone(); }

    }
}
