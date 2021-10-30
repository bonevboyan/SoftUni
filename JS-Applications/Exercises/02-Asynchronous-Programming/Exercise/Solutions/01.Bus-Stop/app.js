async function getInfo() {
	let input = document.getElementById('stopId');
    let stopID = Number(input.value);
    input.value = '';

	let stopNameDiv = document.getElementById('stopName');
	let busesList = document.getElementById('buses');
    busesList.innerHTML = '';

	try {

        if(isNaN(stopID)){
            throw new Error('Invalid Input');
        }

		let result = await fetch(`http://localhost:3030/jsonstore/bus/businfo/${stopID}`);

		if(result.ok == false){
			throw new Error(`${result.status} ${result.statusText}`)
		}

		let buses = await result.json();

		stopNameDiv.textContent = buses.name;

		for (let bus in buses.buses) {
            let liElement = document.createElement('li');
			liElement.textContent = `Bus ${bus} arrives in ${buses["buses"][`${bus}`]} minutes`;
			busesList.appendChild(liElement);
		}

	} catch(error) {
		stopNameDiv.textContent = "Error";
	}
}