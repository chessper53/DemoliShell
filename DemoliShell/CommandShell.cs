using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using DemoliShell.Filesystem;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DemoliShell
{
    internal class CommandShell
    {
        private CommandParser commandParser;
        private CommandInvoker commandInvoker;

        public CommandShell()
        {
            commandParser = new CommandParser();
            commandInvoker = new CommandInvoker();
        }

        public void Run()
        {
            do
            {
                showInterface();
                string userInput = Console.ReadLine();
                ProcessInput(userInput);
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
        public void ProcessInput(string userInput)
        {
            Type type = commandParser.GetCommand(userInput);
            List<string> parameters = commandParser.GetParameter(userInput);

            if(type != null)
            {
                commandInvoker.ExecuteCommand(type, parameters);
            }
            else
            {
                Console.WriteLine("Unkown command, type `Help` for a list of all commands!");
                Console.WriteLine("");
            }
        }   
    }
}
