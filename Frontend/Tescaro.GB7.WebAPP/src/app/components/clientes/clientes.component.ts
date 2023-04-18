import { Component } from '@angular/core';
import { ClienteService } from '../../services/cliente.service';

@Component({
  selector: 'app-clientes',
  templateUrl: './clientes.component.html',
  styleUrls: ['./clientes.component.scss']
})
export class ClientesComponent {

  public Clientes: any = [{
    id: '',
    nome: '',
    isAtivo: '',
    dataHoraCadastro: '',
  }];
  public ClientesFiltrados: any = [{
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
    this.ClientesFiltrados = this.filtroLista ? this.filtrarClientes(this.filtroLista) : this.Clientes;
  }

  contemLetra(string: string, letra: string): boolean {
    let valor  =  string.toLowerCase().includes(letra.toLowerCase());
    return valor;
  }

  filtrarClientes(filtrarPor: string): any {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.Clientes.filter(
      (cliente: {
        nome: string,
        isAtivo: boolean,
        dataHoraCadastro: string,
      }) => {
        const isAtivoStr = cliente.isAtivo ? "Ativo" : "Inativo";
        return cliente.nome.toLocaleLowerCase().indexOf(filtrarPor) !== -1
          || isAtivoStr.toLocaleLowerCase().indexOf(filtrarPor) !== -1
          || cliente.dataHoraCadastro.indexOf(filtrarPor) !== -1;
      }
    );
  }




  constructor( private clienteService: ClienteService){}

  ngOnInit(): void{
    this.getClientes();
  }

  public getClientes(): void{
    this.clienteService.getTodosClientes().subscribe(
      response => {
        //this.Clientes = response;
        //this.ClientesFiltrados = this.Clientes;
      },
          error => console.log(error)
    );


  }

}
