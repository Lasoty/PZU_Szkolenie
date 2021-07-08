using System;
using System.Collections.Generic;

namespace PzuZadania
{

    class Program
    {
        /// <summary>
        /// Metoda startowa programu
        /// </summary>
        /// <param name="args">Argumenty startowe</param>
        static void Main()
        {
            Console.WriteLine("ZADANIA Z PROGRAMOWANIA 1.0 alpha1");
            Console.WriteLine("MENU:");
            Console.WriteLine("\t1. 10 pierwszych liczb");
            Console.WriteLine("\t2. Pobierz i posortuj liczby");
            Console.WriteLine();
            Console.Write("Podaj nr pozycji: ");

            if (int.TryParse(Console.ReadLine(), out int choose))
            {
                Zadania zadania = new Zadania();
                switch (choose)
                {
                    case 1:
                        zadania.TopTenNumbers();
                        break;
                    case 2:
                        zadania.GetAndSortNumbers();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Nieobsługiwany wybór!");
                        Console.ResetColor();
                        break;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nieprawidłowy wybór!");
                Console.ResetColor();
            }



        }
    }
}
