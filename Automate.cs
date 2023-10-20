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
        private List<State> ListState;
        public Automate(State initialState)
        {
            InitialState = initialState;
            Reset();
        }

        public void LoadFromFile(string filePath)
        {
            string L;
            //Pass the file path and file name to the StreamReader constructor
            StreamReader reader = new StreamReader(filePath);
            //Read the first line of text
            L = reader.ReadLine();
            //Continue to read until you reach end of file
            while (L != null)
           {
            //write the line to console window
            Console.WriteLine(L);
            //Read the next line
            L = reader.ReadLine();
             string[] ListMots = L.Split(' ');
             List<string> Sauvgarde = new List<string>();
                    
                    
                       switch(ListMots[0]){
                        case ("state"):
                        if(ListMots[1]!=null && ListMots[2]!=null ){
                            if(!Sauvgarde.Contains(ListMots[1])){
                            switch(ListMots[2]){
                                case "1":
                                ListState.Add(new State(ListMots[1],true));
                                break
                                ;
                                case "0":
                                ListState.Add(new State(ListMots[1],false));
                                break
                                ;
                                default:
                                Console.WriteLine("erreur de commande lecture du fichier impossible");
                                break
                                ;
                            }
                            }
                        }else{
                             Console.WriteLine("erreur de commande lecture du fichier impossible");

                        }
                         break
                        ;
                        case ("transition"):
                          if(ListMots[1]!=null && ListMots[2]!=null ){
                            foreach(var state in ListState){
                                if(state.Name == ListMots[1]){
                            switch(ListMots[2]){
                                case "1":
                                ListState.Add(new State(ListMots[1],true));
                                break
                                ;
                                case "0":
                                ListState.Add(new State(ListMots[1],false));
                                break
                                ;
                                default:
                                Console.WriteLine("erreur de commande lecture du fichier impossible");
                                break
                                ;
                            }
                        }
                          }
                          }
                         break
                        ;
                        case ("end"):
                         break
                        ;
                       }


                    
            }
            
             //close the file
            reader.Close();
            Console.ReadLine();
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
         public void requete(string a){

         }
        public bool Validate(string input)
        {
            bool isValid = true;
            Reset();

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

        public override string ToString()
        {
            // Vous devez modifier cette partie de sorte à retourner un équivalent string qui décrit tous les états et
            // la table de transitions de l'automate.
            return base.ToString(); // On ne retournera donc pas le ToString() par défaut
        }

        public void Reset() => CurrentState = InitialState;
    }
}
