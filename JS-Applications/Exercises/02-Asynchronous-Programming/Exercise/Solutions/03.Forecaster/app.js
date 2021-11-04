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

    async function getLocations() {
        let response = await fetch("http://localhost:3030/jsonstore/forecaster/locations");
        if (response.ok == false) {
            throw new Error(`${response.status} ${response.statusText}`)
        }
        return await response.json();
    }

    async function getWeather(time, locationCode) {
        response = await fetch(`http://localhost:3030/jsonstore/forecaster/${time}/${locationCode}`)
        if (response.ok == false) {
            throw new Error(`${response.status} ${response.statusText}`)
        }
        return await response.json();
    }

    async function displayWeather(e) {
        forecastDiv.innerHTML = '<div id="current"><div class="label">Current conditions</div></div><div id="upcoming"><div class="label">Three-day forecast</div></div>'

        try {
            let locations = await getLocations();

            let inputLocation = document.getElementById("location").value;
            let location = locations.find(x => x.name == inputLocation);

            if (typeof location === "undefined") {
                throw new Error('Invalid Input');
            }

            let [today, upcoming] = await Promise.all([getWeather("today", location.code), getWeather("upcoming", location.code)]);

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
                `<span class="symbol">${symbols[upcoming.forecast[0].condition]}</span>` +
                `<span class="forecast-data">${upcoming.forecast[0].low}°/${upcoming.forecast[0].high}°</span>` +
                `<span class="forecast-data">${upcoming.forecast[0].condition}</span> </span>` +
                `<span class="upcoming">` +
                `<span class="symbol">${symbols[upcoming.forecast[1].condition]}</span>` +
                `<span class="forecast-data">${upcoming.forecast[1].low}°/${upcoming.forecast[1].high}°</span>` +
                `<span class="forecast-data">${upcoming.forecast[1].condition}</span> </span>` +
                `<span class="upcoming">` +
                `<span class="symbol">${symbols[upcoming.forecast[2].condition]}</span>` +
                `<span class="forecast-data">${upcoming.forecast[2].low}°/${upcoming.forecast[2].high}°</span>` +
                `<span class="forecast-data">${upcoming.forecast[2].condition}</span> </span>`

            forecastDiv.children[1].appendChild(forecastInfo);


        } catch (error) {
            forecastDiv.children[0].children[0].textContent = 'Error';
            console.log(error.message)
        }
    }
}

attachEvents();