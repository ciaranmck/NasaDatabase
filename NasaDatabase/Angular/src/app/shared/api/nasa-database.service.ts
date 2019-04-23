import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import Fireball from '../models/Fireball';

@Injectable()
export class NasaDatabaseService {
  public api = 'http://localhost:8080/api';

  constructor(private http: HttpClient) {}

  public getAllFireballs(): Observable<Fireball[]> {
    return this.http.get<Fireball[]>(`${this.api}/allFireballData`);
  }

//   public get(id: number) {
//     return this.http.get(`${this.Fireball_API}/${id}`);
//   }

//   save(fireball: Fireball): Observable<Fireball> {
//     let result: Observable<Fireball>;
//     if (fireball.id) {
//       result = this.http.put<Fireball>(
//         `${this.Fireball_API}/${fireball.id}`,
//         fireball
//       );
//     } else {
//       result = this.http.post<Fireball>(this.Fireball_API, fireball);
//     }
//     return result;
//   }

//   remove(id: number) {
//     return this.http.delete(`${this.Fireball_API}/${id.toString()}`);
//   }
}
