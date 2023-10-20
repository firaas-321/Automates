using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIF1006_tp1
{
    /// <summary>
    /// Un état a un nom (p.ex. "s0", "s1", ou peu importe), peut être un état final, et peut transiter vers d'autres états
    /// selon un input lu (on a donc une liste de transitions, où chaque transition est un tuple (input, nouvel état) 
    /// </summary>
    public class State
    {
        public bool IsFinal {get; set;}
        public string Name { get; private set; }
        public List<Transition> Transitions { get; private set; }

        public State (string name, bool isFinal)
        {
            Name = name;
            IsFinal = isFinal;
            Transitions = new List<Transition>();
        }

        // Au besoin, vous pouvez ajouter du code ici, au min. de redéfinir ToString()
        public override string ToString()
        {
            StringBuilder tostring = new StringBuilder();
            tostring.Append("etat: ").Append(Name);
            if (IsFinal == true) {
               tostring.Append(" (final)");
            }
            
    
            if (Transitions.Any()) {
                tostring.Append("\nTransitions :\n");

                foreach (var transition in Transitions)
                {
                    tostring.Append($" les inputs: {transition.Input}, => {transition.TransiteTo.Name}\n");
                }
             }
              else
            {
                tostring.Append("pas de transitions\n");
            }
             return tostring.ToString();
    }
    }
}
