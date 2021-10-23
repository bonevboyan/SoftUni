window.addEventListener('load', solve);

function solve() {
    let hits = document.querySelector(".all-hits-container");

    let saved = document.querySelector(".saved-container");

    let button = document.getElementById("add-btn");

    let inputFields = Array.from(document.querySelectorAll(".container-text form input"));

    let likes = document.querySelector(".likes p");

    button.addEventListener("click", () => {
        let [genre, name, author, date] = inputFields.map(x => x.value);

        if (!genre || !name || !author || !date) {
            return;
        }

        for (const iterator of inputFields) {
            iterator.value = "";
        }

        let hitsInfoDiv = document.createElement("div");
        hitsInfoDiv.classList.add("hits-info");
        hitsInfoDiv.innerHTML =
            `<img src="./static/img/img.png">
            <h2>Genre: ${genre}</h2>
            <h2>Name: ${name}</h2>
            <h2>Author: ${author}</h2>
            <h3>Date: ${date}</h3>`;

        let saveBtn = document.createElement("button");
        saveBtn.textContent = "Save song";
        saveBtn.classList.add("save-btn");
        let likeBtn = document.createElement("button");
        likeBtn.textContent = "Like song";
        likeBtn.classList.add("like-btn");
        let deleteBtn = document.createElement("button");
        deleteBtn.textContent = "Delete";
        deleteBtn.classList.add("delete-btn");

        hitsInfoDiv.appendChild(saveBtn);
        hitsInfoDiv.appendChild(likeBtn);
        hitsInfoDiv.appendChild(deleteBtn);

        hits.appendChild(hitsInfoDiv);

        likeBtn.addEventListener("click", () => {
            let likesTokens = likes.textContent.split(' ');
            likeCount = Number(likesTokens[2]) + 1;

            likes.textContent = `${likesTokens[0]} ${likesTokens[1]} ${likeCount}`;

            likeBtn.disabled = true;
        });

        saveBtn.addEventListener("click", () => {
            hits.removeChild(hitsInfoDiv);
            saved.appendChild(hitsInfoDiv);

            hitsInfoDiv.removeChild(saveBtn);
            hitsInfoDiv.removeChild(likeBtn);
        });

        deleteBtn.addEventListener("click", () => {
            hitsInfoDiv.parentElement.removeChild(hitsInfoDiv);
        });
    });
}