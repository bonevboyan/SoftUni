import { getAllData } from "../api/data.js";
import { html } from "../lib.js";

//TODO
const catalongTemplate = (data) => html``;

//TODO
const memeTemplate = (d) => html``

export async function showCatalog(ctx) {
    const data = await getAllData();

    ctx.render(catalongTemplate(data));
}