using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;   
using System.Text;
using System.Threading.Tasks;
using DemoliShell.Interfaces;

namespace DemoliShell.Commands
{
    public class CdCommand : ICommand
    {
        public List<string> Parameters { get; set; }

        public void Execute()
        {
            if (Parameters != null && Parameters.Count > 0)
            {
                string path = Parameters[0];
                Directory.SetCurrentDirectory(path);
            }
            else { Console.WriteLine("Parameters are null or empty."); }
        }
    }
}