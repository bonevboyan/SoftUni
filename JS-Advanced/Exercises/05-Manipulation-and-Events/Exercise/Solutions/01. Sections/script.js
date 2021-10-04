function create(words) {
	let contents = document.getElementById("content");
	
	for (const iterator of words) {
		let section = document.createElement("div")

		let paragraph = document.createElement("p");
		paragraph.textContent = iterator;
		paragraph.style.display = "none"

		section.appendChild(paragraph);
		section.addEventListener("click", onClick)

		contents.appendChild(section);

		function onClick(ev){
			ev.target.children[0].style.display = "block";
		}
	}
}