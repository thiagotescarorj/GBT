import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BancosDadosComponent } from './components/bancosDados/bancosDados/bancosDados.component';
import { ChamadosComponent } from './components/chamados/chamados.component';
import { ClientesComponent } from './components/clientes/clientes.component';
import { DNSsComponent } from './components/dns/dns/dns.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { ChamadoDetalheComponent } from './components/chamados/chamado-detalhe/chamado-detalhe.component';
import { ChamadoFormComponent } from './components/chamados/chamado-form/chamado-form.component';
import { ChamadoListaComponent } from './components/chamados/chamado-lista/chamado-lista.component';
import { ChamadoEditarComponent } from './components/chamados/chamado-editar/chamado-editar.component';
import { UserComponent } from './components/user/user.component';
import { LoginComponent } from './components/user/login/login.component';
import { RegisterComponent } from './components/user/register/register.component';
import { PerfilComponent } from './components/user/perfil/perfil/perfil.component';

const routes: Routes = [
  {path: "user", component: UserComponent,
    children:[
      {path: "login", component: LoginComponent},
      {path: "register", component: RegisterComponent},

    ]
  },
  {path: "bancoDados", component: BancosDadosComponent},
  {path: "dashboard", component: DashboardComponent},
  {path: "chamados", redirectTo: 'chamados/lista'},
  {path: "chamados", component: ChamadosComponent,
   children:[
    {path: 'detalhe/:id', component: ChamadoDetalheComponent},
    {path: 'form', component: ChamadoFormComponent},
    {path: 'lista', component: ChamadoListaComponent},
    {path: 'editar/:id', component: ChamadoEditarComponent},
   ]
  },
  {path: "clientes", component: ClientesComponent},
  {path: "dns", component: DNSsComponent},
  {path: "user/perfil", component: PerfilComponent},
  {path: '', redirectTo: 'dashboard', pathMatch: 'full'},
  {path: '**', redirectTo: 'dashboard', pathMatch: 'full'},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
