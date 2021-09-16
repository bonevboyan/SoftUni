function print(arr){
    let step = parseFloat(arr[arr.length - 1])
    arr = arr.slice(0, arr.length - 1)
    for (let index = 0; index < arr.length; index+=step) {
        console.log(arr[index])
        
    }
}