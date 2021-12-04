import { getAllData } from "../api/data.js";
import { html } from "../lib.js";
import { getUserData } from '../util.js';

//TODO
const catalogTemplate = (data, isLogged) => html`
<section id="catalogPage">
    <h1>All Albums</h1>
    ${data.length == 0 
            ? html`<p>No Albums in Catalog!</p>` 
            : data.map(x => cardTemplate(x, isLogged))}

</section>`;

//TODO
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

export async function showCatalog(ctx) {
    const data = await getAllData();

    const isLogged = getUserData() != null;

    ctx.render(catalogTemplate(data, isLogged));
}