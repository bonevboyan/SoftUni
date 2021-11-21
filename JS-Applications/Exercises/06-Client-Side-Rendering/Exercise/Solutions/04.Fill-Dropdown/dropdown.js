import { html, render } from '../node_modules/lit-html/lit-html.js';

const selectTemplate = (list) => html`
<select id='menu'>
    ${list.map(x => html`<option value=${x._id}>${x.text}</option>`)}
</select>`;

const url = 'http://localhost:3030/jsonstore/advanced/dropdown';
const main = document.querySelector('div');
const input = document.getElementById('itemText');
const form = document.querySelector('form');

initialize();

async function initialize() {
    const response = await fetch(url);
    const data = await response.json();
    const list = Object.values(data);

    form.addEventListener('submit', (event) => addItem(event, list));

    update(list);
}

function update(list) {
    const result = selectTemplate(list);
    render(result, main);
}

async function addItem(event, list) {
    event.preventDefault();

    const item = {
        text: input.value
    };

    const response = await fetch(url, {
        method: 'post',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(item)
    });
    
    const result = await response.json();
    list.push(result);
    update(list);
    input.value = '';
}