function fibb(n, k){
    let arr = [1];
    for (let index = 1; index < n; index++) {
        arr.push(arr.slice(Math.max(index - k, 0), index).reduce((arr, curr) => arr + curr, 0));
    }
    return arr;
}