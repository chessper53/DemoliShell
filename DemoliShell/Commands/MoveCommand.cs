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

        public ICommandOutputWriter OutputWriter { get; set; }

        //Constructor
        public MoveCommand()
        {
            OutputWriter = new CommandOutputWriter();
        }
        public ^MoveCommand(ICommandOutputWriter commandOutputWriter)
        {
            OutputWriter = commandOutputWriter;
        }



        public void Execute()
            {
                if (Parameters != null && Parameters.Count > 0)
                {
                    //Get path of source directory
                    string sourcePath = Parameters[0];

                    //Get path of destination directory
                    string destinationPath = Parameters[1];

                    Directory.Move(sourcePath, destinationPath);
                }
                else { OutputWriter.WriteLine("Parameters are null or empty."); }
            }
    }
}
