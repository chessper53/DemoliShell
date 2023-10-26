using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using DemoliShell.Interfaces;

namespace DemoliShell.Commands
{
    public class MoveCommand : ICommand
    {
        public List<string> Parameters { get; set; }

        public void Execute()
        {
            // Den Pfad des SourceOrdners abrufen
            string sourcePath = Parameters[0];

            //Den Pfad des DestinationPath abrufen
            string destinationPath = Parameters[1];

            Directory.Move(sourcePath, destinationPath);
        }
    }
}
