function solve() {
	document.getElementsByTagName("button")[0].addEventListener("click", onGenerate);

	document.getElementsByTagName("button")[1].addEventListener("click", onBuy);

	function onGenerate(ev){
		let furniture = JSON.parse(document.getElementsByTagName("textarea")[0].value);
		let table = document.getElementsByClassName("table")[0].children[1];

		for (const iterator of furniture) {
			let newRow = document.createElement("tr");

			newRow.appendChild(generateElement("img", "src", iterator["img"]));
			newRow.appendChild(generateElement("p", "textContent", iterator["name"]));
			newRow.appendChild(generateElement("p", "textContent", iterator["price"]));
			newRow.appendChild(generateElement("p", "textContent", iterator["decFactor"]));
			newRow.appendChild(generateElement("input", "type", "checkbox"));

			table.appendChild(newRow);
		}

		function generateElement(childElementTag, contentType, content){
			let parentElement = document.createElement("td");
			let childElement = document.createElement(childElementTag);
			childElement[contentType] = content;
			parentElement.appendChild(childElement);

			return parentElement;
		}
	}

	function onBuy(ev){
		let checkedElements = Array.from(document.getElementsByClassName("table")[0].children[1].children).filter(x => x.children[4].children[0].checked);
		let sum = checkedElements.reduce((acc, curr) => acc + Number(curr.children[2].children[0].textContent), 0);
		let boughtFurniture = checkedElements.map(x => x.children[1].textContent);
		let decFactorSum = checkedElements.reduce((acc, curr) => acc + Number(curr.children[3].children[0].textContent), 0);

		document.getElementsByTagName("textarea")[1].value = `Bought furniture: ${boughtFurniture.join(", ")}\nTotal price: ${sum.toFixed(2)}\nAverage decoration factor: ${decFactorSum / checkedElements.length}`;
	}
}