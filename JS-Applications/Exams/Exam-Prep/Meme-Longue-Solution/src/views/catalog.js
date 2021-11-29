import { getAllMemes } from "../api/data.js";
import { html } from "../lib.js";

const catalongTemplate = (memes) => html`
<section id="meme-feed">
    <h1>All Memes</h1>
    <div id="memes">
        ${memes.length == 0 
            ? html`<p class="no-memes">No memes in database.</p>` 
            : memes.map(memeTemplate)}
    </div>
</section>`;

const memeTemplate = (meme) => html`
<div class="meme">
    <div class="card">
        <div class="info">
            <p class="meme-title">${meme.title}</p>
            <img class="meme-image" alt="meme-img" src=${meme.imageUrl}>
        </div>
        <div id="data-buttons">
            <a class="button" href="/details/${meme._id}">Details</a>
        </div>
    </div>
</div>`

export async function showCatalog(ctx) {
    const data = await getAllMemes();

    ctx.render(catalongTemplate(data));
}