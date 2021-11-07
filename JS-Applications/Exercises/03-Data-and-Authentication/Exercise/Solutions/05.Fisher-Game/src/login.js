window.addEventListener('DOMContentLoaded', () => {
    const form = document.querySelector('form');
    form.addEventListener('submit', login);
})

async function login(event) {
    event.preventDefault();
    const formData = new FormData(event.target);

    getUser([...formData.entries()].reduce((p, [k, v]) => Object.assign(p, { [k]: v }), {}));
}

async function getUser(user) {
    try {
        const response = await fetch('http://localhost:3030/users/login', {
            method: 'post',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(user)
        });

        if (response.ok != true) {
            const error = await response.json();
            throw new Error(error.message);
        }
        const data = await response.json();

        sessionStorage.setItem('userData', JSON.stringify(data));
        window.location = './index.html';
    }
    catch (error) {
        alert(error.message);
    }
}