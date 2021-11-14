import { showView } from './dom.js';
import { showHome } from './home.js';
import { updateNav } from './app.js'; 

const section = document.getElementById('form-sign-up');
const form = section.querySelector('form');
form.addEventListener('submit', onRegister);
section.remove();

export function showRegister() {
    showView(section);
}

async function onRegister(event) {
    event.preventDefault();
    const formData = new FormData(form);

    const email = formData.get('email').trim();
    const password = formData.get('password').trim();
    const repeatPassword = formData.get('repeatPassword').trim();

    try {
        if(email == '' || password == '' || password != repeatPassword){
            throw new Error('Invalid credentials!');
        }

        const res = await fetch('http://localhost:3030/users/register', {
            method: 'post',
            headers: {
                'Content-Type': 'application/js'
            },
            body: JSON.stringify({ email, password, repeatPassword })
        });

        if (res.ok == false) {
            const error = await res.json();
            throw new Error(error.message);
        }

        const data = await res.json();
        sessionStorage.setItem('userData', JSON.stringify({
            email: data.email,
            id: data._id,
            token: data.accessToken
        }));

        alert('Registered successfuly!');
        form.reset();
        
        updateNav();
        showHome();
    } catch (error) {
        alert(error.message);
    }
}