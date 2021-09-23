function lowestPrice(arr){
    let items = {};
    for (const iterator of arr) {
        let [townName, productName, productPrice] = iterator.split(' | ');
        productPrice = Number(productPrice);

        if (!items.hasOwnProperty(productName)) {
            items[productName] = {};
        }

        items[productName][townName] = productPrice;
    }
    for (let product in items) {
        let sorted = Object.entries(items[product]).sort((a, b) => a[1] - b[1]);
        console.log(`${product} -> ${sorted[0][1]} (${sorted[0][0]})`);
    }
}