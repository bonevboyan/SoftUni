import { e, showSection } from "../dom.js";
import { getAllIdeas } from "../api/data.js";
import { showDetails } from "./details.js";

const section = document.getElementById('dashboard-holder');
let id;
section.remove();

export function showDashboard() {
    showSection(section);
    showIdeas();
}

async function showIdeas() {
    let ideas = await getAllIdeas();
    section.innerHTML = '';
    console.log(ideas)
    ideas.forEach(element => {
        let hmtl = `<div class="card overflow-hidden current-card details" style="width: 20rem; height: 18rem;" id=${element._id}>
                        <div class="card-body">
                            <p class="card-text">${element.title}</p>
                        </div>
                        <img class="card-image" src="${element.img}" alt="Card image cap">
                        <a class ="btn" href="">Details</a>
                    </div>`
        section.innerHTML += hmtl;
    });
    [...section.children].forEach(x => {
        x.querySelector('.btn').addEventListener('click', (event, id) => {
            event.preventDefault();
            id = event.target.parentElement.id;
            showDetails(id);
        })
    })
}