import { editById, getById } from '../api/data.js';
import { html } from '../lib.js';

//TODO
const editTemplate = (data, onSubmit) => html``;

export async function showEdit(ctx) {
    const card = await getById(ctx.params.id);

    ctx.render(editTemplate(card, onSubmit));

    async function onSubmit(event) {
        event.preventDefault();

        const formData = new FormData(event.target);

        const submisson = {
            title = form.get("title").trim(),
            description = form.get("description").trim(),
            imageUrl = form.get("imageUrl").trim()
        }

        if (Object.values(submisson).any(x => x == '')) {
            return alert('All fields must be filled!');
        }

        await editById(ctx.params.id, submisson);
        ctx.page.redirect('/catalog');
    }
}
