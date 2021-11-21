import { html, render } from '../node_modules/lit-html/lit-html.js';
import { cats } from './catSeeder.js';

const listTemplate = (data, onDetails) => html`
<ul>
    ${data.map(c => html`
    <li>
        <img src="./images/${c.imageLocation}.jpg" width="250" height="250" alt="Card image cap">
        <div class="info">
            <button class="showBtn" @click=${() => onDetails(c)}>${data.details ? 'Hide status code': 'Show status code'}</button>
            <div class="status" id="100" style=display:${c.details ? 'block': 'none'}>
                <h4>Status Code: ${c.statusCode}</h4>
                <p>${c.statusMessage}</p>
            </div>
        </div>
    </li>
    `)}
</ul>`;

start();

function start() {
    const container = document.getElementById('allCats');

    onRender();

    function onDetails(cat) {
        cat.details = !cat.details;
        onRender();
    }

    function onRender() {
        render(listTemplate(cats, onDetails), container);
    }
}