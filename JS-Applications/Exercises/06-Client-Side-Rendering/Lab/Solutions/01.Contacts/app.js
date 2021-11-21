import { contacts } from "./contacts.js"
import { html, render } from "./node_modules/lit-html/lit-html.js"
//import { styleMap } from "./node_modules/lit-html/directives/style-map"

const contactTemplate = (data, onDetails) => html`
<div class="contact card">
    <div>
        <i class="far fa-user-circle gravatar"></i>
    </div>
    <div class="info">
        <h2>Name: ${data.name}</h2>
        <button class="detailsBtn" @click=${() => onDetails(data)}>${data.details ? 'Hide': 'Details'}</button>
        <div class="details" id="1" style=display:${data.details ? 'block': 'none'}> 
            <p>Phone number: ${data.phoneNumber}</p>
            <p>Email: ${data.email}</p>
        </div>
    </div>
</div>`

start();

function start() {
    const container = document.getElementById('contacts');

    onRender();

    function onDetails(contact) {
        contact.details = !contact.details;
        onRender();
    }

    function onRender() {
        render(contacts.map(c => contactTemplate(c, onDetails)), container);
        console.log(contacts)
    }
}