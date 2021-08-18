import { Inject, Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { Car } from '../model/car.model';

@Injectable({ providedIn: 'root' })
export class CarService {

  private _baseUrl: string;

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(public http: HttpClient) {
    this._baseUrl = "https://localhost:44310/CarService/";
  }


  addCar(car: Car): Observable<any> {
    var request = `AddCar`;
    return this.http.post<any>(this._baseUrl + request, car )
      .pipe(
        tap(_ => console.log('AddCar')),
        catchError(this.handleError<any>('AddCar'))
      );
  }

  updateCar(car: Car): Observable<any> {
    var request = `UpdateCar`;
    return this.http.put<any>(this._baseUrl + request, car)
      .pipe(
        tap(_ => console.log('UpdateCar')),
        catchError(this.handleError<any>('UpdateCar'))
      );
  }

  deleteCar(id: Number): Observable<any> {
    var request = `DeleteCar/${id}`;
    return this.http.delete<any>(this._baseUrl + request)
      .pipe(
        tap(_ => console.log('DeleteCar')),
        catchError(this.handleError<any>('DeleteCar'))
      );
  }

  getCarById(id: number): Observable<any> {
    var request = `GetCarById/${id}`;
    return this.http.get<any>(this._baseUrl + request)
      .pipe(
        tap(_ => console.log('getCarById')),
        catchError(this.handleError<any>('getCarById'))
      );
  }


  getAllCars(): Observable<any> {
    var request = `GetAllCars`;
    return this.http.get<any>(this._baseUrl + request)
      .pipe(
        tap(_ => console.log('GetAllCars')),
        catchError(this.handleError<any>('GetAllCars'))
      );
  }





  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.log(error);
      return of(error as T);
    };
  }

} 
