function solve() {
	let key = document.getElementById("input");
	let paragraphs = key.value.split('.').reduce((acc, curr, index) => {
		if(index % 3 == 0){
			acc.push('');
		}
		if(curr.length > 0){
			acc[acc.length - 1] += `${curr}. `;
		}
		return acc;
	}, []);

	let result = document.getElementById("output");

	for (let i = 0; i < paragraphs.length; i++) {
		if(paragraphs[i].length > 0){
			result.insertAdjacentHTML("beforeend", `<p>${paragraphs[i].trim()}</p>`);
		}
	}
}