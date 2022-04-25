import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ContatosComponent } from './Components/Contatos/Contatos.component';
import { DashboardComponent } from './Components/Dashboard/Dashboard.component';
import { EventosComponent } from './Components/Eventos/eventos.component';
import { PalestrantesComponent } from './Components/palestrantes/palestrantes.component';
import { PerfilComponent } from './Components/Perfil/Perfil.component';

const routes: Routes = [
  {  path: 'eventos', component: EventosComponent},
  {  path: 'dashboard', component: DashboardComponent},
  { path: 'perfil', component: PerfilComponent},
  {path: 'palestrantes', component: PalestrantesComponent},
  {path: 'contatos', component: ContatosComponent},
  {path: '', redirectTo: 'dashboard', pathMatch: 'full'},
  {path: '**', redirectTo: 'dashboard', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
