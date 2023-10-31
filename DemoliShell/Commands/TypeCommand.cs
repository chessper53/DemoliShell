using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoliShell.Interfaces;

namespace DemoliShell.Commands
{
    public class TypeCommand : ICommand
    {
        public CommandContext CommandContext { get; set; } = new CommandContext();

        //Constructor
        public TypeCommand()
        {
            CommandContext.OutputWriter = new CommandOutputWriter();
        }
        public TypeCommand(ICommandOutputWriter commandOutputWriter)
        {
            CommandContext.OutputWriter = commandOutputWriter;
        }


        public void Execute()
        {
            //CommandContext.OutputWriter.WriteLine(CommandContext.ShellWorkspace.GetFullPath());
            //throw new NotImplementedException();
        }
    }
}
