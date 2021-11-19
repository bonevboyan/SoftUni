import { showSection } from "../dom.js";

const section = document.getElementById('homeView');
section.remove();

export function showHome() {
    showSection(section);
}