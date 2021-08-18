import { Component, OnInit } from '@angular/core';
import { CarService } from '../car/service/car.service';
import { Car } from '../car/model/car.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {

  public vehicles: string[] = ["Car", "Boat", "Bike"];
  public selectedVehicle = "Car";
  public status: string;
  public error: string;
  public make: string;
  public model: string;
  public bodyType: string;
  public numberOfWheels: number;
  public numberOfDoors: number;

  constructor(private carService: CarService) {
  }

  addCar() {
    this.status = "";
    this.error = "";
    let car = new Car(1, 0, this.numberOfDoors, this.numberOfWheels, parseInt(this.bodyType), this.make, this.model);
    this.carService.addCar(car)
      .subscribe(status => {
        if (status && status.error) {
          this.error = "There was an error in creating a vehicle";
        } else {
          this.status = "Successfully created";
        }
        
      });
  }

  ngOnInit() {
    this.numberOfDoors = 1;
    this.numberOfWheels = 4;
    this.bodyType = "1";
    this.make = "Toyota";
    this.model = "Corolla";
  }

}
