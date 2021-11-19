import { showSection } from "../dom.js";
import { login } from "../api/data.js";
import { updateNav, goTo } from "../app.js";

const section = document.getElementById('loginView');
const form = section.querySelector('form');
form.addEventListener('submit', onLogin);
section.remove();

export function showLogin() {
    showSection(section);
}

async function onLogin(event) {
    event.preventDefault();
    const formData = new FormData(form);

    const email = formData.get('email').trim();
    const password = formData.get('password').trim();

    await login(email, password);

    form.reset();
    updateNav();
    goTo('home')
}