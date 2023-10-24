using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoliShell.Interfaces;

namespace DemoliShell
{
    internal class CommandFactory
    {
        static List<string> commands;

        public ICommand CreateCommand(Type type)
        {
            return null;
        }
    }
}
