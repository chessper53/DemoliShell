using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoliShell.Interfaces;

namespace DemoliShell.Commands
{
    internal class ExitCommand : ICommand
    {
        public void Execute(string[] parameter)
        {
            Environment.Exit(0);
        }

        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
