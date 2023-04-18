import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from './app-routing.module';

import { CollapseModule } from 'ngx-bootstrap/collapse';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { ModalModule } from 'ngx-bootstrap/modal';
import { ToastrModule } from 'ngx-toastr';
import { NgxSpinnerModule } from 'ngx-spinner';


import { AppComponent } from './app.component';
import { ChamadosComponent } from './components/chamados/chamados.component';
import { ClientesComponent } from './components/clientes/clientes.component';
import { NavegacaoComponent } from './shared/navegacao/navegacao.component';
import { DNSsComponent } from './components/dns/dns/dns.component';
import { BancosDadosComponent } from './components/bancosDados/bancosDados/bancosDados.component';
import { PerfilComponent } from './components/perfil/perfil/perfil.component';
import { TituloComponent } from './shared/titulo/titulo.component';

import { ChamadoService } from './services/chamado.service';
import { BancoDadosService } from './services/bancoDados.service';
import { DNSService } from './services/dns.service';

import { ClienteService } from './services/cliente.service';


import { DateTimeFormatPipe } from './helpers/DateTimeFormat.pipe';
import { DashboardComponent } from './components/dashboard/dashboard.component';



@NgModule({
  declarations: [
    AppComponent,
    ChamadosComponent,
    ClientesComponent,
    DNSsComponent,
    BancosDadosComponent,
    PerfilComponent,
    NavegacaoComponent,
    TituloComponent,
    DashboardComponent,
    DateTimeFormatPipe,
   ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule,
    CollapseModule.forRoot(),
    TooltipModule.forRoot(),
    BsDropdownModule.forRoot(),
    ModalModule.forRoot(),
    ToastrModule.forRoot({
      timeOut: 5000,
      positionClass: 'toast-bottom-right',
      preventDuplicates: true,
      progressBar: true
    }),
    NgxSpinnerModule

  ],

  providers: [ChamadoService, ClienteService, DNSService, BancoDadosService],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
})
export class AppModule { }
