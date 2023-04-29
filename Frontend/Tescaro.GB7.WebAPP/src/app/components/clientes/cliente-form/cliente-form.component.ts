import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-cliente-form',
  templateUrl: './cliente-form.component.html',
  styleUrls: ['./cliente-form.component.scss']
})
export class ClienteFormComponent implements OnInit {

  clienteForm!: FormGroup;

  constructor(private fb: FormBuilder){}

    ngOnInit(): void {
    this.clienteForm = new FormGroup({
            id: new FormControl(''),
            nome: new FormControl('', Validators.required),

      });
  }

  get nome(){
    return this.clienteForm.get('nome')!;
  }

  submit(){
    if(this.clienteForm.invalid){
      return;
    }
    console.log('Criado Formulário')
  }

   resetForm(event: any): void{
    event.preventDefault();
    this.clienteForm.reset();
  }

}
