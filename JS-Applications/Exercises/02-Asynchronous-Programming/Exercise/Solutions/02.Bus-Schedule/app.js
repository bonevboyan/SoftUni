function solve() {
    let departBtn = document.getElementById("depart");
    let arriveBtn = document.getElementById("arrive");

    let infoDiv = document.getElementById("info");

    let nextStopID = 'depot';
    let nextStop = 'depot';

    async function depart() {
        departBtn.disabled = true;
        arriveBtn.disabled = false;

        try {
            let response = await fetch(`http://localhost:3030/jsonstore/bus/schedule/${nextStopID}`);
    
            if(response.ok == false){
                throw new Error(`${response.status} ${response.statusText}`)
            }
    
            let stop = await response.json();
            
            nextStopID = stop.next;
            nextStop = stop.name;

            infoDiv.textContent = `Next stop ${nextStop}`;
    
        } catch(error) {
            infoDiv.textContent = "Error" + error.message;
            arriveBtn.disabled = true;
        }
    }

    function arrive() {
        departBtn.disabled = false;
        arriveBtn.disabled = true;

        infoDiv.textContent = `Arriving at ${nextStop}`;
    }

    return {
        depart,
        arrive
    };
}

let result = solve();