import { Character } from './../interfaces/character.interface';
import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'app-dbz-main-page',
    templateUrl: 'main-page.component.html'
})

export class MainPageDBZComponent {
    public characters: Character[] = [{
        name: 'Krillin',
        power: 1000
    },{
        name: 'Goku',
        power: 9500
    }];
}