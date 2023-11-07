using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoliShell.Filesystem;
using DemoliShell.Interfaces;

namespace DemoliShell.Commands
{
    public class DelCommand : ICommand
    {
        public CommandContext CommandContext { get; set; } = new CommandContext();

        //Constructor
        public DelCommand()
        {
            CommandContext.OutputWriter = new CommandOutputWriter();
        }
        public DelCommand(ICommandOutputWriter commandOutputWriter)
        {
            CommandContext.OutputWriter = commandOutputWriter;
        }


        public void Execute()
        {
            if (CommandContext.Parameters != null && CommandContext.Parameters.Count > 0)
            {
                string filepath = CommandContext.Parameters[0];
                Filesystem.Directory currentDir = CommandContext.ShellWorkspace.CurrentDirectory;
                Filesystem.Directory currentDirClone = currentDir.Clone();
                Filesystem.Directory fileDir = CommandContext.ShellWorkspace.PathHandler.GetDirectory(filepath, CommandContext.ShellWorkspace.CurrentDirectory, CommandContext.ShellWorkspace.Drive);
                if (fileDir != currentDir)
                {
                    // Iterate through the FilesystemItems in the ParentDirectory
                    string fileNameToCheck = fileDir.Name;
                    if (fileDir.ParentDirectory != null)
                    {
                        foreach (FilesystemItem item in fileDir.ParentDirectory.FilesystemItems)
                        {
                            if (item.Name == fileNameToCheck)
                            {
                                // Check if the current Directory is affected
                                while (currentDirClone.ParentDirectory != null)
                                {
                                    if (currentDirClone.ParentDirectory.Name == fileDir.Name)
                                    {
                                        CommandContext.OutputWriter.WriteLine("Your current Directory is affected by this change, you will be relocated to the root Directory!");
                                        fileDir.ParentDirectory.FilesystemItems.Remove(item);
                                        CommandContext.ShellWorkspace.CurrentDirectory = CommandContext.ShellWorkspace.Drive.RootDirectory;
                                        break;
                                    }
                                    // Move to the next parent directory
                                    currentDirClone = currentDirClone.ParentDirectory;
                                }

                                if (currentDirClone.ParentDirectory == null)
                                {
                                    fileDir.ParentDirectory.FilesystemItems.Remove(item);
                                    CommandContext.OutputWriter.WriteLine("The File has been deleted!");
                                }
                                break;
                            }
                        }
                    }
                }
                else
                {
                    CommandContext.OutputWriter.WriteLine("Your current Directory is affected by this change, you will be relocated to the root Directory!");
                    fileDir.ParentDirectory.FilesystemItems.Remove(fileDir);
                    CommandContext.ShellWorkspace.CurrentDirectory = CommandContext.ShellWorkspace.Drive.RootDirectory;
                }
            }
            else { CommandContext.OutputWriter.WriteLine("Parameters are null or empty."); }
        }
    }
}
