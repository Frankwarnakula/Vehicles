using Vehicles.Models;
using Vehicles.Service.Car;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Vehicles.API
{
    [ApiController]
    [Route("[controller]")]
    public class CarServiceController : ControllerBase
    {
        private readonly ICarService _carService = new CarService();

        //public CarServiceController(ICarService carService)
        //{
        //    _carService = carService;
        //}

        [HttpPost]
        [Route("AddCar")]
        public IActionResult AddCar([FromBody()] Car addCar)
        {

            if (addCar == null || !ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                _carService.AddCar(addCar);
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        [Route("UpdateCar")]
        public IActionResult UpdateCar([FromBody()] Car updateCar)
        {
            if (updateCar == null)
            {
                return BadRequest();
            }

            try
            {
                _carService.UpdateCar(updateCar);
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteCar")]
        public IActionResult DeleteCar([FromBody()] int id)
        {
            try
            {
                _carService.DeleteCar(id);
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("GetAllCars")]
        public IActionResult GetAllCars()
        {
            try
            {
                var vehicles = _carService.GetAllCars();
                return StatusCode(200, vehicles);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpGet]
        [Route("GetCarById")]
        public IActionResult GetCarById(int id)
        {
            try
            {
                var vehicle = _carService.GetCarById(id);
                return StatusCode(200, vehicle);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


    }
}
