using System;
namespace Struct
{
    public class MontyHall
    {

        static Random random = new Random();

        public static void Main()
        {
            int CastiguriCuSchimbareDeUsa = 0;
            int CastiguriFaraSchimbareDeUsa = 0;
            int NrSimulari = 0;
            while (true)
            {
                CastiguriFaraSchimbareDeUsa += Joc(false) ? 1 : 0; // Incrementeaza daca conditia este indeplinita 1:0 <=> if(true||false)
                CastiguriCuSchimbareDeUsa += Joc(true) ? 1 : 0; // 
                NrSimulari++;
                if ((NrSimulari % 10) == 0) //Dupa N simulari sa afiseze Rezultatele: 
                {
                    Console.WriteLine("Numar Simulari: " + NrSimulari);
                    Console.WriteLine("Numar Castiguri Fara Schimbare De Usa: " + CastiguriFaraSchimbareDeUsa);
                    Console.WriteLine("Procent De Castiguri Fara schimbare De Usa:  " + ((double)CastiguriFaraSchimbareDeUsa / NrSimulari) * 100);
                    Console.WriteLine("Numar Castiguri Cu Schimbare de Usa :    " + CastiguriCuSchimbareDeUsa);
                    Console.WriteLine("Procent Castiguri Cu Schimbare De Usa:   " + ((double)CastiguriCuSchimbareDeUsa / NrSimulari) * 100);
                    Console.ReadLine();
                }
            }
        }

        static bool Joc(bool SchimbareUsa)
        {
            int Masina = GenereazaMasinaSiOaie(); //Genereaza Pozitia Masinii si a Oii
            int PrimaUsa = GenereazaAlegereaPrimaUsa(); // Prima Usa Random
            int OaieRandom = GenereazaOaieRandom(PrimaUsa, Masina); //Prezentatorul alege o Oaie random
            int PrimaAlegere;
            if (SchimbareUsa)
            {
                PrimaAlegere = MontyHall.SchimbareUsa(PrimaUsa, OaieRandom); // Schimba usa dupa ce prezentatorul arata usa cu Oaie
            }
            else
            {
                PrimaAlegere = PrimaUsa; // Mentine prima alegere: prima usa
            }
            return PrimaAlegere == Masina;
        }

        static int GenereazaAlegereaPrimaUsa()
        {
            int Alegere = random.Next(3); // Concurentul are de ales 3 optiuni: 1,2,3
            return Alegere;
        }

        static int GenereazaMasinaSiOaie()
        {
            int Masina = random.Next(3); //Masina poate fi 1,2,3
            return Masina;
        }

        static int GenereazaOaieRandom(int PrimaUsaAleasa,
            int PozitiaMasinii)
        {
            while (true)
            {
                int OaieRandom = random.Next(3); //Oaia poate fi 1,2,3
                if (OaieRandom == PrimaUsaAleasa || //Oaia nu poate fi in Pozitia Masinii
                    OaieRandom == PozitiaMasinii)
                {
                    continue;
                }
                return OaieRandom;
            }
        }

        static int SchimbareUsa(int PrimaUsaAleasa,
            int OaieRandom)
        {
            int RezultatSchimbareUsa = 0;
            while (true)
            {
                if (RezultatSchimbareUsa == PrimaUsaAleasa || //Nu schimba niciodata la prima usa aleasa
                    RezultatSchimbareUsa == OaieRandom)
                {
                    RezultatSchimbareUsa++; //Incearca urmatoarea usa
                    continue;
                }
                return RezultatSchimbareUsa;
            }
        }
    }
}

