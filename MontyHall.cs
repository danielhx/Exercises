using System;
namespace Struct
{


    public class MontyHall
    {

        static Random random = new Random();

        public static void Main()
        {
            int DoorChangeWins = 0;
            int WithoutDoorChangeWins = 0;
            int Simulations = 0;
            while (true)
            {
                WithoutDoorChangeWins += Game(false) ? 1 : 0; // Incrementeaza daca conditia este indeplinita 1:0 <=> if(true||false)
                DoorChangeWins += Game(true) ? 1 : 0; // 
                Simulations++;
                if ((Simulations % 10) == 0) //Dupa N simulari sa afiseze Rezultatele: 
                {
                    Console.WriteLine("Number Of Simulations: " + Simulations);
                    Console.WriteLine("Numbers Of Wins Without Door Change: " + WithoutDoorChangeWins);
                    Console.WriteLine("Percentage of Wins Without Door Change:  " + ((double)WithoutDoorChangeWins / Simulations) * 100);
                    Console.WriteLine("Number of Wins With Door Change :    " + DoorChangeWins);
                    Console.WriteLine("Percentage of Wins With Door Change:   " + ((double)DoorChangeWins / Simulations) * 100);
                    Console.ReadLine();
                }
            }
        }

        static bool Game(bool DoorChange)
        {
            int Car = GenerateCarAndGoat(); //Genereaza Pozitia Masinii si a Oii
            int PrimaUsa = GenerateFirstDoorChange(); // Prima Usa Random
            int Goat = GenerateGoat(PrimaUsa, Car); //Prezentatorul alege o Oaie random
            int FirstChoice;
            if (DoorChange)
            {
                FirstChoice = MontyHall.ChangeDoor(PrimaUsa, Goat); // Schimba usa dupa ce prezentatorul arata usa cu Oaie
            }
            else
            {
                FirstChoice = PrimaUsa; // Mentine prima alegere: prima usa
            }
            return FirstChoice == Car;
        }

        static int GenerateFirstDoorChange()
        {
            int Choice = random.Next(3); // Concurentul are de ales 3 optiuni: 1,2,3
            return Choice;
        }

        static int GenerateCarAndGoat()
        {
            int Car = random.Next(3); //Masina poate fi 1,2,3
            return Car;
        }

        static int GenerateGoat(int FirstDoorChosen,
            int CarPosition)
        {
            while (true)
            {
                int RandomGoat = random.Next(3); //Oaia poate fi 1,2,3
                if (RandomGoat == FirstDoorChosen || //Oaia nu poate fi in Pozitia Masinii
                    RandomGoat == CarPosition)
                {
                    continue;
                }
                return RandomGoat;
            }
        }

        static int ChangeDoor(int FirstDoorChosen,
            int OaieRandom)
        {
            int DoorChangeResult = 0;
            while (true)
            {
                if (DoorChangeResult == FirstDoorChosen || //Nu schimba niciodata la prima usa aleasa
                    DoorChangeResult == OaieRandom)
                {
                    DoorChangeResult++; //Incearca urmatoarea usa
                    continue;
                }
                return DoorChangeResult;
            }
        }
    }
}

