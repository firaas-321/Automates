using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIF1006_tp1
{
    public class Automate
    {
        public State InitialState { get; set; }
        public State CurrentState { get; set; }
        Dictionary<string, State> stateDictionary = new Dictionary<string, State>();
        public Automate()//j'ai du modifier cette partie car je n'arrivait pas a cree l'etat initiale a partir du fichier txt 
        {
            
            Reset();
        }

        public void LoadFromFile(string filePath)
{
    string L = "";

    StreamReader reader = new StreamReader(filePath);
        
    while (L != null)
    {
        Console.WriteLine(L);
        L = reader.ReadLine();
        if (L != null)
            {
               string[] ListMots = L.Split(' ');
            

        if (ListMots.Length >= 2)
        {
            string commande = ListMots[0];
            string arg1 = ListMots[1];
            string arg2 = ListMots.Length > 2 ? ListMots[2] : null;
            string arg3 = ListMots.Length > 3 ? ListMots[3] : null;//pour acceder aux index plus facilement 


            switch (commande)
            {
                case "state":
                    if (!stateDictionary.ContainsKey(arg1))
                    {
                            // Utiliser un dictionnaire pour stocker les états par leur nom

                        bool isFinal = arg2 == "1";
                        State newState = new State(arg1, isFinal);
                        stateDictionary[arg1] = newState;
                    }
                    else
                    {
                        Console.WriteLine($"Erreur de commande: État déjà défini - {L}");
                    }
                    break;
                case "transition":
                  if (arg1 != null && arg2 != null && arg3 != null)
              {
               if (stateDictionary.ContainsKey(arg1) && stateDictionary.ContainsKey(arg3))
               {
                   char transitionChar = arg2[0]; // Première lettre de l'argument 2
                    stateDictionary[arg1].Transitions.Add(new Transition(transitionChar, stateDictionary[arg3]));
                 }
                  else
               {
                      Console.WriteLine("Erreur de commande: État source ou de transition inexistant - " + L);//pour gerer les erreur etc
                     }
                       }
                    else
                    {
                        Console.WriteLine($"Erreur de commande: État source inexistant - {L}");
                    }
                    break;
                default:
                    Console.WriteLine($"Erreur de commande: Ligne non reconnue - {L}");
                    break;
            }
        }
        else
        {
            Console.WriteLine($"Erreur de commande: Ligne mal formatée - {L}");
        }
    }
    }
     InitialState = stateDictionary["s0"];
    // Fermez le fichier
     reader.Close();
    
    // La variable stateDictionary contient maintenant tous les états


            // Vous devez pouvoir charger à partir d'un fichier quelconque.  Cela peut être un fichier XML, JSON, texte, binaire, ...
            // P.ex. avec un fichier texte, vous pouvoir balayer ligne par ligne et interprété en séparant chaque ligne en un tableau de strings
            // dont le premier représente l'action, et la suite les arguments. L'équivalent de l'automate décrit manuellement dans la classe
            // Program pourrait être:
            //  state s0 0
            //  state s1 0
            //  state s2 1
            //  state s3 0
            //  transition s0 0 s1
            //  transition s1 0 s0
            //  transition s1 1 s2
            //  transition s2 1 s2
            //  transition s2 0 s3
            //  transition s3 1 s1
            // Dans une boucle, on prend les lignes une par une et si le 1er terme est "state", on prend les arguments et on crée un état du même nom
            // et on l'ajoute à une liste d'état
            // Si c'est "transition" on cherche dans la liste d'état l'état qui a le nom en 1er argument et on ajoute la transition avec les 2 autres
            // arguments à sa liste
            // Etc.
            //
            // Considérez que:
            //   - S'il y a d'autres termes, les lignes pourraient être ignorées;
            //   - Si l'état n'est pas trouvé dans la liste (p.ex. l'état est référencé mais n'existe pas (encore)), la transition est ignorée
        }

        public bool Validate(string input)
        {
            bool isValid = true;
            Reset(); 

          char[] caracteresEntree = input.ToCharArray();

         foreach (char caractere in caracteresEntree)
        {
        Transition transition = CurrentState.TrouverTransition(caractere);//pour trouver la transition si elle existe

        if (transition != null)
        {
            CurrentState = transition.TransiteTo;//on continu jusqu'a ne plus trouver de transition ou a la fin de la chaine
        }
        else
        {
            return false;
        }

        Console.WriteLine($"\nÉtat actuel : {CurrentState.Name}, Entrée lue : {caractere}, État transité : {CurrentState.Name} ");
        }
          if(CurrentState.IsFinal){
        isValid = true;
         }else{
        isValid = false;

        }
            // Une fois que tous les caractères de l'entrée ont été lus, vérifier si l'état courant est final
            // Vous devez transformer l'input en une liste / un tableau de caractères (char) et les lire un par un;
            // L'automate doit maintenant à jour son "CurrentState" en suivant les transitions et en respectant l'input.
            // Considérez que l'automate est déterministe et que même si dans les faits on aurait pu mettre plusieurs
            // transitions possibles pour un état et un input donné, le 1er trouvé dans la liste est le chemin emprunté.
            // Si aucune transition n'est trouvé pour un état courant et l'input donné, cela doit retourner faux;
            // Si tous les caractères ont été pris en compte, on vérifie si l'état courant est final ou non et on retourne
            // vrai ou faux selon.

            // VOUS DEVEZ OBLIGATOIREMENT AFFICHER la suite des états actuel, input lu, et état transité pour qu'on puisse
            // suivre le déroulement de l'analyse.
    return isValid;

        }

        public void Reset() => CurrentState = InitialState;

      public override string ToString()
{
    StringBuilder toString = new StringBuilder();

    foreach (var stateEntry in stateDictionary)
    {
        State state = stateEntry.Value;
        toString.AppendLine(state.ToString());
    }

    return toString.ToString();
}

    }
}
