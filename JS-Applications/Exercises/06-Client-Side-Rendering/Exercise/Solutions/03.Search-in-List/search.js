import { html, render } from '../node_modules/lit-html/lit-html.js';
import { towns } from './towns.js';

const searchTemplate = (towns, match) => html`    
<article>
   <div id="towns">
      <ul>
         ${towns.map(t => html`
         <li class=${(match && t.toLowerCase().includes(match.toLowerCase())) ? 'active' : ''}>${t}</li>`)}
      </ul>
   </div>
   <input type="text" id="searchText" .value=${match} />
   <button @click=${search}>Search</button>
   <div id="result">${countMatches(towns, match)}</div>
</article>`;

update();

function update(match = '') {
   const result = searchTemplate(towns, match);
   render(result, document.body);
}

function search(event) {
   const match = event.target.parentNode.querySelector('input').value;
   update(match);
}

function countMatches(towns, match) {
   const matches = towns.filter(t => match && t.toLowerCase().includes(match.toLowerCase())).length;
   if (matches != 0) {
      return `${matches} matches found`;
   } else {
      return '';
   }
}