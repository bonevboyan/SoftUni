function print(arr){
    let dl = arr[arr.length - 1]
    arr = arr.slice(0, arr.length - 1)
    console.log(arr.join(dl))
}