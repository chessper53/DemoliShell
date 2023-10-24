using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoliShell
{
    internal class CommandShell
    {
        private string currentDir;

        private CommandParser commandParser;

        public void Run()
        {
            do
            {
                showInterface();
                // Den Pfad zum neuen Arbeitsverzeichnis abrufen
                string path = Console.ReadLine();
            } while (true);

        }
        public void showInterface()
        {

        }
        public void Exit()
        {
            System.Environment.Exit(0);
        }
        public void ProcessInput()
        {

        }   
    }
}
