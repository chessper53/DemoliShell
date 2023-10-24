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
            // Den Pfad zum neuen Arbeitsverzeichnis abrufen
            string path = Parameters[0];

            // Das aktuelle Arbeitsverzeichnis ändern
            Directory.SetCurrentDirectory(path);

            // Das neue aktuelle Arbeitsverzeichnis ausgeben
            Console.WriteLine(Directory.GetCurrentDirectory());
        }
    }
}