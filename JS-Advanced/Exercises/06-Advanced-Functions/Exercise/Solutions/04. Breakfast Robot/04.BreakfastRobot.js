function solution() {
    const microelements = {
        protein: 0,
        carbohydrate: 0,
        fat: 0,
        flavour: 0
    };

    const recipies = {
        apple: [0, 1, 0, 2],
        lemonade: [0, 10, 0, 20],
        burger: [0, 5, 7, 3],
        eggs: [5, 0, 1, 1],
        turkey: [10, 10, 10, 10],
    }

    function robot(command) {
        let [action, food, quantity] = command.split(' ');
        if (action == "restock") {
            microelements[food] += Number(quantity);
            return "Success";
        } else if (action === "prepare") {
            for (let index = 0; index < quantity; index++) {
                if (microelements.protein < recipies[food][0]) {
                    return `Error: not enough protein in stock`;
                }
                if (microelements.carbohydrate < recipies[food][1]) {
                    return `Error: not enough carbohydrate in stock`;
                }
                if (microelements.fat < recipies[food][2]) {
                    return `Error: not enough fat in stock`;
                }
                if (microelements.flavour < recipies[food][3]) {
                    return `Error: not enough flavour in stock`;
                }
    
                microelements.protein -= recipies[food][0];
                microelements.carbohydrate -= recipies[food][1];
                microelements.fat -= recipies[food][2];
                microelements.flavour -= recipies[food][3];
            }
            return "Success";
        } else if (action == "report") {
            return `protein=${microelements.protein} carbohydrate=${microelements.carbohydrate} fat=${microelements.fat} flavour=${microelements.flavour}`
        }
    }
    return robot;
}