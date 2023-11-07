using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using DemoliShell.Filesystem;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using DemoliShell.Persistency;

namespace DemoliShell
{
    internal class CommandShell
    {
        private CommandParser commandParser;
        private CommandInvoker commandInvoker;
        private ShellWorkspace shellWorkspace;

        public CommandShell()
        {
            commandParser = new CommandParser();
            commandInvoker = new CommandInvoker();
            shellWorkspace = new ShellWorkspace();
        }

        public void Run()
        {

            do
            {
                showInterface();
                string userInput = Console.ReadLine();
                ProcessInput(userInput);
                PersistencyService.Save(shellWorkspace.Drive);
            } while (true);

        }
        public void showInterface()
        {
            Console.Write(shellWorkspace.GetFullPath() + " > "); ;

            //Console.Write(System.IO.Directory.GetCurrentDirectory() + " > ");
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
                commandInvoker.ExecuteCommand(type, parameters, shellWorkspace);
            }
            else
            {
                Console.WriteLine("Unkown command, type `Help` for a list of all commands!");
                Console.WriteLine("");
            }
        }   
    }
}
