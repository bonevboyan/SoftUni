import { login } from "../api/data.js";
import { html } from "../lib.js";

//TODO
const loginTemplate = (onSubmit) => html`
<section id="loginPage">
    <form @submit=${onSubmit}>
        <fieldset>
            <legend>Login</legend>

            <label for="email" class="vhide">Email</label>
            <input id="email" class="email" name="email" type="text" placeholder="Email">

            <label for="password" class="vhide">Password</label>
            <input id="password" class="password" name="password" type="password" placeholder="Password">

            <button type="submit" class="login">Login</button>

            <p class="field">
                <span>If you don't have profile click <a href="#">here</a></span>
            </p>
        </fieldset>
    </form>
</section>`

export function showLogin(ctx) {
    ctx.render(loginTemplate(onSubmit));


    async function onSubmit(event) {
        event.preventDefault();
        const form = new FormData(event.target);

        const email = form.get("email").trim();
        const password = form.get("password").trim();

        await login(email, password);

        ctx.page.redirect("/catalog");
        ctx.updateUserNav();
    }
}