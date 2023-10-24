using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoliShell.Interfaces;

namespace DemoliShell.Commands
{
    internal class SetColorCommand : ICommand
    {
        public List<string> Parameters { get; set; }

        public void Execute()
        {
            Console.WriteLine(Parameters[0]);
            string colorName = Parameters[0];
            ConsoleColor c;
            if (Enum.TryParse(colorName, out c)) ;
            Console.ForegroundColor = c;
        }
    }
}
