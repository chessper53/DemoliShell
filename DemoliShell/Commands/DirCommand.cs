using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoliShell.Interfaces;

namespace DemoliShell.Commands
{
    public class DirCommand : ICommand
    {
        public CommandContext CommandContext { get; set; } = new CommandContext();


        //Constructor
        public DirCommand()
        {
            CommandContext.OutputWriter = new CommandOutputWriter();
        }
        public DirCommand(ICommandOutputWriter commandOutputWriter)
        {
            CommandContext.OutputWriter = commandOutputWriter;
        }

        public void Execute()
        {
            foreach (Filesystem.Directory item in CommandContext.ShellWorkspace.CurrentDirectory.FilesystemItems)
            {
                CommandContext.OutputWriter.WriteLine(item.Name);
            }
        }
    }
}
