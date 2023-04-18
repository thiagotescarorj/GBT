import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { DNS } from '../models/DNS';

@Injectable()
export class DNSService {

  baseURL = 'https://localhost:7276/api/DNS';

  constructor(private http: HttpClient) { }


  getTodosDNSs(): Observable<DNS[]>{
    return this.http.get<DNS[]>(this.baseURL);
  }

  getDNSsByCliente(clienteId: number): Observable<DNS[]>{
    return this.http.get<DNS[]>(`${this.baseURL}/${clienteId}`)
  }
}
