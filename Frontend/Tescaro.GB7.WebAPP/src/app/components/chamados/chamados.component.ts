import { Component, TemplateRef } from '@angular/core';
import { ChamadoService } from '../../services/chamado.service';
import { Chamado } from '../../models/Chamado';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from 'ngx-spinner';



@Component({
  selector: 'app-chamados',
  templateUrl: './chamados.component.html',
  styleUrls: ['./chamados.component.scss'],


})
export class ChamadosComponent {
  modalRef?: BsModalRef;

  public Chamados: any = [{
    id: '',
    numero: '',
    isAtivo: '',
    dataHoraCadastro: '',
    dataRecebimento: '',
    dataEnvioHomologacao: '',
    dataPublicacao: '',
  }];
  public ChamadosFiltrados: any = [{
    id: '',
    numero: '',
    isAtivo: '',
    dataHoraCadastro: '',
    dataRecebimento: '',
    dataEnvioHomologacao: '',
    dataPublicacao: '',
  }];

  private _filtroLista: string = '';

  public get filtroLista(): string{
    return this._filtroLista;
  }

  public set filtroLista(value: string){
    this._filtroLista = value;
    this.ChamadosFiltrados = this.filtroLista ? this.filtrarChamados(this.filtroLista) : this.Chamados;
  }

  public contemLetra(string: string, letra: string): boolean {
    let valor  =  string.toLowerCase().includes(letra.toLowerCase());
    return valor;
  }

  public filtrarChamados(filtrarPor: string): any {
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
        const dataHoraCadastroStr = chamado.dataHoraCadastro == null ? "" : chamado.dataHoraCadastro;
        const dataRecebimentoStr = chamado.dataRecebimento == null ? "" : chamado.dataRecebimento;
        const dataEnvioHomologacaoStr = chamado.dataEnvioHomologacao == null ? "" : chamado.dataEnvioHomologacao;
        const dataPublicacaoStr = chamado.dataPublicacao == null ? "" : chamado.dataPublicacao;
        return chamado.numero.toLocaleLowerCase().indexOf(filtrarPor) !== -1
          || isAtivoStr.toLocaleLowerCase().indexOf(filtrarPor) !== -1
          || dataHoraCadastroStr.indexOf(filtrarPor) !== -1
          || dataRecebimentoStr.indexOf(filtrarPor) !== -1
          || dataEnvioHomologacaoStr.indexOf(filtrarPor) !== -1
          || dataPublicacaoStr.indexOf(filtrarPor) !== -1;
      }
    );
  }

  constructor(
    private chamadoService: ChamadoService,
    private modalService: BsModalService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService
  ){}

  public ngOnInit(): void{
    this.spinner.show();
    this.getChamados();
  }



  public getChamados(): void{
    const Observer = {
      next:(_chamado: Chamado[]) => {
        this.Chamados = _chamado;
        this.ChamadosFiltrados = this.Chamados;
      },
      error: (error: any) => {
        this.spinner.hide();
        this.toastr.error('Erro ao carregar os Chamados', 'Erro!')
      },
      complete: () => this.spinner.hide()

    }

    this.chamadoService.getTodosChamados().subscribe(Observer);



  }


  // Modal

  message?: string;

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  confirm(): void {
    this.modalRef?.hide();
    this.toastr.success('Chamado excluído com sucesso', 'Deletado!')
  }

  decline(): void {
    this.modalRef?.hide();
  }

}
