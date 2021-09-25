function solve() {
	document.querySelector('#searchBtn').addEventListener('click', onClick);

	function onClick() {
		let key = document.getElementById("searchField").value;
		let students = document.getElementsByClassName("container")[0].children[2].children;

		for (let i = 0; i < students.length; i++) {
			let children = students[i].children;
			for (let j = 0; j < children.length; j++) {
				if (children[j].textContent.includes(key)) {
					students[i].classList.add("select");
				}
			}
		}
	}
}