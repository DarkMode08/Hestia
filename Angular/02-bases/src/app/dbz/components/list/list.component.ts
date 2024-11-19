import { Character } from './../../interfaces/character.interface';
import { ChangeDetectionStrategy, Component, Input, input } from '@angular/core';

@Component({
    selector: 'dbz-list',
    templateUrl: './list.component.html',
    styleUrl: './list.component.css',
    changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ListDBZComponent { 
    @Input()
    public CharacterList: Character[] = [{
        name: 'Trunks',
        power: 10
    }]
}
