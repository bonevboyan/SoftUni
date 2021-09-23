function storeCatalogue(arr) {
    let catalogue = {};

    for (let line of arr) {
        let [item, price] = line.split(' : ');

        if (catalogue[item[0]] === undefined) {
            catalogue[item[0]] = {}
        }

        catalogue[item[0]][item] = price;
    }

    let sortedByFirstLetter = Object.entries(catalogue).sort((a, b) => a[0].localeCompare(b[0]));
    for (let line of sortedByFirstLetter) {
        console.log(line[0]);
        for (let [itemName, itemPrice] of Object.entries(line[1]).sort((a, b) => a[0].localeCompare(b[0]))) {
            console.log(` ${itemName}: ${itemPrice}`)
        }
    }
}
