using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoliShell.Interfaces;
using NUnitLite;

namespace DemoliShell.Commands
{
    public class SetColorCommand : ICommand
    {
        public CommandContext CommandContext { get; set; } = new CommandContext();


        public SetColorCommand()
        {
            CommandContext.OutputWriter = new CommandOutputWriter();
        }
        public SetColorCommand(ICommandOutputWriter commandOutputWriter)
        {
            CommandContext.OutputWriter = commandOutputWriter;
        }

        public void Execute()
        {
            if (CommandContext.Parameters != null && CommandContext.Parameters.Count > 0)
            {
                string colorName = CommandContext.Parameters[0];
                colorName = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(colorName.ToLower());
                ConsoleColor c;
                if (Enum.TryParse(colorName, out c))
                {
                    CommandContext.OutputWriter.ForegroundColor = c;
                }
                else
                {
                    CommandContext.OutputWriter.WriteLine("Color does not Exist, please try again.");
                }
            }
            else { CommandContext.OutputWriter.WriteLine("Parameters are null or empty.");}
        }
    }
}
