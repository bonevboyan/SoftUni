import { register } from "../api/data.js";
import { html } from "../lib.js";

//TODO
const registerTemplate = (onSubmit) => html`
<section id="registerPage">
    <form @submit=${onSubmit}>
        <fieldset>
            <legend>Register</legend>

            <label for="email" class="vhide">Email</label>
            <input id="email" class="email" name="email" type="text" placeholder="Email">

            <label for="password" class="vhide">Password</label>
            <input id="password" class="password" name="password" type="password" placeholder="Password">

            <label for="conf-pass" class="vhide">Confirm Password:</label>
            <input id="conf-pass" class="conf-pass" name="conf-pass" type="password" placeholder="Confirm Password">

            <button type="submit" class="register">Register</button>

            <p class="field">
                <span>If you already have profile click <a href="#">here</a></span>
            </p>
        </fieldset>
    </form>
</section>`

export function showRegister(ctx) {
    ctx.render(registerTemplate(onSubmit));


    async function onSubmit(event) {
        event.preventDefault();
        const form = new FormData(event.target);

        //TODO
        const submission = {
            email: form.get("email").trim(),
            password: form.get("password").trim(),
            repeatPass: form.get("conf-pass").trim()
        }

        if (submission.email == '' || submission.password == '' || submission.repeatPass == '') {
            return alert('All fields must be filled!');
        }

        if (submission.password != submission.repeatPass) {
            return alert('Passwords don\'t match!');
        }

        await register(submission.email, submission.password);

        ctx.page.redirect("/catalog");
        ctx.updateUserNav();
    }
}