using Vehicles.Models;
using Vehicles.Service.Car;
using System.Collections.Generic;


namespace Vehicles.API.Test.Service
{
    public class CarServiceFake : ICarService
    {

        private static List<Car> _cars = new List<Car>();

        public CarServiceFake()
        {
            _cars = new List<Car>()
            {
                new Car() { Id = 1, Make = "Toyota", Model = "Corolla", BodyType = BodyTypes.Hatchback, NumberOfDoors = 4, NumberOfWheels = 4, VehicleType = VehicleTypes.Car },
                new Car() { Id = 2, Make = "Mazda", Model = "Mx", BodyType = BodyTypes.Sedan, NumberOfDoors = 4, NumberOfWheels = 4, VehicleType = VehicleTypes.Car },
                new Car() { Id = 3, Make = "Nissan", Model = "Saloon", BodyType = BodyTypes.Sedan, NumberOfDoors = 4, NumberOfWheels = 4, VehicleType = VehicleTypes.Car },
            };
        }

        public Car AddCar(Car addCar)
        {
            if (_cars.Count > 1)
            {
                _cars.Sort((vehicle1, vehicle2) => vehicle2.Id.CompareTo(vehicle1.Id));
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
            Car searchCar = _cars.Find(vehicle => vehicle.Id == id);

            if (searchCar != null)
            {
                int index = _cars.FindIndex(ind => ind.Equals(searchCar));
                _cars.RemoveAt(index);
            }
        }

        public List<Car> GetAllCars()
        {
            _cars.Sort((vehicle1, vehicle2) => vehicle2.Id.CompareTo(vehicle1.Id));

            return _cars;
        }

        public Car GetCarById(int id)
        {
            return _cars.Find(vehicle => vehicle.Id == id);
        }

        public void UpdateCar(Car updateCar)
        {
            Car searchCar = _cars.Find(vehicle => vehicle.Id == updateCar.Id);

            if (searchCar != null)
            {
                searchCar.Make = updateCar.Make;
                searchCar.Model = updateCar.Model;
                searchCar.VehicleType = updateCar.VehicleType;
                searchCar.NumberOfDoors = updateCar.NumberOfDoors;
                searchCar.NumberOfWheels = updateCar.NumberOfWheels;
                searchCar.BodyType = updateCar.BodyType;

                int index = _cars.FindIndex(ind => ind.Equals(searchCar));

                _cars[index] = searchCar;
            }

        }
    }
}
