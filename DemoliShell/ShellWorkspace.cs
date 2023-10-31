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
        private Drive drive;
        private PersistencyService persistencyService;
        private string CurrentDirectory {get;set;}
    }
}
