namespace MChojniakStudio.Console
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    [CreateAssetMenu(fileName = "Console Setup", menuName = "MChojniakStudio/Console Setup")]
    public class ConsoleSetup : ScriptableObject
    {
        public static ConsoleSetup Instance { get; private set; }

        public Color LogColor;
        public Color WarningColor;
        public Color ErrorColor;
        public Color CommandColor;

        public bool ShowSender;

        void OnEnable()
        {
            Instance = this;
        }

        void OnDisable()
        {
            Instance = null;
        }

    }

}