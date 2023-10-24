using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

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
            Console.Write(Directory.GetCurrentDirectory() + " > ");
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
