import { html } from "../lib.js";
import { create } from "../api.js/data.js";

//TODO
const createTemplate = (onSubmit) => html``

export function showCreate(ctx) {
    ctx.render(createTemplate(onSubmit));

    async function onSubmit(event) {
        event.preventDefault();
        const form = new FormData(event.target);

        const submisson = {
            title = form.get("title").trim(),
            description = form.get("description").trim(),
            imageUrl = form.get("imageUrl").trim()
        }

        if (Object.values(submisson).any(x => x == '')) {
            return alert('All fields must be filled!');
        }

        await create(submisson);

        ctx.page.redirect("/catalog");
    }
}