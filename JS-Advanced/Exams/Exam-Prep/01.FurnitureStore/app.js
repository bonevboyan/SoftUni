window.addEventListener('load', solve);

function solve() {
    const html = {
        button: document.getElementById("add"),
        model: document.getElementById("model"),
        year: document.getElementById("year"),
        price: document.getElementById("price"),
        description: document.getElementById("description"),
        table: document.getElementById("information")
    }
    html.button.addEventListener("click", e => {
        const furniture = {
            model: html.model.value,
            year: Number(html.year.value),
            description: html.description.value,
            price: Number(html.price.value)
        }
        console.log(furniture);
    })
}
