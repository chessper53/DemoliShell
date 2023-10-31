using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoliShell.Interfaces
{
    public interface ICommandOutputWriter
    {
        ConsoleColor ForegroundColor { get; set; }
        void Write(string text);
        void WriteLine(string text);
    }
}
