import { NgModule, Component } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PortfolioComponent } from './pages/portfolio/portfolio.component';
import { AboutComponent } from './pages/about/about.component';
import { ItemComponent } from './pages/item/item.component';

const routes: Routes = [
  // Comillas Vacias Para Especificar la Ruta Inicial.
  { path: 'home', component: PortfolioComponent },
  { path: 'about', component: AboutComponent},
  { path: 'item', component: ItemComponent },
  // ** Para cualquier otra ruta no especificada sera dirigida a esto.
  { path: '**', pathMatch: 'full', redirectTo: 'home' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
