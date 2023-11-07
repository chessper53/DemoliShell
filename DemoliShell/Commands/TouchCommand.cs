using DemoliShell.Filesystem;
using System;
using DemoliShell.Interfaces;
using File = DemoliShell.Filesystem.File;

namespace DemoliShell.Commands
{
    internal class TouchCommand : ICommand
    {
        public CommandContext CommandContext { get; set; } = new CommandContext();

        //Constructor
        public TouchCommand()
        {
            CommandContext.OutputWriter = new CommandOutputWriter();
        }
        public TouchCommand(ICommandOutputWriter commandOutputWriter)
        {
            CommandContext.OutputWriter = commandOutputWriter;
        }

        public void AddFilesystemItem(FilesystemItem item)
        {
            CommandContext.ShellWorkspace.CurrentDirectory.FilesystemItems.Add(item);
        }

        public void MakeFile(string fileName, string fileContent)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                CommandContext.OutputWriter.WriteLine("Filename darf nicht leer sein.");
                return;
            }

            // Prüfen Sie, ob das File bereits existiert
            foreach (FilesystemItem item in CommandContext.ShellWorkspace.CurrentDirectory.FilesystemItems)
            {
                if (item.Name == fileName && item is Filesystem.File)
                {
                    CommandContext.OutputWriter.WriteLine("Das File existiert bereits.");
                    return;
                }
            }

            // Das File erstellen
            File newFile = new File();
            newFile.Name = fileName;
            newFile.CreatedOn = DateTime.Now;
            newFile.ParentDirectory = CommandContext.CurrentDirectory;


            CommandContext.Parameters.RemoveAt(0);
            newFile.FileContent = String.Join(" ", CommandContext.Parameters);
            newFile.FileContent = newFile.FileContent.Replace("\\n", Environment.NewLine);
            newFile.Extension = "txt";
            AddFilesystemItem(newFile);
            CommandContext.OutputWriter.WriteLine("File '" + fileName + "' erstellt.");

        }

        public void Execute()
        {
            if (CommandContext.Parameters.Count < 2)
            {
                CommandContext.OutputWriter.WriteLine("Usage: Touch <FileName> <FileContent>");
                return;
            }

            string fileName = CommandContext.Parameters[0];
            string fileContent = CommandContext.Parameters[1];
            MakeFile(fileName, fileContent);
        }
    }
}
