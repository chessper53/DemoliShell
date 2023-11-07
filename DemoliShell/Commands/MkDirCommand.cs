using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoliShell.Filesystem;
using DemoliShell.Interfaces;

namespace DemoliShell.Commands
{
    public class MkDirCommand : ICommand
    {
        public CommandContext CommandContext { get; set; } = new CommandContext();

        //Constructor
        public MkDirCommand()
        {
            CommandContext.OutputWriter = new CommandOutputWriter();
        }
        public MkDirCommand(ICommandOutputWriter commandOutputWriter)
        {
            CommandContext.OutputWriter = commandOutputWriter;
        }

        public void AddFilesystemItem(FilesystemItem item)
        {
            CommandContext.ShellWorkspace.CurrentDirectory.FilesystemItems.Add(item);
        }
        public void MakeDirectory(string directoryName)
        {
            if (string.IsNullOrWhiteSpace(directoryName))
            {
                CommandContext.OutputWriter.WriteLine("Verzeichnisname darf nicht leer sein.");
                return;
            }

            // Prüfen Sie, ob das Verzeichnis bereits existiert
            foreach (FilesystemItem item in CommandContext.ShellWorkspace.CurrentDirectory.FilesystemItems)
            {
                if (item.Name == directoryName && item is Filesystem.Directory)
                {
                    CommandContext.OutputWriter.WriteLine("Das Verzeichnis existiert bereits.");
                    return;
                }
            }

            // Das Verzeichnis erstellen
            Filesystem.Directory newDirectory = new Filesystem.Directory();
            newDirectory.Name = directoryName;
            newDirectory.CreatedOn = DateTime.Now;
            newDirectory.ParentDirectory = CommandContext.ShellWorkspace.CurrentDirectory;
            AddFilesystemItem(newDirectory);
            CommandContext.OutputWriter.WriteLine("Verzeichnis '" + directoryName + "' erstellt.");
        }

        public void Execute()
        {
            string input = CommandContext.Parameters[0];
            MakeDirectory(input);
        }
    }
}