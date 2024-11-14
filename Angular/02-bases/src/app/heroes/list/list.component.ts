import { Component } from '@angular/core';

@Component({
  selector: 'app-heroes-list',
  templateUrl: './list.component.html',
  styleUrl: './list.component.css'
})
export class ListComponent {
  public heroNames:string[] = ['Spiderman', 'Ironman', 'Thor'];
  public _deleteHero?:string;

  removeLastHero():void {
    this._deleteHero = this.heroNames.pop();
  }
}
