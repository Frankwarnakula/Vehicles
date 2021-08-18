using Vehicles.API.Test.Service;
using Vehicles.Models;
using Vehicles.Service.Car;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Xunit;

namespace Vehicles.API.Test
{

    public class CarServiceControllerTest
    {

        ICarService _service;
        CarServiceController _controller;

        public CarServiceControllerTest()
        {
            _service = new CarServiceFake();
            _controller = new CarServiceController();
        }


        [Fact]
        public void GetAllCars_When_Called_Returns_HTTP_200()
        {
            clearData();
            var apiResult = _controller.GetAllCars();
            Assert.Equal(200, ((ObjectResult)apiResult).StatusCode);
        }

        [Fact]
        public void GetAllCars_When_Called_Returns_All_Cars()
        {
            clearData();
            var apiResult = _controller.GetAllCars();
            var items = (List<Car>)((ObjectResult)apiResult).Value;
            Assert.Equal(0, items.Count);
        }

        [Fact]
        public void AddCar_When_Called_Adds_A_New_Car()
        {
            clearData();
            Car vehicle = new Car()
            {
                Id = 1,
                Model = "Tesla",
                Make  = "T3",
                NumberOfDoors = 2,
                NumberOfWheels = 4,
                BodyType = BodyTypes.Sedan,
                VehicleType = VehicleTypes.Car
            };

            var createdResponse = _controller.AddCar(vehicle);
            Assert.Equal(200, ((StatusCodeResult)createdResponse).StatusCode);

            var apiResult = _controller.GetAllCars();
            var items = (List<Car>)((ObjectResult)apiResult).Value;
            Assert.Equal(1, items.Count);
        }

        [Fact]
        public void GetCarById_When_Called_Returns_The_Requested_Car()
        {
            clearData();
            Car vehicle = new Car()
            {
                Id = 1,
                Model = "Tesla",
                Make = "T3",
                NumberOfDoors = 2,
                NumberOfWheels = 4,
                BodyType = BodyTypes.Sedan,
                VehicleType = VehicleTypes.Car
            };

            _controller.AddCar(vehicle);

            var apiResult = _controller.GetCarById(1);
            Assert.Equal(200, ((ObjectResult)apiResult).StatusCode);

            var item = (Car)((ObjectResult)apiResult).Value;
            Assert.Equal(1, item.Id);
            Assert.Equal("Tesla", item.Model);
            Assert.Equal("T3", item.Make);
            Assert.Equal(2, item.NumberOfDoors);
            Assert.Equal(4, item.NumberOfWheels);
            Assert.Equal(BodyTypes.Sedan, item.BodyType);
            Assert.Equal(VehicleTypes.Car, item.VehicleType);
        }

        [Fact]
        public void DeleteCar_When_Called_Removes_The_Car()
        {
            clearData();
            Car vehicle = new Car()
            {
                Id = 1,
                Model = "Tesla",
                Make = "T3",
                NumberOfDoors = 2,
                NumberOfWheels = 4,
                BodyType = BodyTypes.Sedan,
                VehicleType = VehicleTypes.Car
            };

            _controller.AddCar(vehicle);

            vehicle = new Car()
            {
                Id = 1,
                Model = "Mx",
                Make = "Mazda",
                NumberOfDoors = 4,
                NumberOfWheels = 4,
                BodyType = BodyTypes.Sedan,
                VehicleType = VehicleTypes.Car
            };

            _controller.AddCar(vehicle);

            var apiResult = _controller.GetAllCars();
            var itemsBeforeDelete = (List<Car>)((ObjectResult)apiResult).Value;
            var countBeforeDelete = itemsBeforeDelete.Count;

            apiResult = _controller.GetCarById(2);
            Assert.Equal(200, ((ObjectResult)apiResult).StatusCode);
            var item = (Car)((ObjectResult)apiResult).Value;

            Assert.Equal(2, item.Id);
            Assert.Equal("Mx", item.Model);
            Assert.Equal("Mazda", item.Make);
            Assert.Equal(4, item.NumberOfDoors);
            Assert.Equal(4, item.NumberOfWheels);
            Assert.Equal(BodyTypes.Sedan, item.BodyType);
            Assert.Equal(VehicleTypes.Car, item.VehicleType);

            apiResult = _controller.DeleteCar(2);
            Assert.Equal(200, ((StatusCodeResult)apiResult).StatusCode);

            apiResult = _controller.GetAllCars();
            var itemsAfterDelete = (List<Car>)((ObjectResult)apiResult).Value;

            Assert.Equal(countBeforeDelete - 1, itemsAfterDelete.Count);

        }

        [Fact]
        public void UpdateCar_When_Called_Updates_The_Car()
        {
            clearData();
            Car vehicle = new Car()
            {
                Id = 1,
                Model = "Tesla",
                Make = "T3",
                NumberOfDoors = 2,
                NumberOfWheels = 4,
                BodyType = BodyTypes.Sedan,
                VehicleType = VehicleTypes.Car
            };

            _controller.AddCar(vehicle);

            vehicle = new Car()
            {
                Id = 1,
                Model = "Mx",
                Make = "Mazda",
                NumberOfDoors = 4,
                NumberOfWheels = 4,
                BodyType = BodyTypes.Sedan,
                VehicleType = VehicleTypes.Car
            };

            _controller.AddCar(vehicle);

            vehicle = new Car()
            {
                Id = 1,
                Model = "Saloon",
                Make = "Nissan",
                NumberOfDoors = 4,
                NumberOfWheels = 4,
                BodyType = BodyTypes.Sedan,
                VehicleType = VehicleTypes.Car
            };

            _controller.AddCar(vehicle);


            var apiResult = _controller.GetCarById(3);
            Assert.Equal(200, ((ObjectResult)apiResult).StatusCode);
            var item = (Car)((ObjectResult)apiResult).Value;

            Assert.Equal(3, item.Id);
            Assert.Equal("Saloon", item.Model);
            Assert.Equal("Nissan", item.Make);
            Assert.Equal(4, item.NumberOfDoors);
            Assert.Equal(4, item.NumberOfWheels);
            Assert.Equal(BodyTypes.Sedan, item.BodyType);
            Assert.Equal(VehicleTypes.Car, item.VehicleType);

            var modifyingCar = new Car() { Id = 3, Make = "Tesla", Model = "DriverLess", BodyType = BodyTypes.Sedan, NumberOfDoors = 2, NumberOfWheels = 8, VehicleType = VehicleTypes.Car };

            apiResult = _controller.UpdateCar(modifyingCar);
            Assert.Equal(200, ((StatusCodeResult)apiResult).StatusCode);

            apiResult = _controller.GetCarById(3);
            Assert.Equal(200, ((ObjectResult)apiResult).StatusCode);
            item = (Car)((ObjectResult)apiResult).Value;

            Assert.Equal(3, item.Id);
            Assert.Equal("DriverLess", item.Model);
            Assert.Equal("Tesla", item.Make);
            Assert.Equal(2, item.NumberOfDoors);
            Assert.Equal(8, item.NumberOfWheels);
            Assert.Equal(BodyTypes.Sedan, item.BodyType);
            Assert.Equal(VehicleTypes.Car, item.VehicleType);
        }

        private void clearData()
        {
            for (int i = 0; i < 3; i++)
            {
                _controller.DeleteCar(i);
            }
        }

    }
}
