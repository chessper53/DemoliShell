using DemoliShell.Filesystem;
using System;
using DemoliShell.Interfaces;

namespace DemoliShell.Commands
{
    internal class MoreCommand : ICommand
    {
        public CommandContext CommandContext { get; set; } = new CommandContext();

        // Constructor
        public MoreCommand()
        {
            CommandContext.OutputWriter = new CommandOutputWriter();
        }

        public MoreCommand(ICommandOutputWriter commandOutputWriter)
        {
            CommandContext.OutputWriter = commandOutputWriter;
        }

        public void Execute()
        {
            if (CommandContext.Parameters != null && CommandContext.Parameters.Count > 0)
            {
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
                    // Display the content of the file with pausing for user interaction
                    CommandContext.OutputWriter.WriteLine($"File Content for '{fileName}':");

                    int chunkSize = 50; // Anzahl Zeichen pro Ausgabe-Chunk
                    int currentIndex = 0;

                    while (currentIndex < fileToDisplay.FileContent.Length)
                    {
                        int remainingCharacters = fileToDisplay.FileContent.Length - currentIndex;
                        int charactersToOutput = Math.Min(chunkSize, remainingCharacters);

                        string outputChunk = fileToDisplay.FileContent.Substring(currentIndex, charactersToOutput);
                        currentIndex += charactersToOutput;

                        // Ausgabe des aktuellen Chunks
                        CommandContext.OutputWriter.WriteLine(outputChunk);

                        // Überprüfen, ob der Bildschirm voll ist
                        if (currentIndex < fileToDisplay.FileContent.Length)
                        {
                            CommandContext.OutputWriter.WriteLine("... (Drücken Sie Leerschlag für mehr)");
                            char key = Console.ReadKey().KeyChar;
                            if (key != ' ')
                            {
                                break;
                            }
                        }
                    }
                }
                else
                {
                    CommandContext.OutputWriter.WriteLine($"File '{fileName}' not found.");
                }
            }
            else { CommandContext.OutputWriter.WriteLine("Parameters are null or empty."); }
        }
    }
}