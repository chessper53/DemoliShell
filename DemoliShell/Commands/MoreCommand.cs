﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoliShell.Interfaces;

namespace DemoliShell.Commands
{
    public class MoreCommand : ICommand
    {
        public CommandContext CommandContext { get; set; } = new CommandContext();



        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
