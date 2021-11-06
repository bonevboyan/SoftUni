function attachEvents() {
    document.getElementById("btnLoad").addEventListener("click", onLoad);
    document.getElementById("btnCreate").addEventListener("click", onCreate);

    const numberList = document.getElementById("phonebook");
    numberList.addEventListener("click", onDelete);

    const personInput = document.getElementById("person");
    const phoneInput = document.getElementById("phone");

    const url = "http://localhost:3030/jsonstore/phonebook";

    async function onLoad() {
        const numbers = await getEntries();

        numberList.innerHTML = '';

        for ({person, phone, _id} of numbers) {
            const newElement = document.createElement("li");
            newElement.textContent = `${person}: ${phone}`;
            newElement.setAttribute("key", _id);

            const button = document.createElement("button");
            button.textContent = "Delete";
            newElement.appendChild(button);

            numberList.appendChild(newElement);
        }
    }

    function onCreate() {
        const entry = {
            person: personInput.value.trim(),
            phone: phoneInput.value.trim()
        }

        if (Object.entries(entry).some(x => x[1] === '')) {
            return;
        }

        personInput.value = '';
        phoneInput.value = '';

        postEntry(entry);
    }

    function onDelete(event) {
        const target = event.target;
        if(target.tagName == "BUTTON"){
            const key = target.parentElement.getAttribute("key"); 

            target.parentElement.parentElement.removeChild(target.parentElement);
            
            deleteEntry(key);
        }
    }

    async function postEntry(entry) {
        try {
            const response = await fetch(url, {
                method: 'post',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(entry)
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
    
    async function getEntries() {
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

    async function deleteEntry(key) {
        try {
            const response = await fetch(`${url}/${key}`, {
                method: 'delete'
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