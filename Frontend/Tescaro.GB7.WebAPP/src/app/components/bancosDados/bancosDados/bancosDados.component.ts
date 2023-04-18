import { Component } from '@angular/core';
import { BancoDadosService } from 'src/app/services/bancoDados.service';

@Component({
  selector: 'app-bancosDados',
  templateUrl: './bancosDados.component.html',
  styleUrls: ['./bancosDados.component.scss']
})
export class BancosDadosComponent {

  public BancosDados: any = [{
    id: '',
    nome: '',
    isAtivo: '',
    dataHoraCadastro: '',
  }];
  public BancosDadosFiltrados: any = [{
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
    this.BancosDadosFiltrados = this.filtroLista ? this.filtrarBancosDados(this.filtroLista) : this.BancosDados;
  }

  contemLetra(string: string, letra: string): boolean {
    let valor  =  string.toLowerCase().includes(letra.toLowerCase());
    return valor;
  }

  filtrarBancosDados(filtrarPor: string): any {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.BancosDados.filter(
      (bancosDado: {
        nome: string,
        isAtivo: boolean,
        dataHoraCadastro: string,
      }) => {
        const isAtivoStr = bancosDado.isAtivo ? "Ativo" : "Inativo";
        return bancosDado.nome.toLocaleLowerCase().indexOf(filtrarPor) !== -1
          || isAtivoStr.toLocaleLowerCase().indexOf(filtrarPor) !== -1
          || bancosDado.dataHoraCadastro.indexOf(filtrarPor) !== -1;
      }
    );
  }




  constructor( private bancosDadoService: BancoDadosService){}

  ngOnInit(): void{
    this.getBancosDados();
  }

  public getBancosDados(): void{
    this.bancosDadoService.getTodosBancosDados().subscribe(
      response => {
        //this.BancosDados = response;
        //this.BancosDadosFiltrados = this.BancosDados;
      },
          error => console.log(error)
    );


  }

}
