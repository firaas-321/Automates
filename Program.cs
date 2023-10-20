using System;

namespace PIF1006_tp1
{
    public class Program
    {
        static void Main(string[] args)
        {
 
            Automate automate = new Automate(); 

            while (true)
            {
                // creation du menu
                Console.WriteLine("\n==================================   Menu creation d'automates   ==========================================\n\n");
                Console.WriteLine("1. Charger un fichier\n");
                Console.WriteLine("2. Afficher la liste des états et transitions\n");
                Console.WriteLine("3. Soumettre un input\n");
                Console.WriteLine("4. Quitter\n\n");

                Console.Write("Veuillez sélectionnez une option entre 1 et 4: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("\nEntrez le chemin du fichier à charger : ");
                        string filePath = Console.ReadLine();
                        try{
                        automate.LoadFromFile(filePath);
                        }catch(Exception e){
                            Console.WriteLine("\nException declancher le ce chemain est erroné ou n'existe pas\n");
                        }
                        break;
                    case "2":
                        if (automate != null)
                        {
                            Console.WriteLine(automate.ToString());
                        }
                        else
                        {
                            Console.WriteLine("L'automate n'a pas encore été chargé.Veuillez charger un fichier ");
                        }
                        break;
                    case "3":
                        if (automate != null)
                        {
                            Console.Write("Entrez un input en tant que chaîne de 0 ou de 1 : ");
                            
                            string input = Console.ReadLine();
            
                            bool isValid = automate.Validate(input);
                            if (isValid)
                            {
                                Console.WriteLine("Votre nput accepté !");
                            }
                            else
                            {
                                Console.WriteLine("votre input rejeté !");
                            }
                        }
                        else
                        {
                            Console.WriteLine("L'automate n'a pas encore été chargé. Chargez un fichier d'abord.");
                        }
                        break;
                    case "4":
                        Console.WriteLine("Fin de l'application.");
                        return;
                    default:
                        Console.WriteLine("Option invalide. Veuillez choisir une option valide (1-4).");
                        break;
                }
            }
        }
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

