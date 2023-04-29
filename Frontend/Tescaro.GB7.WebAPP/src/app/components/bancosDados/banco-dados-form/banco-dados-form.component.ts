import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-banco-dados-form',
  templateUrl: './banco-dados-form.component.html',
  styleUrls: ['./banco-dados-form.component.scss']
})
export class BancoDadosFormComponent implements OnInit {

  bancoDadosForm!: FormGroup;

  constructor(private fb: FormBuilder){}

    ngOnInit(): void {
    this.bancoDadosForm = new FormGroup({
            id: new FormControl(''),
            nome: new FormControl('', Validators.required),
            cliente: new FormControl('', Validators.required),

      });
  }

  get nome(){
    return this.bancoDadosForm.get('nome')!;
  }

  get cliente(){
    return this.bancoDadosForm.get('cliente')!;
  }

  submit(){
    if(this.bancoDadosForm.invalid){
      return;
    }
    console.log('Criado Formulário')
  }

   resetForm(event: any): void{
    event.preventDefault();
    this.bancoDadosForm.reset();
  }


}
