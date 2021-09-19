function bigger(arr){
    return arr.sort((a, b) => a - b).slice(arr.length / 2, arr.length);
}