using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoliShell
{
    internal class CommandParser
    {
        private List<Type> commands;

        public CommandParser() { 
            commands = CommandFactory.GetCommands();
        }
        public Type GetCommand(string input) {
            foreach(Type type in commands)
            {
                int spaceIndex = input.IndexOf(' ');
                string commandInUserInput;

                if (spaceIndex >= 0)
                {
                    commandInUserInput = input.Substring(0, spaceIndex);
                }
                else
                {
                    commandInUserInput = input;
                }

                //Console.WriteLine($"{type.Name}||{commandInUserInput}");

                if (type.Name.ToLower() == commandInUserInput.ToLower()+"command")
                {
                    return type;
                }
            }

            return null;
        }

        public List<string> GetParameter(string input) {
            List<string> parameters = input.Split(' ').ToList<string>(); ;
            parameters.RemoveAt(0);

            if(parameters.Count > 0)
            {
                return parameters;
            }

            return null;
        }
    }
}
