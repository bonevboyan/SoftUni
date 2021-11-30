import { login } from "../api/data.js";
import { html } from "../lib.js";

//TODO
const loginTemplate = (onSubmit) => html``

export function showLogin(ctx, event) {
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