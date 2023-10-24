using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoliShell.Interfaces;

namespace DemoliShell.Commands
{
    internal class SetColor : ICommand
    {
        public void Execute()
        {

            string colorName = Console.ReadLine();
            ConsoleColor c;
            if (Enum.TryParse(colorName, out c)) ;
            Console.ForegroundColor = c;


            throw new NotImplementedException();
        }
    }
}
