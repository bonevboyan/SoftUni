function isMagic(array){
    let sum = 0;
    for (let index = 0; index < array[0].length; index++) {
        sum += array[0][index]
    }
    console.log(sum);
    for (let index = 0; index < array.length; index++) {
        let currSum = 0;
        for (let jindex = 0; jindex < array[index].length; jindex++) {
            currSum += array[index][jindex]
        }
        if(currSum != sum){
            return false;
        }
    }
    for (let index = 0; index < array.length; index++) {
        let currSum = 0;
        for (let jindex = 0; jindex < array[index].length; jindex++) {
            currSum += array[jindex][index]
        }
        if(currSum != sum){
            return false;
        }
    }
    return true;
}