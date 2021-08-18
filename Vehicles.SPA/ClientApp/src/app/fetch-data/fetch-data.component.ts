import { Component, Inject } from '@angular/core';
import { CarService } from '../car/service/car.service';
import { Car } from '../car/model/car.model';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {

  public cars: Car[];

  constructor(private carService: CarService) {
    this.getAllCars();
  }

  getAllCars() {
    this.carService.getAllCars()
      .subscribe(allCars => {
        this.cars = allCars;
      });
  }
}

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}
