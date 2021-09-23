function towns(arr){
    let towns = [];
    for (const iterator of arr.slice(1)) {
        let re = /([a-zA-Z0-9. -?])+/g;
        let [town, lat, lng] = iterator.match(re);
        town = town.trim(); 
        lat = Number(Number(lat).toFixed(2));
        lng = Number(Number(lng).toFixed(2));

        let newTown = {
            "Town": town,
            "Latitude": lat,
            "Longitude": lng
        }
        towns.push(newTown);
    }
    return JSON.stringify(towns);
}