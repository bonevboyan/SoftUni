import { register } from "../api/data.js";
import { html } from "../lib.js";

//TODO
const registerTemplate = (onSubmit) => html``

export function showRegister(ctx) {
    ctx.render(registerTemplate(onSubmit));


    async function onSubmit(event) {
        event.preventDefault();
        const form = new FormData(event.target);

        //TODO
        const submission = {
            email = form.get("email").trim(),
            password = form.get("password").trim(),
            repeatPass = form.get("repeatPass").trim()
        }

        if (Object.values(submission).any(x => x == '')) {
            return alert('All fields must be filled!');
        }

        if(submission.password != submission.repeatPass){
            return alert('Passwords don\'t match!');
        }
    
        await register(email, password);
    
        ctx.page.redirect("/catalog");
        ctx.updateUserNav();
    }
}