using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;   
using System.Text;
using System.Threading.Tasks;
using DemoliShell.Interfaces;

namespace DemoliShell.Commands
{
    public class CdCommand : ICommand
    {
        public CommandContext CommandContext { get; set; } = new CommandContext();




        public void Execute()
        {
            if (CommandContext.Parameters != null && CommandContext.Parameters.Count > 0)
            {
                string path = CommandContext.Parameters[0];
                Directory.SetCurrentDirectory(path);
            }
            else { Console.WriteLine("Parameters are null or empty."); }
        }
    }
}