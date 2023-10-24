using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoliShell.Interfaces;

namespace DemoliShell
{
    internal class CommandFactory
    {
        static List<Type> commands = SetCommands();

        public static ICommand CreateCommand(Type type)
        {
            foreach (var commandType in commands)
            {
                if (commandType.IsAssignableFrom(type))
                {
                    return Activator.CreateInstance(commandType) as ICommand;
                }
            }
            return null;
        }
        static List<Type> SetCommands()
        {
            Type interfaceType = typeof(ICommand);

            return AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(assembly => assembly.GetTypes())
            .Where(type => interfaceType.IsAssignableFrom(type) && !type.IsInterface)
            .ToList();
        }
        public static List<Type> GetCommands()
        {
            return commands;
        }
    }
}
