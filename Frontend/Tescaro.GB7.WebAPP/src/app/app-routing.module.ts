import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BancosDadosComponent } from './components/bancosDados/bancosDados/bancosDados.component';
import { ChamadosComponent } from './components/chamados/chamados.component';
import { ClientesComponent } from './components/clientes/clientes.component';
import { DNSsComponent } from './components/dns/dns/dns.component';
import { PerfilComponent } from './components/perfil/perfil/perfil.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';

const routes: Routes = [
  {path: "bancoDados", component: BancosDadosComponent},
  {path: "dashboard", component: DashboardComponent},
  {path: "chamados", component: ChamadosComponent},
  {path: "clientes", component: ClientesComponent},
  {path: "dns", component: DNSsComponent},
  {path: "perfil", component: PerfilComponent},
  {path: '', redirectTo: 'dashboard', pathMatch: 'full'},
  {path: '**', redirectTo: 'dashboard', pathMatch: 'full'},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
