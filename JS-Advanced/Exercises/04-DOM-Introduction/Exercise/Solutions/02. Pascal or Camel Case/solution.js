function solve() {
    let input = document.getElementById("text").value;
    let currentCase = document.getElementById("naming-convention").value;

    input = input.split(" ").map(x => x.toLowerCase());

    if (currentCase == "Camel Case") {
        input = input.map(x => x.charAt(0).toUpperCase() + x.toLowerCase().slice(1)).join('');
		input = input.charAt(0).toLowerCase() + input.slice(1);
    } else if (currentCase == "Pascal Case") {
        input = input.map(x => x.charAt(0).toUpperCase() + x.toLowerCase().slice(1)).join('');
	} else { 
		input = "Error!";
	}

	document.getElementById("result").textContent = input;
}