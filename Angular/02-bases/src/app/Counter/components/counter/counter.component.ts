import { Component} from '@angular/core';

@Component({
    selector: 'app-counter',
    template: `
    <p>//Counter.Component</p>
    <h4> {{ Counter }} </h4>

    <button (click)="increaseBy(-1)">-1</button>
    <button (click)="resetCounter()">Reset</button>
    <button (click)="increaseBy(+1)">1+</button>
`
})

export class CounterComponent {
    public title:string = 'Hi!';
    public Counter:number = 0;

    increaseBy(value:number):void{
    this.Counter += value;
    }

    resetCounter():void{
    this.Counter = 0;
  }
}