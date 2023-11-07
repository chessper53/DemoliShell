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

            //DEBUG
            Filesystem.Directory dir = new Filesystem.Directory();
            dir.ParentDirectory = shellWorkspace.CurrentDirectory;
            dir.Name = "eat";

            Filesystem.Directory dir2 = new Filesystem.Directory();
            dir2.ParentDirectory = dir;
            dir2.Name = "eat2";
            dir.FilesystemItems.Add(dir2);

            Filesystem.File file = new Filesystem.File();
            file.ParentDirectory = dir;
            file.Name = "file";
            dir.FilesystemItems.Add(file);

            Filesystem.Directory dir3 = new Filesystem.Directory();
            dir3.ParentDirectory = dir;
            dir3.Name = "eat3";
            dir.FilesystemItems.Add(dir3);
            shellWorkspace.CurrentDirectory.FilesystemItems.Add(dir);



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
            Console.Write(shellWorkspace.GetFullPath() + " > "); ;
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
