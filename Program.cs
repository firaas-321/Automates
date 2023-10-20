using System;

namespace PIF1006_tp1
{
    public class Program
    {
        static void Main(string[] args)
        {
 
            //-- Ceci est un exemple manuel de ce qui devrait fonctionner pour tester,
            //   mais votre travail DOIT utiliser un fichier chargé quelconque  --
            State s0 = new State("s0", false);
            State s1 = new State("s1", false);
            State s2 = new State("s2", true);
            State s3 = new State("s3", false);
            s0.Transitions.Add(new Transition('0', s1));
            s1.Transitions.Add(new Transition('0', s0));
            s1.Transitions.Add(new Transition('1', s2));
            s2.Transitions.Add(new Transition('1', s2));
            s2.Transitions.Add(new Transition('0', s3));
            s3.Transitions.Add(new Transition('1', s1));

            // Dans cet exemple uniquement, on permet au constructuer d'accueilir un état initial
            // (qui par référence "transporte" tout l'automate en soi)
            Automate automate = new Automate(s0);
           automate.LoadFromFile("teste.txt");
            // On doit pouvoir ensuite appeler une méthode qui permet de valider un input ou non
            bool isValid = automate.Validate("011000");

            // Et ainsi de suite...

            //---------------------------------------------------------------------------------------------------------------------------
            // Ci-haut est un exemple.  Vous devez plutôt faire un menu avec des options/interactions utilisateurs pour:
            //      (1) Charger un fichier en spécifiant le chemin (relatif) du fichier.  Vous pouvez charger un fichier par défaut au démarrage
            //      (2) La liste des états et la liste des transitions doivent pouvoir être affichées proprement;
            //      (3) Soumettre un input en tant que chaîne de 0 ou de 1 -> Assurez-vous que la chaine passée ne contient QUE ces caractères
            //          avant d'envoyer n'est pas obligatoire, mais cela ne doit pas faire planter de l'autre coté;  un message doit indiquer si
            //          c'est accepté ou rejeté.  Vous pouvez vous ajouter une option qui redemande à l'utilisateur s'il veut enter un nouvel
            //          input plutôt que de retourner immédiatement au menu principal ET/OU rentrer une liste d'input (rentrés à la console
            //          ou provenant d'un 2e fichier) pour faire des validations en rafales.
            //      (4) Quitter l'application.
        }
    }
}
