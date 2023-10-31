using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoliShell.Interfaces;

namespace DemoliShell.Commands
{
    public class RenCommand : ICommand
    {
        public List<string> Parameters { get; set; }
        public ICommandOutputWriter OutputWriter { get; set; }

        //Constructor
        public RenCommand()
        {
            OutputWriter = new CommandOutputWriter();
        }
        public RenCommand(ICommandOutputWriter commandOutputWriter)
        {
            OutputWriter = commandOutputWriter;
        }


        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
