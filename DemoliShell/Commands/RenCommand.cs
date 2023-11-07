using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using DemoliShell.Interfaces;

namespace DemoliShell.Commands
{
    public class RenCommand : ICommand
    {
        public CommandContext CommandContext { get; set; } = new CommandContext();

        //Constructor
        public RenCommand()
        {
            CommandContext.OutputWriter = new CommandOutputWriter();
        }
        public RenCommand(ICommandOutputWriter commandOutputWriter)
        {
            CommandContext.OutputWriter = commandOutputWriter;
        }


        public void Execute()
        {
            

            if (CommandContext.Parameters.Count != 2)
            {
                CommandContext.OutputWriter.WriteLine("Usage: Ren <oldName> <newName>");
                return;
            }

            string oldName;
            string newName;

            oldName = CommandContext.Parameters[0];
            newName = CommandContext.Parameters[1];

            foreach (Filesystem.Directory item in CommandContext.ShellWorkspace.CurrentDirectory.FilesystemItems)
            {
                if (item.Name.Equals(oldName))
                {
                    int index = 1;
                    string newFullName = newName;

                    // If the new name already exists, append an index number
                    while (CommandContext.ShellWorkspace.CurrentDirectory.FilesystemItems.Any(x => x.Name.Equals(newFullName)))
                    {
                        index++;
                    }

                    try
                    {
                        // Rename the file or folder to the new name
                        item.Name = newFullName + "_" + index; // Aktualisieren Sie den Namen im Verzeichnis
                        CommandContext.OutputWriter.WriteLine($"Renamed to {newFullName}");
                    }
                    catch (Exception ex)
                    {
                        CommandContext.OutputWriter.WriteLine($"Error renaming: {ex.Message}");
                    }
                }
                else
                {
                    CommandContext.OutputWriter.WriteLine("File or folder " + oldName + " does not exist.");
                }
            }
        }
    }
}
