using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoliShell.Filesystem;
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
            if (CommandContext.Parameters.Count != 1)
            {
                CommandContext.OutputWriter.WriteLine("Usage: More <FileName>");
                return;
            }

            string fileName = CommandContext.Parameters[0];
            Filesystem.File fileToDisplay = null;

            // Find the file with the given name
            foreach (FilesystemItem item in CommandContext.ShellWorkspace.CurrentDirectory.FilesystemItems)
            {
                if (item.Name == fileName && item is Filesystem.File)
                {
                    fileToDisplay = (Filesystem.File)item;
                    break;
                }
            }

            if (fileToDisplay != null)
            {
                // Display the content of the file
                CommandContext.OutputWriter.WriteLine($"File Content for '{fileName}':");
                CommandContext.OutputWriter.WriteLine(fileToDisplay.FileContent);
            }
            else
            {
                CommandContext.OutputWriter.WriteLine($"File '{fileName}' not found.");
            }
        }
    }
}
