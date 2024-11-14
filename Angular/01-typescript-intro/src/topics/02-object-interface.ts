






// Arreglo ts
let skills: string[] = ['Bash','Counter','Healing'];

//Objeto Strider - Se le dio uso a la interfase para definir que tipo sera cada dato
interface Character{
    name: string;
    hp: number;
    skills: string[];
    hometown?: string;
}

// Objeto Principal que hace uso de la interfaz
const strider: Character = {
    name: 'Michael',
    hp: 8,
    skills: ['Bash','Counter']
};

// inicializar valor que fue opcional en constructor
strider.hometown = 'Stg';

console.table(strider);

export {};