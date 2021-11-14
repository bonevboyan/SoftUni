import { showView } from './dom.js';
import { showHome } from './home.js';

const section = document.getElementById('add-movie');
const form = section.querySelector('form');
form.addEventListener('submit', onSubmit);
section.remove();

export function showCreate() {
    showView(section);
}

async function onSubmit(event) {
    event.preventDefault();
    const formData = new FormData(form);

    const title = formData.get('title').trim();
    const description = formData.get('description').trim();
    const imageUrl = formData.get('imageUrl').trim();

    try {
        if (title == '' || description == '' || imageUrl == '') {
            throw new Error('All fields are required!');
        }

        const res = await fetch('http://localhost:3030/data/movies', {
            method: 'post',
            headers: {
                'Content-Type': 'application/js',
                'X-Authorization': JSON.parse(sessionStorage.getItem('userData')).token
            },
            body: JSON.stringify({ title, description, img: imageUrl })
        });

        if (res.ok == false) {
            const error = await res.json();
            throw new Error(error.message);
        }

        form.reset();

        showHome();
    } catch (error) {
        alert(error.message);
    }
}