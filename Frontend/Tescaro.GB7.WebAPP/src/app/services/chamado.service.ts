import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Chamado } from '../models/Chamado';

@Injectable()
export class ChamadoService {

  baseURL = 'https://localhost:7276/api/Chamado';

  constructor(private http: HttpClient) { }

   getTodosChamados(): Observable<Chamado[]>{
    return this.http.get<Chamado[]>(this.baseURL);
  }

  getChamadoById(id: number): Observable<Chamado>{
    return this.http.get<Chamado>(`${this.baseURL}/${id}`);
  }

  getChamadosByNumero(numero: string): Observable<Chamado[]>{
    return this.http.get<Chamado[]>(`${this.baseURL}/${numero}`)
  }


  getChamadosByCliente(clienteId: number): Observable<Chamado[]>{
    return this.http.get<Chamado[]>(`${this.baseURL}/${clienteId}`)
  }


  getChamadosByDNS(dnsId: number): Observable<Chamado[]>{
    return this.http.get<Chamado[]>(`${this.baseURL}/${dnsId}`)
  }


  getChamadosByBancoDados(bancoDadosId: number): Observable<Chamado[]>{
    return this.http.get<Chamado[]>(`${this.baseURL}/${bancoDadosId}`)
  }

}
