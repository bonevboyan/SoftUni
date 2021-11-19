import { showHome } from "./views/home.js";
import { showLogin } from "./views/login.js";
import { showRegister } from "./views/register.js";
import { showDashboard } from "./views/dashboard.js";
import { showCreate } from "./views/create.js";
import { logout } from "./api/data.js";

const views = {
    'home': showHome,
    'login': showLogin,
    'register': showRegister,
    'dashboard': showDashboard,
    'create': showCreate
}

const links = {
    'homeBtn': 'home',
    'loginBtn': 'login',
    'registerBtn': 'register',
    'dashboardBtn': 'dashboard',
    'createBtn': 'create'
}

const nav = document.querySelector('nav');
nav.addEventListener('click', (event) => onNavigate(event));
document.getElementById('logoutBtn').addEventListener('click', onLogout);

function onNavigate(event) {
    if (event.target.tagName == 'A') {
        const name = links[event.target.id];
        if (name) {
            event.preventDefault();
            goTo(name);
        }
    }
}

async function onLogout(event) {
    logout();
    updateNav();
}

export function goTo(name) {
    const view = views[name];

    if (typeof view == 'function') {
        view();
    }
}

export function updateNav() {
    let userData = sessionStorage.getItem('userData');

    if (userData == null) {
        [...nav.querySelectorAll('.user')].forEach(x => x.style.display = 'none');
        [...nav.querySelectorAll('.guest')].forEach(x => x.style.display = 'block');
    } else {
        [...nav.querySelectorAll('.guest')].forEach(x => x.style.display = 'none');
        [...nav.querySelectorAll('.user')].forEach(x => x.style.display = 'block');
    }
}

showHome();
updateNav()