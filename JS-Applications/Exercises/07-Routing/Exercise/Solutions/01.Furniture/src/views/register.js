import { html } from "../lib.js"
import { register } from "../api/data.js";

const registerTemplate = (onSubmit) => html`
<div class="row space-top">
    <div class="col-md-12">
        <h1>Register New User</h1>
        <p>Please fill all fields.</p>
    </div>
</div>
<form @submit=${onSubmit}>
    <div class="row space-top">
        <div class="col-md-4">
            <div class="form-group">
                <label class="form-control-label" for="email">Email</label>
                <input class="form-control" id="email" type="text" name="email">
            </div>
            <div class="form-group">
                <label class="form-control-label" for="password">Password</label>
                <input class="form-control" id="password" type="password" name="password">
            </div>
            <div class="form-group">
                <label class="form-control-label" for="rePass">Repeat</label>
                <input class="form-control" id="rePass" type="password" name="rePass">
            </div>
            <input type="submit" class="btn btn-primary" value="Register" />
        </div>
    </div>
</form>`

export function showRegister(ctx) {
    ctx.render(registerTemplate(onSubmit));

    async function onSubmit(event) {
        event.preventDefault();

        const registerForm = new FormData(event.target);
        const email = registerForm.get('email').trim();
        const password = registerForm.get('password').trim();
        const rePass = registerForm.get('rePass').trim();

        if(email.length < 3 || password.length < 3 || rePass != password){
            return alert('Credentials too short or passwords don\'t match!');
        }

        await register(email, password);

        registerForm.set('email', '');
        registerForm.set('password', '');
        ctx.updateUserNav();
        ctx.page.redirect('/');
    }
}