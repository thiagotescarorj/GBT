import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from './app-routing.module';

import { CollapseModule } from 'ngx-bootstrap/collapse';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { ModalModule } from 'ngx-bootstrap/modal';
import { ToastrModule } from 'ngx-toastr';
import { NgxSpinnerModule } from 'ngx-spinner';

import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { defineLocale } from 'ngx-bootstrap/chronos';
import { ptBrLocale } from 'ngx-bootstrap/locale';


import { AppComponent } from './app.component';
import { ChamadosComponent } from './components/chamados/chamados.component';
import { ClientesComponent } from './components/clientes/clientes.component';
import { NavegacaoComponent } from './shared/navegacao/navegacao.component';
import { DNSsComponent } from './components/dns/dns/dns.component';
import { BancosDadosComponent } from './components/bancosDados/bancosDados/bancosDados.component';
import { TituloComponent } from './shared/titulo/titulo.component';

import { ChamadoService } from './services/chamado.service';
import { BancoDadosService } from './services/bancoDados.service';
import { DNSService } from './services/dns.service';

import { ClienteService } from './services/cliente.service';


import { DateTimeFormatPipe } from './helpers/DateTimeFormat.pipe';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { ChamadoDetalheComponent } from './components/chamados/chamado-detalhe/chamado-detalhe.component';
import { ChamadoListaComponent } from './components/chamados/chamado-lista/chamado-lista.component';
import { ChamadoFormComponent } from './components/chamados/chamado-form/chamado-form.component';
import { ChamadoEditarComponent } from './components/chamados/chamado-editar/chamado-editar.component';
import { UserComponent } from './components/user/user.component';
import { LoginComponent } from './components/user/login/login.component';
import { RegisterComponent } from './components/user/register/register.component';
import { PerfilComponent } from './components/user/perfil/perfil/perfil.component';
import { ClienteDetalheComponent } from './components/clientes/cliente-detalhe/cliente-detalhe.component';
import { ClienteEditarComponent } from './components/clientes/cliente-editar/cliente-editar.component';
import { ClienteFormComponent } from './components/clientes/cliente-form/cliente-form.component';
import { ClienteListaComponent } from './components/clientes/cliente-lista/cliente-lista.component';
import { DnsDetalheComponent } from './components/dns/dns-detalhe/dns-detalhe.component';
import { DnsEditarComponent } from './components/dns/dns-editar/dns-editar.component';
import { DnsFormComponent } from './components/dns/dns-form/dns-form.component';
import { DnsListaComponent } from './components/dns/dns-lista/dns-lista.component';
import { BancoDadosListaComponent } from './components/bancosDados/banco-dados-lista/banco-dados-lista.component';
import { BancoDadosEditarComponent } from './components/bancosDados/banco-dados-editar/banco-dados-editar.component';
import { BancoDadosDetalheComponent } from './components/bancosDados/banco-dados-detalhe/banco-dados-detalhe.component';
import { BancoDadosFormComponent } from './components/bancosDados/banco-dados-form/banco-dados-form.component';

defineLocale('pt-br', ptBrLocale);


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
    ChamadoDetalheComponent,
    ChamadoListaComponent,
    ChamadoFormComponent,
    ChamadoEditarComponent,
    UserComponent,
    LoginComponent,
    RegisterComponent,
    ClienteDetalheComponent,
    ClienteEditarComponent,
    ClienteFormComponent,
    ClienteListaComponent,
    DnsDetalheComponent,
    DnsEditarComponent,
    DnsFormComponent,
    DnsListaComponent,
    BancoDadosListaComponent,
    BancoDadosEditarComponent,
    BancoDadosDetalheComponent,
    BancoDadosFormComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
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
    NgxSpinnerModule,
    BsDatepickerModule.forRoot(),


  ],

  providers: [ChamadoService, ClienteService, DNSService, BancoDadosService],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
})
export class AppModule { }

