import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';

const routes: Routes = [{
  path: '', loadChildren: () => import('./components/home/home.module').then(m => m.HomeModule)
},
{
  path: 'departamentos', loadChildren: () => import('./components/departamentos/departamentos.module').then(m => m.DepartamentosModule)
}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
