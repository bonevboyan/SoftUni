import { showSection } from "../dom.js";
import { getById } from "../api/data.js";

const section = document.getElementById('detailsView');
section.remove();

export function showDetails(id) {
    showSection(section);
    console.log(id)
    displayDetails(id)
}

async function displayDetails(id) {
    const info = await getById(id);

    section.innerHTML = `<img class="det-img" src="${info.img}" />
                        <div class="desc">
                            <h2 class="display-5">${info.title}</h2>
                            <p class="infoType">Description:</p>
                            <p class="idea-description">${info.desciption}</p>
                        </div>
                        <div class="text-center">
                            <a class="btn detb" href="">Delete</a>
                        </div>`

}