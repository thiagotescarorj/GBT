import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-chamado-form',
  templateUrl: './chamado-form.component.html',
  styleUrls: ['./chamado-form.component.scss']
})
export class ChamadoFormComponent implements OnInit {

  chamadoForm!: FormGroup;

  constructor(private fb: FormBuilder){}

    ngOnInit(): void {
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
    return this.chamadoForm.get('bancoDados')
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

}
