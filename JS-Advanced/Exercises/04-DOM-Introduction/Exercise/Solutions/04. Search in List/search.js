function search() {
	let key = document.getElementById("searchText").value;
	let towns = document.getElementById("towns").children;

	let count = 0;

	for (let i = 0; i < towns.length; i++) {
		if (towns[i].textContent.includes(key)) {
			towns[i].style.textDecoration = "underline";
			towns[i].style.fontWeight = "bold";
			count++;
		}
	}

	document.getElementById("result").textContent = `${count} matches found`;
}