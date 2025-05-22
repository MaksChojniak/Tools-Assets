namespace MChojniakStudio.Console
{
    using MChojniakStudio.Extensions;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;

    public static class Commands
    {
        public static HashSet<Command> commands = new HashSet<Command>();

        public static void AddCommand(string name, Delegate action)
        {
            Command command = new Command(name, action);
            commands.Add(command);
        }


    }
}
