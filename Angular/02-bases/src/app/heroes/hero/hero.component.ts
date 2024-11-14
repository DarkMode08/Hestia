import { Component } from '@angular/core';

@Component({
  selector: 'app-heroes-hero',
  templateUrl: './hero.component.html',
  styleUrl: './hero.component.css'
})
export class HeroComponent {
  public name: string = 'Ironman'
  public age: number = 22

  get capitalized():string{

    return `${this.name}`.toUpperCase();
  }

  // Metodo para juntar nombre y edad
  getHeroDescription():string {
    return `Name: ${this.name}, Age: ${this.age}.`;
  }

  changeName():void {
    this.name = 'Spiderman';
  }
  changeAge():void {
    this.age = 24;
  }
  reset():void{
    this.name = 'Ironman';
    this.age = 22;
  }
}
