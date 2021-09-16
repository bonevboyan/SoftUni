function fruit(fruit, weight, price){
    let cost = weight * price / 1000;
    let weightInKG = weight / 1000;
    console.log(`I need $${cost.toFixed(2)} to buy ${weightInKG.toFixed(2)} kilograms ${fruit}.`);
}