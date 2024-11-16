import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PersonService {
  private apiUrl = 'http://localhost:5000/people';

  constructor(private http: HttpClient) { }

  getPeople(): Observable<any> {
    return this.http.get(`${this.apiUrl}`);
  }

  searchByName(name: string) {
    return this.http.get(`${this.apiUrl}/search-by-name`, {
      params: {name}
    });
  }

  getDetailsById(id: number): Observable<any> {
    return this.http.get(`${this.apiUrl}/get-details`, {
      params: {id}
    })
  }

  createPerson(name: string, idSponsor: number | null): Observable<any> {
    return this.http.post(`${this.apiUrl}/create-person`, { name, idSponsor });
  }

  assignSponsor(personId: number, sponsorId: number): Observable<boolean> {
    return this.http.patch<boolean>(`${this.apiUrl}/assign-sponsor`, { personId, sponsorId });
  }

  giveGift(idSponsor: number, idGift: number): Observable<any> {
    return this.http.post(`${this.apiUrl}/give-gift`, {sponsorId: idSponsor, giftId: idGift}, {
      responseType: 'text',
    });
  }
}
