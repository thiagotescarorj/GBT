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

  // form = new FormGroup({
  //       numero: new FormControl(''),
  //       isAtivo: new FormControl(''),
  //       dataHoraCadastro: new FormControl(''),
  //       dataRecebimento: new FormControl(''),
  //       dataEnvioHomologacao: new FormControl(''),
  //       dataPublicacao: new FormControl(''),
  //       observacao: new FormControl(''),
  //       scriptText: new FormControl(''),
  //       cliente: new FormControl(''),
  //       dns: new FormControl(''),
  //       bancoDados: new FormControl(''),
  // });

//   form = this.fb.group({
//     numero: ['', Validators.required],
//     cliente: ['', Validators.required],
//     dns: ['', Validators.required],
//     bancoDados: ['', Validators.required],
//     dataRecebimento: ['', Validators.required],
//     isAtivo: [''],
//     dataHoraCadastro: [''],
//     dataEnvioHomologacao: [''],
//     dataPublicacao: [''],
//     observacao: [''],
//     scriptText: [''],
// });

  ngOnInit(): void {
    this.chamadoForm = new FormGroup({
            id: new FormControl(''),
            numero: new FormControl('',[Validators.required]),
            dataRecebimento: new FormControl('',[Validators.required]),
            dns: new FormControl('',[Validators.required]),
            bancoDados: new FormControl('',[Validators.required]),
            cliente: new FormControl('',[Validators.required]),
            isAtivo: new FormControl(''),
            dataHoraCadastro: new FormControl(''),
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

   resetForm(){
    this.chamadoForm.reset();
  }

}
