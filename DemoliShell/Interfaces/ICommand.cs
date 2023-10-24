using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoliShell.Interfaces
{
    internal interface ICommand
    {
        public List<string> Parameters { get; set; }

        void Execute();
    }
}
