import { deleteById, getById } from '../api.js/data.js';
import { html } from '../lib.js';
import { getUserData } from '../util.js';

//TODO
const detailsTemplate = (data, isOwner, onDelete) => html``;

export async function showDetails(ctx) {
    const card = await getById(ctx.params.id);
    const userData = getUserData();
    const isOwner = userData && card._ownerId == userData.id;
    
    ctx.render(detailsTemplate(data, isOwner, onDelete));

    async function onDelete() {
        const choice = confirm('Are you sure you want to delete this?');

        if (choice) {
            await deleteById(ctx.params.id);
            ctx.page.redirect('/catalog')
        }
    }
}
