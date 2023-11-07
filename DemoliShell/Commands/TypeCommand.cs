using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            string[] commandParts = CommandContext.Command.Split(' ');
            if (commandParts.Length != 2 || !commandParts[1].ToLower().EndsWith(".txt"))
            {
                CommandContext.OutputWriter.WriteLine("Fehler: Ungültige Eingabe. Bitte geben Sie einen gültigen .txt-Dateipfad an.");
                return;
            }

            string filePath = commandParts[1];
            if (!File.Exists(filePath))
            {
                CommandContext.OutputWriter.WriteLine($"Fehler: Die Datei '{filePath}' existiert nicht.");
                return;
            }

            try
            {
                string fileContent = File.ReadAllText(filePath);
                CommandContext.OutputWriter.WriteLine(fileContent);
            }
            catch (Exception ex)
            {
                CommandContext.OutputWriter.WriteLine($"Fehler: Beim Lesen der Datei ist ein Fehler aufgetreten - {ex.Message}");
            }
        }
    }
}
