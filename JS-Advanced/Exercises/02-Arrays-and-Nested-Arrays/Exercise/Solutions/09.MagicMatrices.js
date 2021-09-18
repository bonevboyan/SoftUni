function isMagic(array){
    if(array.length != array[0].length){
        return false;
    }
    let sum = array[0].reduce((arr, curr) => curr + arr, 0);
    for (let index = 1; index < array.length; index++) {
        let currSum = array[index].reduce((arr, curr) => curr + arr, 0);
        if(currSum != sum){
            return false;
        }
    }
    for (let i = 0; i < array.length; i++) {
        let currSum = 0;
        for (let j = 0; j < array[i].length; j++) {
            currSum += array[j][i];
        }
        if(currSum != sum){
            return false;
        }
    }
    return true;
}