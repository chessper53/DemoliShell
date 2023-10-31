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
        public List<string> Parameters { get; set; }
        public ICommandOutputWriter OutputWriter { get; set; }


        public SetColorCommand()
        {
            OutputWriter = new CommandOutputWriter();
        }
        public SetColorCommand(ICommandOutputWriter commandOutputWriter)
        {
            OutputWriter = commandOutputWriter;
        }

        public void Execute()
        {
            if (Parameters != null && Parameters.Count > 0)
            {
                string colorName = Parameters[0];
                colorName = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(colorName.ToLower());
                ConsoleColor c;
                if (Enum.TryParse(colorName, out c))
                {
                    OutputWriter.ForegroundColor = c;
                }
                else
                {
                    OutputWriter.WriteLine("Color does not Exist, please try again.");
                }
            }
            else { OutputWriter.WriteLine("Parameters are null or empty.");}
        }
    }
}
