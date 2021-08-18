export class Car {
  id: number;
  vehicleType: number;
  numberOfDoors: number;
  numberOfWheels: number;
  bodyType: number;
  make: string;
  model: string;

  constructor(id, vehicleType, numberOfDoors, numberOfWheels, bodyType, make, model) {
    this.id = id;
    this.vehicleType = vehicleType;
    this.numberOfDoors = numberOfDoors;
    this.numberOfWheels = numberOfWheels;
    this.bodyType = bodyType;
    this.make = make;
    this.model = model;
  }
}
