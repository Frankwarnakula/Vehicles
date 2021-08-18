using System.ComponentModel.DataAnnotations;

namespace Vehicles.Models
{

    public class Car 
    {

        public Car()
        {
            this.VehicleType = VehicleTypes.Car;
        }

        [Range(1, 10)]
        public int NumberOfDoors { get; set; }

        [Range(4, 10)]
        public int NumberOfWheels { get; set; }

        [Required]
        public BodyTypes BodyType { get; set; }

        public int Id { get; set; }

        [Required]
        public VehicleTypes VehicleType { get; set; }

        [Required]
        public string Make { get; set; }

        [Required]
        public string Model { get; set; }

    }
}
