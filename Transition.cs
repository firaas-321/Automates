﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIF1006_tp1
{
    /// <summary>
    /// Une transition représente un tuple (input, nouvel état transité)
    /// </summary>
    public class Transition// je n'ai apporté aucune modification a cette class
    {
        public char Input { get; set; }
        public State TransiteTo { get; set; }

        public Transition(char input, State transiteTo)
        {
            Input = input;
            TransiteTo = transiteTo;
        }

        // Au besoin, vous pouvez ajouter du code ici, au min. de redéfinir ToString()
    }
}
