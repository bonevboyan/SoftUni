import { searchByQuery } from "../api/data.js";
import { html } from "../lib.js";
import { getUserData } from '../util.js';

//TODO
const searchTemplate = (onSubmit, beforeSearch, data, isLogged) => html`
<section id="searchPage">
    <h1>Search by Name</h1>

    <div class="search">
        <input id="search-input" type="text" name="search" placeholder="Enter desired albums's name">
        <button @click=${onSubmit} class="button-list">Search</button>
    </div>

    <h2>Results:</h2>

    ${beforeSearch ? '' : html`
    <div class="search-result">
        ${data.length == 0 
            ? html`<p class="no-result">No result.</p>` 
            : data.map(x => cardTemplate(x, isLogged))}
    </div>` }


</section>`;

const cardTemplate = (d, isLogged) => html`
<div class="card-box">
    <img src="${d.imgUrl}">
    <div>
        <div class="text-center">
            <p class="name">Name: ${d.name}</p>
            <p class="artist">Artist: ${d.artist}</p>
            <p class="genre">Genre: ${d.genre}</p>
            <p class="price">Price: $${d.price}</p>
            <p class="date">Release Date: ${d.releaseDate}</p>
        </div>
        ${isLogged ? html`<div class="btn-group">
            <a href="/details/${d._id}" id="details">Details</a>
        </div>` : ''}
        
    </div>
</div>`

export async function showSearch(ctx) {
    const isLogged = getUserData() != null;

    ctx.render(searchTemplate(onSubmit, true));

    async function onSubmit(event) {
        event.preventDefault();

        const result = event.target.parentElement.querySelector('input').value;

        if (result == '') {
            return alert('All fields must be filled!');
        }

        const data = await searchByQuery(result);

        console.log(data)

        ctx.render(searchTemplate(onSubmit, false, data, isLogged));
    }
}