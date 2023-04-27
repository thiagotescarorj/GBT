import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BancoDados } from '../models/BancoDados';

@Injectable()
export class BancoDadosService {

  baseURL = 'https://localhost:7276/api/BancoDados/';

  constructor(private http: HttpClient) { }

  getTodosBancosDados(): Observable<BancoDados[]>{
    return this.http.get<BancoDados[]>(this.baseURL);
  }

  getBancoDadosById(id: number): Observable<BancoDados>{
    return this.http.get<BancoDados>(`${this.baseURL}/${id}`);
  }

  getBancoDadossByNumero(nome: string): Observable<BancoDados[]>{
    return this.http.get<BancoDados[]>(`${this.baseURL}/${nome}`)
  }


  getBancoDadossByCliente(clienteId: number): Observable<BancoDados[]>{
    return this.http.get<BancoDados[]>(`${this.baseURL}/${clienteId}`)
  }
}
