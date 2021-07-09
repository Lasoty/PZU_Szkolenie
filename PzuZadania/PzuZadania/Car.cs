using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PzuZadania
{
    public class Car
    {
        public Car(string brand, string model) : this(CarTypes.Passenger, brand, model)
        {

        }

        public Car(CarTypes type, string brand, string model)
        {
            Brand = brand;
            Model = model;
            Type = type;
        }


        public string Brand;
        public string Model;
        private CarTypes carType;
        private int currentFuel;
        private int maxFuel = 40;

        public CarColors Color { get; set; }

        public CarTypes Type
        {
            get
            {
                Log("Pobieranie wartości Type");
                return carType;
            }

            set
            {
                Log($"Zapisywanie wartości '{value}' do Type");
                carType = value;
            }
        }

        private void Log(string message)
        {
            Console.WriteLine(message);
        }

        public int Refuel(int fuel)
        {
            if (fuel + currentFuel < maxFuel)
            {
                currentFuel += fuel;
            }
            else
            {
                currentFuel = maxFuel;
            }
            return currentFuel;
        }
    }

    public enum CarTypes
    {
        Truck,
        Passenger,
        Bus
    }

    public enum CarColors
    {
        Black,
        Blue,
        Green,
        Red,
        White,
        Brown
    }
}
