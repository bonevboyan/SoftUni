import { deleteById, getById } from '../api/data.js';
import { html } from '../lib.js';
import { getUserData } from '../util.js';

//TODO
const detailsTemplate = (data, isOwner, onDelete) => html`
<section id="detailsPage">
    <div class="wrapper">
        <div class="albumCover">
            <img src="${data.imgUrl}">
        </div>
        <div class="albumInfo">
            <div class="albumText">

                <h1>Name: ${data.name}</h1>
                <h3>Artist: ${data.artist}</h3>
                <h4>Genre: ${data.genre}</h4>
                <h4>Price: $${data.price}</h4>
                <h4>Date: ${data.releaseDate}</h4>
                <p>Description: ${data.description}</p>
            </div>
            ${isOwner ? html`
            <div class="actionBtn">
                <a href="/edit/${data._id}" class="edit">Edit</a>
                <a @click=${onDelete} href="javascript:void(0)" class="remove">Delete</a>
            </div>` : ''}
            
        </div>
    </div>
</section>`;

export async function showDetails(ctx) {
    const data = await getById(ctx.params.id);
    const userData = getUserData();
    const isOwner = userData && data._ownerId == userData.id;

    ctx.render(detailsTemplate(data, isOwner, onDelete));

    async function onDelete() {
        const choice = confirm('Are you sure you want to delete this?');

        if (choice) {
            await deleteById(ctx.params.id);
            ctx.page.redirect('/catalog')
        }
    }
}
