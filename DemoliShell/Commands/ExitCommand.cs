using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoliShell.Interfaces;

namespace DemoliShell.Commands
{
    public class ExitCommand : ICommand
    {
        public List<string> Parameters { get; set; }
        public ICommandOutputWriter OutputWriter { get; set; }

        //Constructor
        public ExitCommand()
        {
            OutputWriter = new CommandOutputWriter();
        }
        public ExitCommand(ICommandOutputWriter commandOutputWriter)
        {
            OutputWriter = commandOutputWriter;
        }


        public void Execute()
        {
            Environment.Exit(0);
        }
    }
}
