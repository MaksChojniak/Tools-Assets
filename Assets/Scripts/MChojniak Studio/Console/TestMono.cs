namespace MChojniakStudio.Console
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class TestMono : MonoBehaviour
    {

        void CMD(string txt, int num, float num2)
        {
            Console.Log(this, $"{txt} {num} {num2}");
        }


        public void Awake()
        {
            Action<string, int, float> cmd = CMD;
            Commands.AddCommand("TEST", cmd);

            foreach (var command in Commands.commands)
            {
                command.Invoke("test command", 1, 2);
            }
        }
    }
}