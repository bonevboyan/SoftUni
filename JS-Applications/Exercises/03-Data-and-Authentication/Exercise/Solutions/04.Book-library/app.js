async function attachEvents() {
    const submitForm = document.querySelector("#submitForm")
    submitForm.addEventListener("submit", onSubmit);

    const editForm = document.querySelector("#editForm");
    editForm.addEventListener("submit", onSave);
    editForm.style.display = 'none';

    const editTitle = document.querySelector('#editForm input[name="title"]');
    const editAuthor = document.querySelector('#editForm input[name="author"]');

    const table = document.querySelector('table tbody');
    table.addEventListener("click", onEdit);
    table.addEventListener("click", onDelete);

    document.getElementById("loadBooks").addEventListener("click", onLoad);

    const url = "http://localhost:3030/jsonstore/collections/books";

    async function onSubmit(event) {
        event.preventDefault();

        const formData = new FormData(event.target);
        event.target.reset();
        const newBook = [...formData.entries()].reduce((p, [k, v]) => Object.assign(p, { [k]: v }), {});


        if (Object.entries(newBook).some(x => x[1] === '')) {
            return;
        }

        const newBookResponse = await postBook(newBook);
        addToTable(newBook, newBookResponse._id);
    }

    async function onLoad(event) {
        const books = await getBooks();
        table.innerHTML = '';
        for (const key in books) {
            addToTable(books[key], key)
        }
    }

    function onDelete(event) {
        if (event.target.textContent == 'Delete') {
            const bookToDelete = event.target.parentElement.parentElement;

            const bookToDeleteId = bookToDelete.getAttribute("key");

            bookToDelete.parentElement.removeChild(bookToDelete);
            deleteBook(bookToDeleteId)
        }
    }

    function onEdit(event) {
        if (event.target.textContent == 'Edit') {
            editForm.style.display = 'block';
            submitForm.style.display = 'none';

            editTitle.value = event.target.parentElement.parentElement.children[0].textContent;
            editAuthor.value = event.target.parentElement.parentElement.children[1].textContent;

            const editedBookId = event.target.parentElement.parentElement.getAttribute("key");

            editForm.setAttribute("key", editedBookId);
        }
    }

    async function onSave(event) {
        event.preventDefault();

        editForm.style.display = 'none';
        submitForm.style.display = 'block';

        const formData = new FormData(event.target);
        event.target.reset();
        const editedBook = [...formData.entries()].reduce((p, [k, v]) => Object.assign(p, { [k]: v }), {});


        if (Object.entries(editedBook).some(x => x[1] === '')) {
            return;
        }

        const editedBookKey = editForm.getAttribute("key");

        await editBook(editedBook, editedBookKey);
        const oldBook = table.querySelector(`tr[key="${editedBookKey}"]`);

        editTable(oldBook, editedBook);
    }

    async function deleteBook(id) {
        try {
            const response = await fetch(`${url}/${id}`, {
                method: 'delete'
            });

            if (response.ok == false) {
                const error = await response.json();
                throw new Error(error.message);
            }

        } catch (error) {
            console.log(error.message)
        }
    }

    async function editBook(newBook, id) {
        try {
            const response = await fetch(`${url}/${id}`, {
                method: 'put',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(newBook)
            });

            if (response.ok == false) {
                const error = await response.json();
                throw new Error(error.message);
            }

        } catch (error) {
            console.log(error.message)
        }
    }

    async function postBook(book) {
        try {
            const response = await fetch(url, {
                method: 'post',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(book)
            });

            if (response.ok == false) {
                const error = await response.json();
                throw new Error(error.message);
            }

            return await response.json();

        } catch (error) {
            console.log(error.message)
        }
    }

    async function getBooks() {
        try {
            const response = await fetch(url);

            if (response.ok == false) {
                const error = await response.json();
                throw new Error(error.message);
            }

            const result = await response.json();

            return result;

        } catch (error) {
            console.log(error.message)
        }
    }

    function editTable(oldBook, editedBook) {
        oldBook.children[0].textContent = editedBook.title;
        oldBook.children[1].textContent = editedBook.author;
    }

    function addToTable(book, id) {
        const newRow = document.createElement('tr');
        newRow.setAttribute("key", id);

        for (const key in book) {
            if (key != '_id') {

            }
        }

        const titleCell = document.createElement('td');
        titleCell.textContent = book['title'];
        newRow.appendChild(titleCell);

        const authorCell = document.createElement('td');
        authorCell.textContent = book['author'];
        newRow.appendChild(authorCell);

        const buttonCell = document.createElement('td');

        const editBtn = document.createElement('button');
        editBtn.textContent = 'Edit';
        const deleteBtn = document.createElement('button');
        deleteBtn.textContent = 'Delete';

        buttonCell.appendChild(editBtn);
        buttonCell.appendChild(deleteBtn);

        newRow.appendChild(buttonCell);

        table.appendChild(newRow);
    }
}

attachEvents();