import { Component, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Cliente } from 'src/app/models/Cliente';
import { ClienteService } from 'src/app/services/cliente.service';

@Component({
  selector: 'app-cliente-lista',
  templateUrl: './cliente-lista.component.html',
  styleUrls: ['./cliente-lista.component.scss']
})
export class ClienteListaComponent {

  modalRef?: BsModalRef;

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

  public contemLetra(string: string, letra: string): boolean {
    let valor  =  string.toLowerCase().includes(letra.toLowerCase());
    return valor;
  }

  public filtrarClientes(filtrarPor: string): any {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.Clientes.filter(
      (cliente: {
        nome: string,
        isAtivo: boolean,
        dataHoraCadastro: string,
      }) => {
        const isAtivoStr = cliente.isAtivo ? "Ativo" : "Inativo";
        const dataHoraCadastroStr = cliente.dataHoraCadastro == null ? "" : cliente.dataHoraCadastro;
        return cliente.nome.toLocaleLowerCase().indexOf(filtrarPor) !== -1
          || isAtivoStr.toLocaleLowerCase().indexOf(filtrarPor) !== -1
          || dataHoraCadastroStr.indexOf(filtrarPor) !== -1;
      }
    );
  }

  constructor(
    private clienteService: ClienteService,
    private modalService: BsModalService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService,
    private router: Router
  ){}

  public ngOnInit(): void{
    this.spinner.show();
    this.getClientes();
  }



  public getClientes(): void{
    const Observer = {
      next:(_cliente: Cliente[]) => {
        this.Clientes = _cliente;
        this.ClientesFiltrados = this.Clientes;
      },
      error: (error: any) => {
        this.spinner.hide();
        this.toastr.error('Erro ao carregar os Clientes', 'Erro!')
      },
      complete: () => this.spinner.hide()

    }

    this.clienteService.getTodosClientes().subscribe(Observer);



  }


  // Modal

  message?: string;

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  confirm(): void {
    this.modalRef?.hide();
    this.toastr.success('Cliente excluído com sucesso', 'Deletado!')
  }

  decline(): void {
    this.modalRef?.hide();
  }

  detalheCliente(id: number): void{
    this.router.navigate([`clientes/detalhe/${id}`]);
  }


}
