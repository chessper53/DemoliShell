﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoliShell.Interfaces;

namespace DemoliShell.Commands
{
    internal class ExitCommand : ICommand
    {
        public List<string> Parameters { get; set; }

        public void Execute()
        {
            Environment.Exit(0);
        }
    }
}
