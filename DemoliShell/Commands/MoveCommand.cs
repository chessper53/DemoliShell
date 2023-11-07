using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using DemoliShell.Interfaces;
using DemoliShell.Filesystem;

namespace DemoliShell.Commands
{
    public class MoveCommand : ICommand
    {
        public CommandContext CommandContext { get; set; } = new CommandContext();

        //Constructor
        public MoveCommand()
        {
            CommandContext.OutputWriter = new CommandOutputWriter();
        }
        public MoveCommand(ICommandOutputWriter commandOutputWriter)
        {
            CommandContext.OutputWriter = commandOutputWriter;
        }



        public void Execute()
        {
            if (CommandContext.Parameters != null && CommandContext.Parameters.Count > 0)
            {
                //Get path of source directory
                string sourcePath = CommandContext.Parameters[0];
                Filesystem.Directory sourceDir = CommandContext.ShellWorkspace.PathHandler.GetDirectory(sourcePath, CommandContext.ShellWorkspace.CurrentDirectory, CommandContext.ShellWorkspace.Drive);

                //Get path of destination directory
                string destinationPath = CommandContext.Parameters[1];
                Filesystem.Directory destinationDir = CommandContext.ShellWorkspace.PathHandler.GetDirectory(destinationPath, CommandContext.ShellWorkspace.CurrentDirectory, CommandContext.ShellWorkspace.Drive);
                Filesystem.Directory destinationDirClone = CommandContext.ShellWorkspace.PathHandler.GetDirectory(destinationPath, CommandContext.ShellWorkspace.CurrentDirectory, CommandContext.ShellWorkspace.Drive).Clone();

                //Check that the destination is not a subfolder of the source
                while (destinationDirClone.ParentDirectory != null)
                {
                    if (destinationDirClone.ParentDirectory == sourceDir)
                    {
                        CommandContext.OutputWriter.WriteLine("Your Destination is a Subfolder of the Sourcepath!");
                        return;
                    }
                    // Move to the next parent directory
                    destinationDirClone = destinationDirClone.ParentDirectory;
                }

                // Delete Old File
                Filesystem.Directory currentDir = CommandContext.ShellWorkspace.CurrentDirectory;
                Filesystem.Directory currentDirClone = currentDir.Clone();
                if (sourceDir != currentDir && destinationDir != currentDir && destinationDir != sourceDir)
                {
                        // Iterate through the FilesystemItems in the ParentDirectory
                        string fileNameToCheck = sourceDir.Name;
                        if (sourceDir.ParentDirectory != null)
                        {
                            foreach (FilesystemItem item in sourceDir.ParentDirectory.FilesystemItems)
                            {
                                if (item.Name == fileNameToCheck)
                                {
                                    // Check if the current Directory is affected
                                    while (currentDirClone.ParentDirectory != null)
                                    {
                                        if (currentDirClone.ParentDirectory.Name == sourceDir.Name)
                                        {
                                            CommandContext.OutputWriter.WriteLine("Your current Directory is affected by this change, you will be relocated to the root Directory!");
                                            sourceDir.ParentDirectory.FilesystemItems.Remove(item);
                                            CommandContext.ShellWorkspace.CurrentDirectory = CommandContext.ShellWorkspace.Drive.RootDirectory;
                                            break;
                                        }
                                        // Move to the next parent directory
                                        currentDirClone = currentDirClone.ParentDirectory;
                                    }

                                    if (currentDirClone.ParentDirectory == null)
                                    {
                                        sourceDir.ParentDirectory.FilesystemItems.Remove(item);
                                    }
                                    break;
                                }
                            }
                        }
                        else
                        {
                            CommandContext.OutputWriter.WriteLine("Your current Directory is affected by this change, you will be relocated to the root Directory!");
                            destinationDir.ParentDirectory.FilesystemItems.Remove(destinationDir);
                            CommandContext.ShellWorkspace.CurrentDirectory = CommandContext.ShellWorkspace.Drive.RootDirectory;
                        }

                    // Change Parent Directory
                    sourceDir.ParentDirectory = destinationDir;

                    // Add to new FilesystemItems
                    destinationDir.FilesystemItems.Add(sourceDir);
                }
            }
            else { CommandContext.OutputWriter.WriteLine("Parameters are null or empty."); }
        }
    }
}
