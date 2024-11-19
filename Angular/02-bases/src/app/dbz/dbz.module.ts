import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MainPageDBZComponent } from './pages/main-page.component';
import { ListDBZComponent } from './components/list/list.component';
import { AddCharacterComponent } from './components/add/add.component';



@NgModule({
  declarations: [
    MainPageDBZComponent,
    ListDBZComponent,
    AddCharacterComponent
  ],
  exports:[
    MainPageDBZComponent,
    ListDBZComponent,
    AddCharacterComponent
  ],
  imports: [
    CommonModule
  ]
})
export class DbzModule { }
