import { page, render } from "./lib.js"
import { getUserData } from "./util.js"
import { showCatalog } from "./views/catalog.js"
import { showLogin } from "./views/login.js"
import { showRegister } from "./views/register.js"
import { showHome } from "./views/home.js"
import { showCreate } from "./views/create.js"
import { showSearch } from "./views/search.js"
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
page("/search", showSearch);
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

//TODO
function updateUserNav() {
    const userId = getUserData();

    if (userId != null) {
        [...document.querySelectorAll('.user')].forEach(x => x.style.display = 'inline-block');
        [...document.querySelectorAll('.guest')].forEach(x => x.style.display = 'none');
    } else {
        [...document.querySelectorAll('.user')].forEach(x => x.style.display = 'none');
        [...document.querySelectorAll('.guest')].forEach(x => x.style.display = 'inline-block');
    }
}

async function onLogout() {
    logout();
    updateUserNav();
    page.redirect('/');
}