
// Nous désirons effectuer la gestion d’une animalerie.
// Cette dernière s’occupe de plusieurs types d’animaux :
// chiens, chats, oiseaux… (laissez libre cours à votre imagination !)
// Pour chaque animal, l’animalerie doit connaitre :
// son nom, son poids, sa taille, son sexe, son âge,
// son âge humain équivalentet sa date d’arrivée à l’animalerie.
// Tous les animaux possèdent le comportement crier().
// Les chats doivent également être caractérisés par leur caractère
// (énergique, farouche, câlin, etc.), si leurs griffes ont été coupées
// et s’il s’agit d’un chat à poil long ou non. Pour les chats,
// la probabilité de décès est de 0,5%. Les chiens doivent être
// caractérisés par la couleur de leur collier, s’il a été dressé et sa race.
// Pour les chiens, la probabilité de décès est de 1%.
// Les oiseaux, quant à eux, sont caractérisés par leur couleur et s’ils
// doivent vivre dans une volière ou dans une petite cage. Pour ces
// derniers, la probabilité de décès est de 3%. Le programme de gestion
// doit : –Encoder des animaux (chiens, chats, oiseaux)–Lister les
// caractéristiques de tous les animaux encodés.–Afficher le nombre de
// chats, de chiens et d’oiseaux–Vérifier si certains animaux ne sont pas
// décédés durant la nuit.

using System;
using System.Collections.Generic;
using Animalerie.Models;
class Program
{
    static List<Animal> animals = new List<Animal>();
    static Random random = new Random();

    static bool ObtenirOuiNon(string message)
    {
        string input;
        do
        {
            input = Console.ReadLine().ToLower();
        } while (input != "oui" && input != "non");

        return input == "oui";
    }

