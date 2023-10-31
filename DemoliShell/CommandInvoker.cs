using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoliShell.Commands;
using DemoliShell.Interfaces;

namespace DemoliShell
{
    internal class CommandInvoker
    {
        public void ExecuteCommand(Type type, List<string> parameters)
        {
            try
            {
                ICommand command = CommandFactory.CreateCommand(type);
                command.Parameters = parameters;
                command.Execute();
            }
            catch (Exception ex)
            {   
                Console.WriteLine(ex.Message);
            }
        }
    }
}
