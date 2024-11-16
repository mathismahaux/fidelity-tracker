import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GiftService {
  private apiUrl = 'http://localhost:5000/gifts';

  constructor(private http: HttpClient) { }

  getGifts(): Observable<any> {
    return this.http.get(`${this.apiUrl}`);
  }

  createGift(name: string): Observable<any> {
    return this.http.post(`${this.apiUrl}/create-gift`, { name });
  }
}
