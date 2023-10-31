using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DemoliShell.Interfaces;


namespace DemoliShell.Commands
{
    public class VerCommand : ICommand
    {
        public CommandContext CommandContext { get; set; } = new CommandContext();


        public void Execute()
        {
            OperatingSystem os = Environment.OSVersion;

            Console.WriteLine("OS Version: " + os.Version.ToString());
        }
    }
}
