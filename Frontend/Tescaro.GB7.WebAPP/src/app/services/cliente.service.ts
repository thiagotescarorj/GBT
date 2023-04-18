import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Cliente } from '../models/Cliente';

@Injectable()
export class ClienteService {

  baseURL = 'https://localhost:7276/api/Cliente';

  constructor(private http: HttpClient) { }

  getTodosClientes(): Observable<Cliente[]>{
    return this.http.get<Cliente[]>(this.baseURL);
  }

  getClienteById(id: number): Observable<Cliente>{
    return this.http.get<Cliente>(`${this.baseURL}/${id}`);
  }

  getClienteByNome(nome: string): Observable<Cliente>{
    return this.http.get<Cliente>(`${this.baseURL}/${nome}`);
  }

}
