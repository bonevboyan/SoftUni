function attachEvents() {
    document.getElementById("submit").addEventListener("click", displayWeather);
    let forecastDiv = document.getElementById("forecast");
    forecastDiv.style.display = "block";

    let symbols = {
        "Sunny": "☀",
        "Partly sunny": "⛅",
        "Overcast": "☁",
        "Rain": "☂",
        "Degrees": "°"
    }
    
    async function displayWeather(e) {
        if(isError){
            forecastDiv.innerHTML = '<div id="current"><div class="label">Current conditions</div></div><div id="upcoming"><div class="label">Three-day forecast</div></div>'
            isError = false;
        }
        try {
            let response = await fetch("http://localhost:3030/jsonstore/forecaster/locations");
            if (response.ok == false) {
                throw new Error(`${response.status} ${response.statusText}`)
            }
            let locations = await response.json();

            let inputLocation = document.getElementById("location").value;
            let location = locations.find(x => x.name == inputLocation);

            if (typeof location === "undefined") {
                throw new Error('Invalid Input');
            }

            response = await fetch(`http://localhost:3030/jsonstore/forecaster/today/${location.code}`)
            if (response.ok == false) {
                throw new Error(`${response.status} ${response.statusText}`)
            }
            let today = await response.json();

            response = await fetch(`http://localhost:3030/jsonstore/forecaster/upcoming/${location.code}`)
            if (response.ok == false) {
                throw new Error(`${response.status} ${response.statusText}`)
            }
            let upcoming = await response.json();

            let forecast = document.createElement("div");
            forecast.classList.add("forecasts");

            forecast.innerHTML = `<span class="condition symbol">${symbols[today.forecast.condition]}</span>` +
                `<span class="condition">` +
                `<span class="forecast-data">${today.name}</span>` +
                `<span class="forecast-data">${today.forecast.low}°/${today.forecast.high}°</span>` +
                `<span class="forecast-data">${today.forecast.condition}</span> </span>`;

            forecastDiv.children[0].appendChild(forecast);

            let forecastInfo = document.createElement("div");
            forecastInfo.classList.add("forecast-info");

            forecastInfo.innerHTML = 
                `<span class="upcoming">` +
                `<span class="symbol">${symbols[upcoming.forecast[0].condition]}</span>`+
                `<span class="forecast-data">${upcoming.forecast[0].low}°/${upcoming.forecast[0].high}°</span>`+
                `<span class="forecast-data">${upcoming.forecast[0].condition}</span> </span>`+
                `<span class="upcoming">`+
                `<span class="symbol">${symbols[upcoming.forecast[1].condition]}</span>`+
                `<span class="forecast-data">${upcoming.forecast[1].low}°/${upcoming.forecast[0].high}°</span>`+
                `<span class="forecast-data">${upcoming.forecast[1].condition}</span> </span>`+
                `<span class="upcoming">`+
                `<span class="symbol">${symbols[upcoming.forecast[2].condition]}</span>`+
                `<span class="forecast-data">${upcoming.forecast[2].low}°/${upcoming.forecast[0].high}°</span>`+
                `<span class="forecast-data">${upcoming.forecast[2].condition}</span> </span>`

            forecastDiv.children[1].appendChild(forecastInfo);


        } catch (error) {
            forecastDiv.children[0].children[0].textContent = 'Error';
        }
    }
}

attachEvents();