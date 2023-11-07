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
            long fullDirSize = 0;
            long fullFileSize = 0;
            int DirCounter = 0;
            int FileCounter = 0;

            CommandContext.OutputWriter.WriteLine("Volume in " + CommandContext.ShellWorkspace.Drive.Name + " is " + CommandContext.ShellWorkspace.Drive.Label);
            CommandContext.OutputWriter.WriteLine("Type: " + CommandContext.ShellWorkspace.Drive.DriveType);
            CommandContext.OutputWriter.WriteLine("\nDirectory of " + CommandContext.ShellWorkspace.CurrentDirectory.Name + "\n");

            foreach (Filesystem.FilesystemItem item in CommandContext.ShellWorkspace.CurrentDirectory.FilesystemItems)
            {
                string itemType = item.GetType() == typeof(Filesystem.Directory) ? "<dir>" : item.Size.ToString();
                string formattedOutput = $"{item.CreatedOn,-30} {itemType,-10} {item.Name,-20}";
                CommandContext.OutputWriter.WriteLine(formattedOutput);

                if (item is Filesystem.Directory)
                {
                    fullDirSize += item.Size;
                    DirCounter ++;
                }
                else
                {
                    fullFileSize += item.Size;
                    FileCounter++;
                }
            }
            string fileOutput = $"{FileCounter +" File(s) ",45} {fullFileSize + " bytes used",10}";
            string dirOutput = $"{DirCounter + " Dir(s) ",45} {fullDirSize + " bytes used",10}";

            CommandContext.OutputWriter.WriteLine(fileOutput);
            CommandContext.OutputWriter.WriteLine(dirOutput);
        }
    }
}
