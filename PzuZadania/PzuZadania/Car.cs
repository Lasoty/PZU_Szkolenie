using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PzuZadania
{
    class Car
    {
        public Car(string brand, string model) : this(CarType.Passenger, brand, model)
        {

        }

        public Car(CarType type, string brand, string model)
        {
            Brand = brand;
            Model = model;
            Type = type;
        }


        public string Brand;
        public string Model;
        private CarType carType;
        private int currentFuel;
        private int maxFuel = 40;

        public CarColors Color { get; set; }

        public CarType Type
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

    public enum CarType
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
