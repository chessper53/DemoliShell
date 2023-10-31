﻿using DemoliShell.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoliShell
{
    internal class CommandOutputWriter : ICommandOutputWriter
    {
        public ConsoleColor ForegroundColor { get { return Console.ForegroundColor; } set { 
                Console.ForegroundColor = value;
            } }

        public void Write(string text)
        {
            Console.Write(text);
        }

        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}
