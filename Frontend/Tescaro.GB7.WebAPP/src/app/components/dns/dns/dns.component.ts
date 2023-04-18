import { Component } from '@angular/core';
import { DNSService } from 'src/app/services/dns.service';


@Component({
  selector: 'app-dnss',
  templateUrl: './dns.component.html',
  styleUrls: ['./dns.component.scss']
})
export class DNSsComponent {

  public DNSs: any = [{
    id: '',
    nome: '',
    isAtivo: '',
    dataHoraCadastro: '',
  }];
  public DNSsFiltrados: any = [{
    id: '',
    nome: '',
    isAtivo: '',
    dataHoraCadastro: '',
  }];

  private _filtroLista: string = '';

  public get filtroLista(): string{
    return this._filtroLista;
  }

  public set filtroLista(value: string){
    this._filtroLista = value;
    this.DNSsFiltrados = this.filtroLista ? this.filtrarDNSs(this.filtroLista) : this.DNSs;
  }

  contemLetra(string: string, letra: string): boolean {
    let valor  =  string.toLowerCase().includes(letra.toLowerCase());
    return valor;
  }

  filtrarDNSs(filtrarPor: string): any {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.DNSs.filter(
      (dns: {
        nome: string,
        isAtivo: boolean,
        dataHoraCadastro: string,
      }) => {
        const isAtivoStr = dns.isAtivo ? "Ativo" : "Inativo";
        return dns.nome.toLocaleLowerCase().indexOf(filtrarPor) !== -1
          || isAtivoStr.toLocaleLowerCase().indexOf(filtrarPor) !== -1
          || dns.dataHoraCadastro.indexOf(filtrarPor) !== -1;
      }
    );
  }




  constructor( private dnsService: DNSService){}

  ngOnInit(): void{
    this.getDNSs();
  }

  public getDNSs(): void{
    this.dnsService.getTodosDNSs().subscribe(
      response => {
        //this.DNSs = response;
        //this.DNSsFiltrados = this.DNSs;
      },
          error => console.log(error)
    );


  }

}
