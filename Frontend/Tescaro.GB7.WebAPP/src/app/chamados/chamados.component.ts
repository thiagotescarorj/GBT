import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-chamados',
  templateUrl: './chamados.component.html',
  styleUrls: ['./chamados.component.scss']
})
export class ChamadosComponent {

  public Chamados: any = [];
  public ChamadosFiltrados: any = [];

  private _filtroLista: string = '';

  public get filtroLista(): string{
    return this._filtroLista;
  }

  public set filtroLista(value: string){
    this._filtroLista = value;
    this.ChamadosFiltrados = this.filtroLista ? this.filtrarChamados(this.filtroLista) : this.Chamados;
  }

  contemLetra(string: string, letra: string): boolean {
    let valor  =  string.toLowerCase().includes(letra.toLowerCase());
    return valor;
  }

  filtrarChamados(filtrarPor: string): any {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.Chamados.filter(
      (chamado: {
        numero: string,
        isAtivo: boolean,
        dataHoraCadastro: string,
        dataRecebimento: string,
        dataEnvioHomologacao: string,
        dataPublicacao: string
      }) => {
        const isAtivoStr = chamado.isAtivo ? "Ativo" : "Inativo";
        return chamado.numero.toLocaleLowerCase().indexOf(filtrarPor) !== -1
          || isAtivoStr.toLocaleLowerCase().indexOf(filtrarPor) !== -1
          || chamado.dataHoraCadastro.toLocaleLowerCase().indexOf(filtrarPor) !== -1
          || chamado.dataRecebimento.toLocaleLowerCase().indexOf(filtrarPor) !== -1
          || chamado.dataPublicacao.toLocaleLowerCase().indexOf(filtrarPor) !== -1;
      }
    );
  }





  constructor(private http: HttpClient){}

  ngOnInit(): void{
    this.getChamados();
  }

  public getChamados(): void{
    this.http.get('https://localhost:7276/api/Chamado').subscribe(
      response => {
        this.Chamados = response;
        this.ChamadosFiltrados = this.Chamados;
      },
          error => console.log(error)
    );


  }

}
