/* // Seccion default 00

import './style.css'
import typescriptLogo from './typescript.svg'
import viteLogo from '/vite.svg'
import { setupCounter } from './counter.ts'

document.querySelector<HTMLDivElement>('#app')!.innerHTML = `
  <div>
    <a href="https://vite.dev" target="_blank">
      <img src="${viteLogo}" class="logo" alt="Vite logo" />
    </a>
    <a href="https://www.typescriptlang.org/" target="_blank">
      <img src="${typescriptLogo}" class="logo vanilla" alt="TypeScript logo" />
    </a>
    <h1>Vite + TypeScript</h1>
    <div class="card">
      <button id="counter" type="button"></button>
    </div>
    <p class="read-the-docs">
      Click on the Vite and TypeScript logos to learn more
    </p>
  </div>
`

setupCounter(document.querySelector<HTMLButtonElement>('#counter')!) */


/* Seccion Basic-Types 01
import './style.css'
import './topics/01-basic-types.ts'

document.querySelector<HTMLDivElement>('#app')!.innerHTML = `
  Hola
`;

console.log('Hola'); */


/* Seccion Object-Interface
import './style.css'
import './topics/02-object-interface'
 */

// Seccion Functions

import './topics/03-functions'