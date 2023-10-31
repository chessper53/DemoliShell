﻿using System;
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
        public CommandContext CommandContext { get; set; } = new CommandContext();

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
                if (CommandContext.Parameters != null && CommandContext.Parameters.Count > 0)
                {
                    //Get path of source directory
                    string sourcePath = CommandContext.Parameters[0];

                    //Get path of destination directory
                    string destinationPath = CommandContext.Parameters[1];

                    Directory.Move(sourcePath, destinationPath);
                }
                else { OutputWriter.WriteLine("Parameters are null or empty."); }
            }
    }
}
