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

            bool changed = false;

            oldName = CommandContext.Parameters[0];
            newName = CommandContext.Parameters[1];

            foreach (Filesystem.Directory item in CommandContext.ShellWorkspace.CurrentDirectory.FilesystemItems)
            {
                if (item.Name.Equals(oldName))
                {
                    string newFullName = newName;

                    // If the new name already exists, append an index number
                    int index = 1;
                    while (CommandContext.ShellWorkspace.CurrentDirectory.FilesystemItems.Any(x => x.Name.Equals(newFullName)))
                    {
                        newFullName = newName + "_" + index;
                        index++;
                    }

                    try
                    {
                        // Rename the file or folder to the new name
                        item.Name = newFullName; // Aktualisieren Sie den Namen im Verzeichnis
                        CommandContext.OutputWriter.WriteLine($"Renamed to {newFullName}");
                        changed = true;
                        break;
                    }
                    catch (Exception ex)
                    {
                        CommandContext.OutputWriter.WriteLine($"Error renaming: {ex.Message}");
                    }
                }
            }

            if (!changed)
            {
                CommandContext.OutputWriter.WriteLine("File or folder " + oldName + " does not exist.");
            }
        }
    }
}