import { getMyMemes } from '../api/data.js';
import { html } from '../lib.js';
import { getUserData } from '../util.js';

const profileTemplate = (memes, info) => html`
<section id="user-profile-page" class="user-profile">
    <article class="user-info">
        <img id="user-avatar" alt="user-profile" src="/images/female.png"></img> 
        <div class="user-content">
        <p>Username: ${info.username}</p>
        <p>Email: ${info.username}</p>
        <p>My memes count: ${memes.length}</p>
        </div>
    </article>
    <h1 id="user-listings-title">User Memes</h1>
    <div class="user-memes-listings">
        ${memes.length == 0 ?
      html`<p class="no-memes">No memes in database.</p>`
      : memes.map(m => memeTemplate(m))
  }
    </div>
</section>`;

const memeTemplate = (meme) => html`
<div class="user-meme">
    <p class="user-meme-title">${meme.title}</p>
    <img class="userProfileImage" alt="meme-img" src=${meme.imageUrl} />
    <a class="button" href="/details/${meme._id}">Details</a>
</div>`;

export async function showProfile(ctx) {
    const userData = getUserData();
    const memes = await getMyMemes(userData.id);
    ctx.render(profileTemplate(memes, userData));
}
