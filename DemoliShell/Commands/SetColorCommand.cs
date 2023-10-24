using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoliShell.Interfaces;

namespace DemoliShell.Commands
{
    public class SetColorCommand : ICommand
    {
        public List<string> Parameters { get; set; }

        public void Execute()
        {
            string colorName = Parameters[0];
            colorName = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(colorName.ToLower());
            ConsoleColor c;
            if (Enum.TryParse(colorName, out c)) 
            { 
                Console.ForegroundColor = c;
            } 
            else {
                Console.WriteLine("Color does not Exist, please try again.");
            }
        }
    }
}
