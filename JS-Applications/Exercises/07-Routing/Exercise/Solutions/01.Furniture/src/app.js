import { page, render } from "./lib.js"
import { getUserData } from "./util.js"
import { showDashboard } from "./views/dashboard.js"
import { showLogin } from "./views/login.js"
import { showRegister } from "./views/register.js"
import { showCreate } from "./views/create.js"
import { showMyFurniture } from "./views/myFurniture.js"
import { showDetails } from "./views/details.js"
import { showEdit } from "./views/edit.js"
import { logout } from "./api/data.js"

const main = document.querySelector('.container');

page(decorateContext);
page("/", showDashboard);
page("/login", showLogin);
page("/register", showRegister);
page("/create", showCreate);
page("/my-furniture", showMyFurniture);
page("/details/:id", showDetails);
page("/edit/:id", showEdit);

updateUserNav();
page.start();

document.getElementById('logoutBtn').addEventListener('click', async () => {
    await logout();
    updateUserNav();
    page.redirect('/');
})

function decorateContext(ctx, next) {
    ctx.render = (content) => render(content, main);
    ctx.updateUserNav = updateUserNav;
    next();
}

function updateUserNav() {
    const userId = getUserData();

    if (userId != null) {
        document.getElementById('user').style.display = 'inline-block';
        document.getElementById('guest').style.display = 'none';
    } else {
        document.getElementById('user').style.display = 'none';
        document.getElementById('guest').style.display = 'inline-block';
    }
}