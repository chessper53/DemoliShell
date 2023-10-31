using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoliShell.Interfaces;

namespace DemoliShell.Commands
{
    public class MoreCommand : ICommand
    {
        public List<string> Parameters { get; set; }
        public ICommandOutputWriter OutputWriter { get; set; }

        //Constructor
        public MoreCommand()
        {
            OutputWriter = new CommandOutputWriter();
        }
        public MoreCommand(ICommandOutputWriter commandOutputWriter)
        {
            OutputWriter = commandOutputWriter;
        }


        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
