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
            foreach (Filesystem.FilesystemItem item in CommandContext.ShellWorkspace.CurrentDirectory.FilesystemItems)
            {
                ;

                if(item.GetType() == typeof(Filesystem.Directory))
                {
                    CommandContext.OutputWriter.WriteLine(item.Name + "           " + "<dir>" + "           " + item.CreatedOn);
                }
                else if (item.GetType() == typeof(Filesystem.File))
                {
                    CommandContext.OutputWriter.WriteLine(item.Name + "                           " + item.CreatedOn);
                }
            }
        }
    }
}
