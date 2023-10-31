using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoliShell.Interfaces;

namespace DemoliShell.Commands
{
    public class MkDirCommand : ICommand
    {
        public List<string> Parameters { get; set; }
        public ICommandOutputWriter OutputWriter { get; set; }

        //Constructor
        public MkDirCommand()
        {
            OutputWriter = new CommandOutputWriter();
        }
        public MkDirCommand(ICommandOutputWriter commandOutputWriter)
        {
            OutputWriter = commandOutputWriter;
        }


        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
