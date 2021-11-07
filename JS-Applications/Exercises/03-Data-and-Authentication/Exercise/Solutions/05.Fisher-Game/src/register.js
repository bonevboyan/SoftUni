window.addEventListener('DOMContentLoaded', () => {
    const form = document.querySelector('form');
    form.addEventListener('submit', register);

    async function register(event) {
        event.preventDefault();
        const formData = [...new FormData(event.target).entries()].reduce((p, [k, v]) => Object.assign(p, { [k]: v }), {});

        if (formData.email == '' || formData.password == '') {
            return alert('All field must be filled!');
        } else if (formData.password != formData.rePass) {
            return alert("Passwords don't match!");
        }


        postUser(formData, event);

    }

    async function postUser(user, event) {
        try {
            const response = await fetch('http://localhost:3030/users/register', {
                method: 'post',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(user)
            });

            if (response.ok != true) {
                const error = await response.json();
                return alert(error.message);
            }

            const data = await response.json();

            sessionStorage.setItem('userData', JSON.stringify(data));



            window.location = './index.html';

            alert('Registered successfully!');
            event.target.reset();
        }
        catch (error) {
            alert(error.message);
        }
    }
})