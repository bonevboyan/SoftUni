import { showView, e } from './dom.js';

const section = document.getElementById('movie-details');
section.remove();

export function showDetails(movieId) {
    showView(section);
    getMovie(movieId);
}

async function getMovie(id) {
    section.replaceChildren(e('p', {}, 'Loading...'));

    const res = await fetch('http://localhost:3030/data/movies/' + id);
    const data = await res.json();

    section.replaceChildren(createDetails(data));
}

function createDetails(movie) {
    const controls = e('div', { className: 'col-md-4 text-center' },
        e('h3', { className: 'my-3' }, 'Movie Description'),
        e('p', {}, movie.description)
    );

    const userData = JSON.parse(sessionStorage.getItem('userData'));
    if (userData != null) {
        if (userData.id == movie._ownerId) {
            controls.appendChild(e('a', {className: 'btn btn-danger', href: '#'}, 'Delete'));
            controls.appendChild(e('a', {className: 'btn btn-warning', href: '#'}, 'Edit'));
        } else {
            controls.appendChild(e('a', {className: 'btn btn-primary', href: '#'}, 'Like'));
        }
    }
    controls.appendChild(e('span', {className: 'enrolled-span'}, `Like ${1}`));
    
    const element = e('div', { className: 'container' },
        e('div', { className: 'row bg-light text-dark' },
            e('h1', {}, `Movie title: ${movie.title}`),
            e('div', { className: 'col-md-8' },
                e('img', { className: 'img-thumbnail', src: movie.img, alt: 'Movie' })
            ),
            controls
        )
    );

    return element;
}