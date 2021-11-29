import { page, render } from "./lib.js"
import { getUserData } from "./util.js"
import { showCatalog } from "./views/catalog.js"
import { showLogin } from "./views/login.js"
import { showRegister } from "./views/register.js"
import { showHome } from "./views/home.js"
import { showCreate } from "./views/create.js"
import { showProfile } from "./views/profile.js"
import { showDetails } from "./views/details.js"
import { showEdit } from "./views/edit.js"
import { logout } from "./api/data.js"

const main = document.querySelector('main');

page(decorateContext);
page("/", showHome);
page("/catalog", showCatalog)
page("/login", showLogin);
page("/register", showRegister);
page("/create", showCreate);
page("/profile", showProfile);
page("/details/:id", showDetails);
page("/edit/:id", showEdit);

updateUserNav();
page.start();

document.getElementById('logoutBtn').addEventListener('click', onLogout)

function decorateContext(ctx, next) {
    ctx.render = (content) => render(content, main);
    ctx.updateUserNav = updateUserNav;
    next();
}

function updateUserNav() {
    const userId = getUserData();

    if (userId != null) {
        document.querySelector('.user').style.display = 'block';
        document.querySelector('.guest').style.display = 'none';
        document.querySelector('.profile span').textContent = `Welcome, ${userId.email}`
    } else {
        document.querySelector('.user').style.display = 'none';
        document.querySelector('.guest').style.display = 'block';
    }
}

async function onLogout() {
    logout();
    updateUserNav();
    page.redirect('/');
}