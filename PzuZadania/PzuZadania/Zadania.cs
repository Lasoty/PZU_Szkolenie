using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PzuZadania
{
    internal class Zadania
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

        public void ShowCalculator()
        {
            Console.Clear();
            Console.WriteLine("KALKULATOR");
            Console.WriteLine(" 1. Dodawanie");
            Console.WriteLine(" 2. Odejmowanie");
            Console.WriteLine(" 3. Mnożenie");
            Console.WriteLine(" 4. Dzielenie");
            Console.WriteLine(" 5. Reszta z dzielenia");

            if (int.TryParse(Console.ReadLine(), out int choose))
            {
                Console.Clear();
                Console.Write("Podaj x: ");
                int x = int.Parse(Console.ReadLine());

                Console.Write("Podaj y: ");
                int y = int.Parse(Console.ReadLine());

                Calculator calculator = new Calculator();
                float result = 0;

                switch (choose)
                {
                    case 1:
                        result = calculator.Sum(x, y);
                        Console.WriteLine($"Wynik dodawania {x} + {y} to {result}. ");
                        break;
                    case 2:
                        result = calculator.Subtract(x, y);
                        Console.WriteLine($"Wynik odejmowania {x} - {y} to {result}. ");
                        break;
                    case 3:
                        result = calculator.Multiply(x, y);
                        Console.WriteLine($"Wynik mnożenia {x} * {y} to {result}. ");
                        break;
                    case 4:
                        try
                        {
                            result = calculator.Divide(x, y);
                            Console.WriteLine($"Wynik dzielenia {x} / {y} to {result}. ");
                        }
                        catch (DivideByZeroException ex)
                        {
                            ShowError(ex.Message);
                        }
                        catch (Exception ex)
                        {
                            ShowError("Wystąpił niespodziewany problem.");
                        }
                        break;
                    case 5:
                        try
                        {
                            result = calculator.Modulo(x, y);
                            Console.WriteLine($"Wynik reszty z dzielenia {x} / {y} to {result}. ");
                        }
                        catch (Exception ex)
                        {
                            ShowError(ex.Message);
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        private void ShowError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
