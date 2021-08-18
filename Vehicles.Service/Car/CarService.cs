using System.Collections.Generic;


namespace Vehicles.Service.Car
{
    public class CarService : ICarService
    {

        private static List<Models.Car> _cars = new List<Models.Car>();

        public Models.Car AddCar(Models.Car addCar)
        {
            if (_cars.Count > 1)
            {
                _cars.Sort((car1, car2) => car2.Id.CompareTo(car1.Id));
            }

            var maximumId = 0;
            if (_cars.Count > 0)
            {
                maximumId = _cars[0].Id;
            }

            addCar.Id = maximumId + 1;

            _cars.Add(addCar);

            return addCar;
        }

        public void DeleteCar(int id)
        {
            Models.Car searchCar = _cars.Find(car => car.Id == id);

            if (searchCar != null)
            {
                int index = _cars.FindIndex(ind => ind.Equals(searchCar));
                _cars.RemoveAt(index);
            }
        }

        public List<Models.Car> GetAllCars()
        {
            _cars.Sort((car1, car2) => car2.Id.CompareTo(car1.Id));

            return _cars;
        }

        public Models.Car GetCarById(int id)
        {
            return _cars.Find(car => car.Id == id);
        }

        public void UpdateCar(Models.Car updateCar)
        {
            Models.Car searchCar = _cars.Find(car => car.Id == updateCar.Id);

            if (searchCar != null)
            {
                searchCar.Make = updateCar.Make;
                searchCar.Model = updateCar.Model;
                searchCar.NumberOfDoors = updateCar.NumberOfDoors;
                searchCar.NumberOfWheels = updateCar.NumberOfWheels;
                searchCar.BodyType = updateCar.BodyType;

                int index = _cars.FindIndex(ind => ind.Equals(searchCar));

                _cars[index] = searchCar;
            }

        }
    }
}
