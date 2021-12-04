import { editById, getById } from '../api/data.js';
import { html } from '../lib.js';

//TODO
const editTemplate = (data, onSubmit) => html`<section class="editPage">
<form @submit=${onSubmit}>
    <fieldset>
        <legend>Edit Album</legend>

        <div class="container">
            <label for="name" class="vhide">Album name</label>
            <input id="name" name="name" class="name" type="text" value="${data.name}">

            <label for="imgUrl" class="vhide">Image Url</label>
            <input id="imgUrl" name="imgUrl" class="imgUrl" type="text" value="${data.imgUrl}">

            <label for="price" class="vhide">Price</label>
            <input id="price" name="price" class="price" type="text" value="${data.price}">

            <label for="releaseDate" class="vhide">Release date</label>
            <input id="releaseDate" name="releaseDate" class="releaseDate" type="text" value="${data.releaseDate}">

            <label for="artist" class="vhide">Artist</label>
            <input id="artist" name="artist" class="artist" type="text" value="${data.artist}">

            <label for="genre" class="vhide">Genre</label>
            <input id="genre" name="genre" class="genre" type="text" value="${data.genre}">

            <label for="description" class="vhide">Description</label>
            <textarea name="description" class="description" rows="10"
                cols="10">${data.description}</textarea>

            <button class="edit-album" type="submit">Edit Album</button>
        </div>
    </fieldset>
</form>
</section>`;

export async function showEdit(ctx) {
    const card = await getById(ctx.params.id);

    ctx.render(editTemplate(card, onSubmit));

    async function onSubmit(event) {
        event.preventDefault();

        const form = new FormData(event.target);

        const submisson = {
            name: form.get("name").trim(),
            imgUrl: form.get("imgUrl").trim(),
            price: form.get("price").trim(),
            releaseDate: form.get("releaseDate").trim(),
            artist: form.get("artist").trim(),
            genre: form.get("genre").trim(),
            description: form.get("description").trim(),
        }

        if (submisson.name == '' || submisson.imgUrl == '' || submisson.price == '' || submisson.releaseDate == '' || submisson.artist == '' || submisson.genre == '' || submisson.description == '') {
            return alert('All fields must be filled!');
        }

        await editById(ctx.params.id, submisson);
        
        ctx.page.redirect('/catalog');
    }
}
