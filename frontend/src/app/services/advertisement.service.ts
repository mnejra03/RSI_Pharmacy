/*import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AdvertisementService {
  private apiUrl = 'http://localhost:5077/api/Advertisements';

  constructor(private http: HttpClient) {}

  getAdvertisements(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl);
  }

  getAdvertisementById(id: number): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/${id}`);
  }
}*/
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AdvertisementService {
  private apiUrl = 'https://localhost:5077/api/GetAdvertisementEndpoint'; // Promeni URL ako je drugačiji

  constructor(private http: HttpClient) {}

   getAdvertisementById(id: number): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/${id}`);
  }

}
