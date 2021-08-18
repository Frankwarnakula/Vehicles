using System.Collections.Generic;


namespace Vehicles.Service.Car
{
    public interface ICarService
    {

        Models.Car GetCarById(int id);

        List<Models.Car> GetAllCars();

        Models.Car AddCar(Models.Car car);

        void UpdateCar(Models.Car car);

        void DeleteCar(int id);
    }
}
