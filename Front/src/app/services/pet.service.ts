import { Injectable } from '@angular/core';
import { environment } from '../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Pet } from '../interface/pet';

@Injectable({
  providedIn: 'root'
})
export class PetService {

  private MyappUrl: string = environment.endpoint;
  private MyApiUrl: string = 'api/Pet/';

  constructor(private http: HttpClient) { }

  getListPets(): Observable<Pet[]>{
   return this.http.get<Pet[]>(`${this.MyappUrl}${this.MyApiUrl}`);
  }

  getPet(id: number): Observable<Pet>{
    return this.http.get<Pet>(`${this.MyappUrl}${this.MyApiUrl}${id}`);
  }

  deletePet(id: number): Observable<any>{
    return this.http.delete(`${this.MyappUrl}${this.MyApiUrl}${id}`);
  }

  addPet(pet: Pet): Observable<Pet>{
    return this.http.post<Pet>(`${this.MyappUrl}${this.MyApiUrl}`, pet);
  }

  updatePet(id: number, pet: Pet): Observable<void>{
    return this.http.put<void>(`${this.MyappUrl}${this.MyApiUrl}${id}`, pet);
  }
}

