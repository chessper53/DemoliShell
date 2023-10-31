using DemoliShell.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoliShell
{
    public class CommandContext
    {
        public List<string> Parameters { get; set; }
        public ICommandOutputWriter OutputWriter { get; set; }
        public ShellWorkspace ShellWorkspace { get; set; }

        public CommandContext()
        {
            Parameters = new List<string>();
        }
    }
}
