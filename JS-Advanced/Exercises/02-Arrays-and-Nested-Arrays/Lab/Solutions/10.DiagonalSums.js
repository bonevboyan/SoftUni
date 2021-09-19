function diagonalSums(arr) {
    let mainSum = 0, secSum = 0;
    for (let index = 0; index < arr.length; index++) {
        mainSum += arr[index][index];
        secSum += arr[index][arr.length - index - 1];
    }
    console.log(mainSum + ' ' + secSum);
}