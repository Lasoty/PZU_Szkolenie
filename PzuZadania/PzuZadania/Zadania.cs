using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PzuZadania
{
    class Zadania
    {
        public void TopTenNumbers()
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.Write(i + " ");
            }
        }

        public void GetAndSortNumbers()
        {
            //1. Liczbę numerów - nie potrzebny
            //2. Numery do posortowania
            //3. Posortuje "na piechotę"

            Console.WriteLine("Podaj liczby do posortowania: ");
            string sNumbers = Console.ReadLine();
            string[] sNumbersArray = sNumbers.Split(" ");
            
            for (int i = 0; i < sNumbersArray.Length; i++)
            {
                for (int j = 0; j < sNumbersArray.Length - 1; j++)
                {
                    int first = int.Parse(sNumbersArray[j]);
                    int second = int.Parse(sNumbersArray[j + 1]);
                    if (first > second)
                    {
                        string tmp = sNumbersArray[j];
                        sNumbersArray[j] = sNumbersArray[j + 1];
                        sNumbersArray[j + 1] = tmp;
                    }
                }
            }

            Console.WriteLine("Posortowana tablica: ");
            foreach (string item in sNumbersArray)
            {
                Console.Write(item + " ");
            }

        }
    }
}
