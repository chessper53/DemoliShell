using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoliShell.Interfaces;
using NUnitLite;

namespace DemoliShell.Commands
{
    public class DelCommand : ICommand
    {
        public CommandContext CommandContext { get; set; } = new CommandContext();

        private string userInput;

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
            CommandContext.OutputWriter.WriteLine("Do you really want to delete this file? y (yes), n (no)");

            userInput = Console.ReadLine();

            if(userInput != null && userInput.ToLower() == "y") {
                File.Delete("Pfad_zur_Datei"); // Ersetzen!!
                CommandContext.OutputWriter.WriteLine("File successfully deleted.");
            } 
            else
            {
                CommandContext.OutputWriter.WriteLine("File not deleted.");
            }
        }
    }
}
