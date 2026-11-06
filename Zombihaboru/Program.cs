
using System;

namespace Zombihaboru
{
    internal class Program
    {
        static Random r = new Random();
        static string[] NevekLetrehozasa(int db)
        {
            string[] nevekOsszes = { "Roland", "Ádám", "Bence", "Csaba", "Dávid", "Erik", "Ferenc", "Gábor", "Hunor", "István", "János", "Károly", "Levente", "Márk", "Norbert", "Péter", "Richárd", "Sándor", "Tamás", "Viktor", "Zoltán", "Anna", "Barbara", "Csilla", "Dóra", "Eszter", "Fanni", "Hanna", "Kata", "Lilla", "Zsófia" };
            string[] nevek = new string[db];
            for (int i = 0; i < db; i++)
            {
                int index = r.Next(0, nevekOsszes.Length);
                nevek[i] = nevekOsszes[index];
            }
            return nevek;
        }

        static void Kiir(string[] nevek)
        {
            foreach (var nev in nevek)
            {
                Console.WriteLine(nev);
            }
        }

        static int[] eleteroBeallitasa(int lakossagSzama)
        {
            int[] eleterok = new int[lakossagSzama];
            for (int i = 0; i < lakossagSzama; i++)
            {
                eleterok[i] = 100;
            }
            return eleterok;
        }

        static int[] TamadoEroBeallitasa(int zombikSzama)
        {
            int[] tamadoEreje = new int[zombikSzama];
            for (int i = 0; i < zombikSzama; i++)
            {
                tamadoEreje[i] = r.Next(10, 25);
            }
            return tamadoEreje;
        }

        static void KiirSzamok(int[] tomb)
        {
            foreach (var item in tomb)
            {
                Console.Write(item+" ");
            }
            Console.WriteLine();
        }


        static bool VanEElolakos(int[] eleterok)
        {
            foreach (var item in eleterok)
            {
                if (item > 0)
                {
                    return true;
                }
            }
            return false;
        }

        static bool VanEErosZombi(int[] zombikTamadoEreje)
        {
            foreach (var item in zombikTamadoEreje)
            {
                if (item > 0)
                {
                    return true;
                }
            }
            return false;
        }

        static void Jatek(int[] lakossagEletereje, int[] zombikTamadoEreje, string[] lakossag, string[] zombik)
        {
            int kor = 1;
            while (VanEElolakos(lakossagEletereje) && VanEErosZombi(zombikTamadoEreje))
            {
                Console.WriteLine($"--- {kor}. kör ---");
                for (int i = 0; i < zombikTamadoEreje.Length; i++)
                {
                    if (zombikTamadoEreje[i] > 0 && VanEElolakos(lakossagEletereje))
                    {
                        int lakosIndex = r.Next(0, lakossagEletereje.Length);
                        while (lakossagEletereje[lakosIndex] <= 0)
                        {
                            lakosIndex = r.Next(0, lakossagEletereje.Length);
                        }

                        int sebzes = zombikTamadoEreje[i];
                        lakossagEletereje[lakosIndex] -= sebzes;
                        if (lakossagEletereje[lakosIndex] < 0)
                        {
                            lakossagEletereje[lakosIndex] = 0;
                        }

                        Console.WriteLine($"{zombik[i]} megtámadta {lakossag[lakosIndex]}-t, aki {sebzes} sebzést kapott. ({lakossagEletereje[lakosIndex]} maradt)");

                        if (lakossagEletereje[lakosIndex] == 0)
                        {
                            Console.WriteLine($"{lakossag[lakosIndex]} meghalt.");
                        }

                        int faradtsag = r.Next(1, 6);
                        zombikTamadoEreje[i] -= faradtsag;
                        if (zombikTamadoEreje[i] <= 0)
                        {
                            zombikTamadoEreje[i] = 0;
                            Console.WriteLine($"{zombik[i]} elfáradt, többé nem tud támadni.");
                        }
                    }
                }
                Console.WriteLine("Lakosság életereje: ");
                KiirSzamok(lakossagEletereje);
                Console.WriteLine("Zombik támadóereje: ");
                KiirSzamok(zombikTamadoEreje);
                kor++;
            }

            if (!VanEElolakos(lakossagEletereje))
            {
                Console.WriteLine("Minden lakó meghalt, a zombik győztek!");
            }
            else
            {
                Console.WriteLine("A zombik elfáradtak, a lakók túlélték!");
            }
        }
        static void Main(string[] args)
        {
            int lakossagSzama = 5;
            int zombikSzama = 3;
            string[] lakossag = NevekLetrehozasa(lakossagSzama);
            string[] zombik = NevekLetrehozasa(zombikSzama);
            Console.Write("Lakosság:");
            Kiir(lakossag);
            Console.Write("Zombik:");
            Kiir(zombik);
            int[] lakossagEletereje = eleteroBeallitasa(lakossagSzama);
            int[] zombikTamadoEreje = TamadoEroBeallitasa(zombikSzama);
            Console.Write("Lakosság életereje: ");
            KiirSzamok(lakossagEletereje);
            Console.Write("Zombik támadó ereje: ");
            KiirSzamok(zombikTamadoEreje);
            VanEErosZombi(zombikTamadoEreje);
            Jatek(lakossagEletereje, zombikTamadoEreje, lakossag, zombik);
        }

        


    }
}
