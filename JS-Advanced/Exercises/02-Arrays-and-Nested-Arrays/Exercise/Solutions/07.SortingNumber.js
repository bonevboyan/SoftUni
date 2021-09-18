function sort(arr){
    return arr.sort((a, b) => a - b).reduce((acc, curr, index, array) => {
        acc.push(array[index]);
        acc.push(array[array.length - index - 1]);
        return acc;
    }, [])
}
console.log(
sort([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]))