function attachEvents() {
    document.getElementById("submit").addEventListener("click", onSubmit);
    document.getElementById("refresh").addEventListener("click", onRefresh);

    const author = document.querySelector('input[name="author"]');
    const content = document.querySelector('input[name="content"]');
    const messagesArea = document.getElementById("messages");

    const url = 'http://localhost:3030/jsonstore/messenger';

    function onSubmit() {
        const message = {
            author: author.value.trim(),
            content: content.value.trim()
        }

        if (Object.entries(message).some(x => x[1] === '')) {
            return;
        }

        author.value = '';
        content.value = '';

        postMessage(message);
    }

    async function onRefresh() {
        const messages = await getMessages();
        messagesArea.value = '';

        for (const message of messages) {
            messagesArea.value += `${message.author}: ${message.content}\n`;
        }
    }

    async function getMessages() {
        try {
            const response = await fetch(url);

            if (response.ok == false) {
                const error = await response.json();
                throw new Error(error.message);
            }

            const result = await response.json();

            return Object.entries(result).map(x => x[1]);

        } catch (error) {
            console.log(error.message)
        }
    }

    async function postMessage(message) {
        try {
            const response = await fetch(url, {
                method: 'post',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(message)
            });

            if (response.ok == false) {
                const error = await response.json();
                throw new Error(error.message);
            }

            const result = await response.json();

        } catch (error) {
            console.log(error.message)
        }
    }
}

attachEvents();