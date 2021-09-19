function sumFirstLast(arr){
    arr = arr.map(x => Number(x));
    return arr[0] + arr[arr.length - 1];
}