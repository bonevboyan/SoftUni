const url = 'http://localhost:3030/jsonstore/collections/books'

export async function getAllBooks() {
    const response = await fetch(url);
    const data = await response.json();

    return Object.entries(data).map(([k, v]) => Object.assign(v, { _id: k }));
}

export async function getBookById(id) {
    const response = await fetch(`${url}/${id}`);
    const data = await response.json();

    return data;
}

export async function createBook(book) {
    await fetch(url, {
        method: 'post',
        headers: { 'Content-type': 'application/json' },
        body: JSON.stringify(book)
    });
}

export async function editBook(id, book) {
    await fetch(`${url}/${id}`, {
        method: 'put',
        headers: { 'Content-type': 'application/json' },
        body: JSON.stringify(book)
    });
}

export async function deleteBook(id) {
    await fetch(`${url}/${id}`, {
        method: 'delete',
    });
}