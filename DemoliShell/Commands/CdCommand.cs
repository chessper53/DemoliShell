using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;   
using System.Text;
using System.Threading.Tasks;
using DemoliShell.Interfaces;

namespace DemoliShell.Commands
{
    internal class CdCommand : ICommand
    {
        public void Execute()
        {
            // Den Pfad zum neuen Arbeitsverzeichnis abrufen
            string path = Console.ReadLine();

            // Das aktuelle Arbeitsverzeichnis ändern
            Directory.SetCurrentDirectory(path);

            // Das neue aktuelle Arbeitsverzeichnis ausgeben
            Console.WriteLine(Directory.GetCurrentDirectory());

            throw new NotImplementedException();

        }
    }
}