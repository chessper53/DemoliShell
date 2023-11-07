using DemoliShell.Filesystem;
using System;
using DemoliShell.Interfaces;
using File = DemoliShell.Filesystem.File;
using System.Text;

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
            newFile.ParentDirectory = CommandContext.ShellWorkspace.CurrentDirectory;
            newFile.FileContent = fileContent;
            newFile.Extension = "txt";
            newFile.Size = GetFileSize(newFile);
            UpdateParentDirectoriesSize(newFile);
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
        public long GetFileSize(File file)
        {
            string contentString = file.FileContent;
            Encoding encoding = Encoding.UTF8;
            byte[] bytes = encoding.GetBytes(contentString);
            long sizeInBytes = bytes.Length;
            return sizeInBytes;
        }
        public void UpdateParentDirectoriesSize(File newFile)
        {
            long fileSize = newFile.Size;

            Filesystem.Directory parentDirectory = newFile.ParentDirectory;

            parentDirectory.Size += fileSize;

            Filesystem.Directory currentDirectory = parentDirectory;
            while (currentDirectory.ParentDirectory != null)
            {
                currentDirectory = currentDirectory.ParentDirectory;
                currentDirectory.Size += fileSize;
            }
            CommandContext.ShellWorkspace.Drive.Size += fileSize;
        }
    }
}
