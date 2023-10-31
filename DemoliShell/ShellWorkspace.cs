using DemoliShell.Filesystem;
using DemoliShell.Persistency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoliShell
{
    internal class ShellWorkspace
    {
        public Drive Drive { get; set; }
        private PersistencyService persistencyService;
        public Filesystem.Directory CurrentDirectory {get;set;}
        public PathHandler PathHandler { get;set;}

        public ShellWorkspace()
        {
            PathHandler = new PathHandler();
        }
    }
}
