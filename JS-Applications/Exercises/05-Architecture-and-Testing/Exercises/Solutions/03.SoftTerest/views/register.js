import { register } from "../api/data.js";
import { showSection } from "../dom.js";
import { updateNav, goTo } from "../app.js";


const section = document.getElementById('registerView');
const form = section.querySelector('form');
form.addEventListener('submit', onRegister);
section.remove();

export function showRegister() {
    showSection(section);
    

}

async function onRegister(event) {
    event.preventDefault();
    const formData = new FormData(form);

    const email = formData.get('email').trim();
    const password = formData.get('password').trim();
    const repeatPassword = formData.get('repeatPassword').trim();

    let re = /[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}/g;

    if(!re.test(email) || password.lenght < 3 || repeatPassword != password){
        return alert('Invalid input!');
    }

    form.reset();

    await register(email, password);
    updateNav();
    goTo('home')
}