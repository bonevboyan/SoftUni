import { showSection } from "../dom.js";
import { goTo } from "../app.js";
import { createIdea } from "../api/data.js";

const section = document.getElementById('createView');
const form = section.querySelector('form');
form.addEventListener('submit', onRegister);
section.remove();

export function showCreate() {
    showSection(section);
    console.log('create')

}


async function onRegister(event) {
    event.preventDefault();
    const formData = new FormData(form);

    const title = formData.get('title').trim();
    const description = formData.get('description').trim();
    const imageURL = formData.get('imageURL').trim();
    
    if(title.length < 6 || description.length < 10 || imageURL.length < 5){
        return alert('Invalid input!');
    }

    form.reset();

    const body = {
        "_ownedId": sessionStorage.getItem('userData').id,
        title,
        description,
        "img": imageURL
    }

    createIdea(body);
    goTo('dashboard');
}