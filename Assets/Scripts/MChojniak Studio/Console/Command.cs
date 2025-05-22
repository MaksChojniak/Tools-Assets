namespace MChojniakStudio.Console
{
    using MChojniakStudio.Extensions;
    using System;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Command
    {
        public string Name;
        public Delegate Action;

        public Command(string name, Delegate action)
        {
            Name = name;
            Action = action;
        }

        public Type[] GetArguments() => Action.Method.GetParameters().Select(param => param.ParameterType).ToArray();


        public void Invoke(params object[] args)
        {
            if (!IsValidArguments(args))
            {
                Console.Error(this, "Wrong command arguments!");
                return;
            }
            Action.DynamicInvoke(args);
        }



        public bool IsValidArguments(params object[] args)
        {
            var delegateArgsType = GetArguments().ToList();
            var argsType = args.Select(param => param.GetType()).ToList();

            if (delegateArgsType.Count() != argsType.Count())
                return false;

            for (int i = 0; i < delegateArgsType.Count(); i++)
            {
                if (!argsType[i].IsAssignableTo(delegateArgsType[i]))
                    return false;
            }

            return true;
        }

    }


}