    static string ConvertirEnOuiNon(bool valeur)
    {
        return valeur ? "oui" : "non";
    }
    static void Main(string[] args)
    {
        List<Animal> animauxDecedes = new List<Animal>();
        bool Quitter = false;
        while (!Quitter)
        {
            animauxDecedes.Clear();
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Encoder un animal");
            Console.WriteLine("2. Afficher les caractéristiques des animaux");
            Console.WriteLine("3. Afficher le nombre de chats, de chiens et d'oiseaux");
            Console.WriteLine("4. Quitter");

            string Choix;
            bool choixValide;
            do
            {
                Console.Write("Choix : ");
                Choix = Console.ReadLine();
                choixValide = (Choix == "1" || Choix == "2" || Choix == "3" || Choix == "4");
                if (!choixValide)
                    Console.WriteLine("Veuillez entrer un choix valide (1, 2, 3 ou 4).");
            } while (!choixValide);

            switch (Choix)
            {
                case "1":
                    EncoderAnimal();
                    break;
                case "2":
                    AfficherCaractAnimaux();
                    break;
                case "3":
                    CompterAnimaux();
                    break;
                case "4":
                    Quitter = true;
                    break;
                default:
                    Console.WriteLine("Choix incorrect.");
                    break;
            }
        }
        foreach (var animal in animals)
        {
            double randomNumber = random.NextDouble() * 100;
            if (randomNumber < animal.ChanceDeMourir)
            {
                Console.WriteLine($"L'animal {animal.Nom} est décédé.");
                animauxDecedes.Add(animal); 
            }
        }
        foreach (var animal in animauxDecedes)
        {
            animals.Remove(animal);
        }
    }
    static void EncoderAnimal()
    {
        Console.WriteLine("Quel type d'animal souhaitez-vous encoder ? (chat, chien, oiseau)");

        string TypeAnimal;
        bool typeValide;
        do
        {
            Console.Write("Type d'animal : ");
            TypeAnimal = Console.ReadLine().ToLower();
            typeValide = (TypeAnimal == "chat" || TypeAnimal == "chien" || TypeAnimal == "oiseau");
            if (!typeValide)
                Console.WriteLine("Veuillez entrer un type d'animal valide (chat, chien, ou oiseau).");
        } while (!typeValide);


        switch (TypeAnimal)
        {
            case "chat":
                Console.WriteLine("Entrez le nom du chat:");
                string NomChat = Console.ReadLine();
                Console.WriteLine("Entrez le poids du chat (en grammes):");
                double PoidsChat = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Entrez la taille du chat (en cm):");
                double TailleChat = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Entrez le sexe du chat (male/femelle):");
                string SexeChat = Console.ReadLine();
                Console.WriteLine("Entrez l'âge du chat:");
                int AgeChat = Convert.ToInt32(Console.ReadLine());
                int AgeHumainChat = AgeChat * 7;
                Console.WriteLine($"L'âge humain du chat {NomChat} est de {AgeHumainChat} ans.");
                Console.WriteLine("Entrez la date d'arrivée du chat (au format JJ/MM/AAAA):");
                DateTime DateArriveeChat;

                bool dateValide = false;
                do
                {
                    string DateEntree = Console.ReadLine();
                    if (DateTime.TryParse(DateEntree, out DateArriveeChat))
                    {
                        dateValide = true;
                    }
                    else
                    {
                        Console.WriteLine("Format de date incorrect. Veuillez entrer une date au format JJ/MM/AAAA.");
                    }
                } while (!dateValide);

                Console.WriteLine("Entrez le caractère du chat:");
                string CaractereChat = Console.ReadLine();
                Console.WriteLine("Les griffes du chat ont-elles été coupées ? (oui/non):");
                bool GriffesCoupeesChat = ObtenirOuiNon("Les griffes du chat ont-elles été coupées ? (oui/non):");

                Console.WriteLine("Le chat a-t-il un poil long ? (oui/non):");
                bool PoilLongChat = ObtenirOuiNon("Le chat a-t-il un poil long ? (oui/non):");

                Chat chat = new Chat
                {
                    Nom = NomChat,
                    Poids = PoidsChat,
                    Taille = TailleChat,
                    Sexe = SexeChat,
                    Age = AgeChat,
                    AgeHumain = AgeHumainChat,
                    DateArrivee = DateArriveeChat,
                    Caractere = CaractereChat,
                    GriffesCoupees = GriffesCoupeesChat,
                    PoilLong = PoilLongChat
                };

                animals.Add(chat);


                break;
            case "chien":
                Console.WriteLine("Entrez le nom du chien:");
                string NomChien = Console.ReadLine();
                Console.WriteLine("Entrez le poids du chien (en grammes):");
                double PoidsChien = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Entrez la taille du chien (en cm):");
                double TailleChien = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Entrez le sexe du chien (male/femelle):");
                string SexeChien = Console.ReadLine();
                Console.WriteLine("Entrez l'âge du chien:");
                int AgeChien = Convert.ToInt32(Console.ReadLine());
                int AgeHumainChien = AgeChien * 7;
                Console.WriteLine($"L'âge humain du chat {NomChien} est de {AgeHumainChien} ans.");
                Console.WriteLine("Entrez la date d'arrivée du chien (au format JJ/MM/AAAA):");
                DateTime DateArriveeChien;

                    bool dateValide2 = false;
                do
                {
                    string DateEntree = Console.ReadLine();
                    if (DateTime.TryParse(DateEntree, out DateArriveeChien))
                    {
                        dateValide2 = true;
                    }
                    else
                    {
                        Console.WriteLine("Format de date incorrect. Veuillez entrer une date au format JJ/MM/AAAA.");
                    }
                } while (!dateValide2);

                Console.WriteLine("Entrez la couleur du collier du chien:");
                string CouleurCollierChien = Console.ReadLine();
                Console.WriteLine("Le chien est-il dressé ? (oui/non):");
                bool DresseChien = ObtenirOuiNon("Le chien est-il dressé ? (oui/non):");
                Console.WriteLine("Entrez la race du chien:");
                string RaceChien = Console.ReadLine();

                Chien chien = new Chien
                {
                    Nom = NomChien,
                    Poids = PoidsChien,
                    Taille = TailleChien,
                    Sexe = SexeChien,
                    Age = AgeChien,
                    AgeHumain = AgeHumainChien,
                    DateArrivee = DateArriveeChien,
                    CouleurCollier = CouleurCollierChien,
                    Entraine = DresseChien,
                    Race = RaceChien
                };

                animals.Add(chien);


                break;
            case "oiseau":
                Console.WriteLine("Entrez le nom de l'oiseau:");
                string NomOiseau = Console.ReadLine();
                Console.WriteLine("Entrez le poids de l'oiseau (en grammes):");
                double PoidsOiseau = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Entrez la taille de l'oiseau (en cm):");
                double TailleOiseau = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Entrez le sexe de l'oiseau (male/femelle):");
                string SexeOiseau = Console.ReadLine();
                Console.WriteLine("Entrez l'âge de l'oiseau:");
                int AgeOiseau = Convert.ToInt32(Console.ReadLine());
                int AgeHumainOiseau = AgeOiseau * 7;
                Console.WriteLine($"L'âge humain du chat {NomOiseau} est de {AgeHumainOiseau} ans.");
                Console.WriteLine("Entrez la date d'arrivée de l'oiseau (au format JJ/MM/AAAA):");
                DateTime DateArriveeOiseau;

                bool dateValide3 = false;
                do
                {
                    string DateEntree = Console.ReadLine();
                    if (DateTime.TryParse(DateEntree, out DateArriveeOiseau))
                    {
                        dateValide3 = true;
                    }
                    else
                    {
                        Console.WriteLine("Format de date incorrect. Veuillez entrer une date au format JJ/MM/AAAA.");
                    }
                } while (!dateValide3);

                Console.WriteLine("Entrez la couleur de l'oiseau:");
                string CouleurOiseau = Console.ReadLine();
                Console.WriteLine("Dans quel type de cage vit l'oiseau? :");
                string TypeCageOiseau = Console.ReadLine();

                Oiseau oiseau = new Oiseau
                {
                    Nom = NomOiseau,
                    Poids = PoidsOiseau,
                    Taille = TailleOiseau,
                    Sexe = SexeOiseau,
                    Age = AgeOiseau,
                    AgeHumain = AgeHumainOiseau,
                    DateArrivee = DateArriveeOiseau,
                    Couleur = CouleurOiseau,
                    TypeDeCage = TypeCageOiseau
                };

                animals.Add(oiseau);


                break;
            default:
                Console.WriteLine("Type d'animal invalide.");
                break;
        }
    }
    static void AfficherCaractAnimaux()
    {
        foreach (var animal in animals)
        {
            Console.WriteLine($"Nom: {animal.Nom}, Type: {animal.GetType().Name}");

            if (animal is Chat)
            {
                Chat chat = (Chat)animal;
                Console.WriteLine($"Caractère: {chat.Caractere},  Griffes coupées: {ConvertirEnOuiNon(chat.GriffesCoupees)}, Poil long: {ConvertirEnOuiNon(chat.PoilLong)}");
                Console.WriteLine($"Poids: {chat.Poids} grammes, Taille: {chat.Taille} cm, Sexe: {chat.Sexe}, Âge: {chat.Age} an(s), Âge humain: {chat.AgeHumain} ans, Date d'arrivée: {chat.DateArrivee.ToShortDateString()}");
            }
            else if (animal is Chien)
            {
                Chien chien = (Chien)animal;
                Console.WriteLine($"Couleur du collier: {chien.CouleurCollier}, Dressé: {ConvertirEnOuiNon(chien.Entraine)}, Race: {chien.Race}");
                Console.WriteLine($"Poids: {chien.Poids} grammes, Taille: {chien.Taille} cm, Sexe: {chien.Sexe}, Âge: {chien.Age} an(s), Âge humain: {chien.AgeHumain} ans, Date d'arrivée: {chien.DateArrivee.ToShortDateString()}");
            }
            else if (animal is Oiseau)
            {
                Oiseau oiseau = (Oiseau)animal;
                Console.WriteLine($"Couleur: {oiseau.Couleur}, Type de cage: {oiseau.TypeDeCage}");
                Console.WriteLine($"Poids: {oiseau.Poids} grammes, Taille: {oiseau.Taille} cm, Sexe: {oiseau.Sexe}, Âge: {oiseau.Age} an(s), Âge humain: {oiseau.AgeHumain} ans, Date d'arrivée: {oiseau.DateArrivee.ToShortDateString()}");
            }

            Console.WriteLine(); 
        }
    }
    static void CompterAnimaux()
    {
        int NbChat = 0, NbChien = 0, NbOiseau = 0;
        foreach (var animal in animals)
        {
            if (animal is Chat)
                NbChat++;
            else if (animal is Chien)
                NbChien++;
            else if (animal is Oiseau)
                NbOiseau++;
        }
        Console.WriteLine($"Nombre de chats : {NbChat}");
        Console.WriteLine($"Nombre de chiens : {NbChien}");
        Console.WriteLine($"Nombre de oiseaux : {NbOiseau}");

    }
}

