import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { BsLocaleService } from 'ngx-bootstrap/datepicker';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Chamado } from 'src/app/models/Chamado';
import { ChamadoService } from 'src/app/services/chamado.service';


@Component({
  selector: 'app-chamado-editar',
  templateUrl: './chamado-editar.component.html',
  styleUrls: ['./chamado-editar.component.scss']
})
export class ChamadoEditarComponent implements OnInit {

  chamado = {} as Chamado;
  chamadoForm!: FormGroup;

  constructor(private fb: FormBuilder,
    private localeService: BsLocaleService,
    private router: ActivatedRoute,
    private chamadoService: ChamadoService,
    private spinner: NgxSpinnerService,
    private toastr: ToastrService)
    {
      this.localeService.use('pt-br');
    }

    public salvarAlteracao(): void{
      this.spinner.show();
    }

    public carregamentoChamado(): void{
      const chamadoIdParam = this.router.snapshot.paramMap.get('id');

      if(chamadoIdParam != null){
        this.spinner.show();
        this.chamadoService.getChamadoById(+chamadoIdParam).subscribe(
          {
            next: (chamado: Chamado) => {
                                        this.chamado = {...chamado};
                                        this.chamadoForm.patchValue(this.chamado);
                                        },
            error: () => {
              this.spinner.hide();
              this.toastr.error("Erro ao carregar o Chamado.", "Erro!")
            },
            complete:  () => {
              this.spinner.hide();
            }
          });
      }

    }

    ngOnInit(): void {
    this.carregamentoChamado();
    this.chamadoForm = new FormGroup({
            id: new FormControl(''),
            numero: new FormControl('',[Validators.required]),
            dataRecebimento: new FormControl('',[Validators.required]),
            dns: new FormControl('',[Validators.required]),
            bancoDados: new FormControl('',[Validators.required]),
            cliente: new FormControl('',[Validators.required]),
            dataEnvioHomologacao: new FormControl(''),
            dataPublicacao: new FormControl(''),
            observacao: new FormControl(''),
            scriptText: new FormControl(''),
      });
  }

  get numero(){
    return this.chamadoForm.get('numero')!;
  }

  get cliente(){
    return this.chamadoForm.get('cliente')!;
  }

  get dns(){
    return this.chamadoForm.get('dns')
  }

  get bancoDados(){
    return this.chamadoForm.get('bancoDados')
  }

  get dataRecebimento(){
    return this.chamadoForm.get('dataRecebimento')
  }

  submit(){
    if(this.chamadoForm.invalid){
      return;
    }
    console.log('Criado Formulário')
  }

   resetForm(event: any): void{
    event.preventDefault();
    this.chamadoForm.reset();
  }

  get bsConfig(): any{
    return {
      adaptivePosition: true,
      dateInputFormat: 'DD/MM/YYYY',
      containerClass: 'theme-orange',
      showWeekNumbers: false
     }
  }

  

}

