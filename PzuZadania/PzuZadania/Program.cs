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
        static void Main(IList<string> args)
        {
            Console.WriteLine("Cześć!");
            Console.Write("Jak masz na imię: ");

            string firstName;

            firstName = Console.ReadLine();

            Console.WriteLine("Witaj " + firstName);

            Console.Write("Ile masz lat? ");
            int age = 0;
            string sAge = Console.ReadLine();
            age = Convert.ToInt32(sAge);
            age = int.Parse(sAge);

            Console.WriteLine($"Serio masz {age} lat");
        }
    }
}
