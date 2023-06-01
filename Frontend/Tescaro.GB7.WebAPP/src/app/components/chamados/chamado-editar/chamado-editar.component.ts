import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { BsLocaleService } from 'ngx-bootstrap/datepicker';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Chamado } from 'src/app/models/Chamado';
import { ChamadoService } from 'src/app/services/chamado.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-chamado-editar',
  templateUrl: './chamado-editar.component.html',
  styleUrls: ['./chamado-editar.component.scss']
})
export class ChamadoEditarComponent implements OnInit {
  
  chamado = {} as Chamado;
  chamadoForm!: FormGroup;
  router2: Router;
  
  
  constructor(private fb: FormBuilder,
    private localeService: BsLocaleService,
    private router: ActivatedRoute,
    private chamadoService: ChamadoService,
    private spinner: NgxSpinnerService,
    private toastr: ToastrService,
    router2: Router)
    {
      this.localeService.use('pt-br');
      this.router2 = router2;
      
    }
    
    public salvar(): void{
      this.spinner.show();
  
        
        this.chamado = {... this.chamadoForm.value};


        this.chamadoService.post(this.chamado).subscribe(
          () => this.toastr.success("Chamado salvo com sucesso!", "Sucesso"),
          (error: any) => {
            console.log(error);
            this.spinner.hide();
            this.toastr.error("Erro ao salvar Chamado", "Erro");
          },
          () => this.spinner.hide()
        );

        this.router2.navigateByUrl('/chamados/lista');       

      
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
      
      get clienteId(){
        return this.chamadoForm.get('clienteId')!;
      }
      
      get dnsId(){
        return this.chamadoForm.get('dnsId')
      }
      
      get bancoDadosId(){
        return this.chamadoForm.get('bancoDadosId')
      }
      
      get dataRecebimento(){
        return this.chamadoForm.get('dataRecebimento')
      }

      get dataEnvioHomologacao(){
        return this.chamadoForm.get('dataEnvioHomologacao')!;
      }
    
      get dataPublicacao(){
        return this.chamadoForm.get('dataPublicacao')!;
      }
    
      get observacao(){
        return this.chamadoForm.get('observacao')!;
      }
    
      get scriptText(){
        return this.chamadoForm.get('scriptText')!;
      }
      
      submit(){
        if(this.chamadoForm.invalid){
          return;
        }
        console.log('Atualizado Formulário')
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
    
    