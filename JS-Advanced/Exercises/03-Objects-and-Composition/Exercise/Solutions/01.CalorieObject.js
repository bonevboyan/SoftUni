function calorie(arr){
    let food = arr.filter((element, index) => {
        if(index % 2 == 0){
            return element;
        }
    });
    let calories = arr.filter((element, index) => {
        if(index % 2 == 1){
            return element;
        }
    });
    let obj = {

    }
    for (let index = 0; index < food.length; index++) {
        obj[food[index]] = Number(calories[index]);
    }
    console.log(obj)
}