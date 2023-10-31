    using DemoliShell.Filesystem;
using DemoliShell.Persistency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoliShell
{
    public class ShellWorkspace
    {
        public Drive Drive { get; set; }
        public Filesystem.Directory CurrentDirectory {get;set;}
        public PathHandler PathHandler { get;set;}

        public ShellWorkspace()
        {
            PathHandler = new PathHandler();
            Drive = PersistencyService.Load();
            CurrentDirectory = Drive.RootDirectory;
        }
        public string GetFullPath()
        {
            return PathHandler.GetFullPath(CurrentDirectory, Drive);
        }
    }
}
