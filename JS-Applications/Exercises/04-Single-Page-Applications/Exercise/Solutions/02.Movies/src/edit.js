import { showView } from './dom.js';
import { showDetails } from './details.js';
import { showHome } from './home.js';

const section = document.getElementById('edit-movie');
const form = section.querySelector('form');
form.addEventListener('submit', onSubmit);
section.remove();

export async function showEdit(id) {
    const movie = await getMovie(id);
    
    section.setAttribute('id', id);
    section.querySelector('[name="title"]').value = movie.title;
    section.querySelector('[name="description"]').value = movie.description;
    section.querySelector('[name="imageUrl"]').value = movie.img;

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

        const res = await fetch('http://localhost:3030/data/movies/' + section.getAttribute('id'), {
            method: 'put',
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

        alert('Edited movie successfuly!');
        showHome();
    } catch (error) {
        alert(error.message);
    }
}

async function getMovie(id) {
    const response = await fetch('http://localhost:3030/data/movies/' + id);
    const movie = await response.json();

    return movie;
}