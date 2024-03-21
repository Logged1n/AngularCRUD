import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Observable, throwError } from "rxjs";
import { catchError, switchMap } from "rxjs/operators";

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  apiUrl = 'https://localhost:7120/api/';
  photoApiKey = "4iFKIHhwv7SVWb";
  photoUrl = "https://api.multiavatar.com/";

  constructor(private _http: HttpClient) { }

  addEmployee(data: any): Observable<any> {
    return this._http.get(this.photoUrl + data.firstName + data.lastName + "/?apikey=" + this.photoApiKey, { responseType: 'text' }).pipe(
      switchMap(svgResponse => {
        // Przypisz string SVG do data.photoSVG
        data.photoSVG = svgResponse;
        // Wyślij dane do serwera
        return this._http.post(this.apiUrl + 'Employee/AddEmployee', data, {
          headers: {
            'Content-Type': 'application/json',
            'Accept': 'application/json'
          }
        });
      }),
      catchError(error => {
        console.error('Wystąpił błąd: ', error);
        return throwError(error);
      })
    );
  }

  updateEmployee(data: any) {
    return this._http.put(this.apiUrl + 'Employee/UpdateEmployee', data, {
      headers: {
        'Content-Type': 'application/json',
        'Accept': 'application/json'
      }
    })
  }

  getEmployeeList(): Observable<any> {
    return this._http.get(this.apiUrl + 'Employee/GetEmployee');
  }

  deleteEmployee(id: number): Observable<any> {
    return this._http.delete(this.apiUrl + `Employee/DeleteEmployee/${id}`);
  }
}
