using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PzuZadania
{
    public class CarManager
    {
        public CarManager()
        {
            carList = new List<Car>();
            GenerateFakeData();
        }

        private void GenerateFakeData()
        {
            carList.Add(new Car("Audi", "A6")
            {
                Color = CarColors.Black,
                Type = CarTypes.Passenger
            });

            carList.Add(new Car("BMW", "M5")
            {
                Color = CarColors.Blue,
                Type = CarTypes.Passenger
            });

            carList.Add(new Car("Citroen", "C5")
            {
                Color = CarColors.White,
                Type = CarTypes.Passenger
            });

            carList.Add(new Car("Skoda", "Superb")
            {
                Color = CarColors.Green,
                Type = CarTypes.Passenger
            });
        }

        List<Car> carList;

        public IList<Car> GetCarList()
        {
            return carList;
        }

        /// <summary>
        /// Dodaje nowe auto z obiektu
        /// </summary>
        /// <param name="car">Obiekt auta</param>
        public void AddCar(Car car)
        {
            carList.Add(car);
        }

        /// <summary>
        /// Dodaje nowe auto na podstawie parametrów
        /// </summary>
        /// <param name="brand">Marka auta</param>
        /// <param name="model">Model auta</param>
        /// <param name="color">Kolor auta</param>
        public void AddCar(string brand, string model, CarColors color)
        {
            Car car = new Car(brand, model);
            car.Color = color;

            carList.Add(car);
        }
    }
}
