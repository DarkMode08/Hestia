






// Funcion basica de retorno
function addnumber(a:number, b:number):number{

    return a + b;
}

// Funciones de Fecha
const addnumberArrow = (a:number, b:number):string => {
    return `${a + b}`;
}

// Funciones de
function multiply(firstNumber:number, secondNumber:number, base?:number):number{

    return firstNumber * secondNumber;
}

const result:number = addnumber (8, 16);
const result2:string = addnumberArrow (8, 16);
const result3:number = multiply(8, 16);

console.log({result, result2, result3});

export{};