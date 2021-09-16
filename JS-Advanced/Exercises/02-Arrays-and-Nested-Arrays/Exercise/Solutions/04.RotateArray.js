function rotate(arr) {
    let step = parseFloat(arr[arr.length - 1])
    arr = arr.slice(0, arr.length - 1)
    var num = 0;
    for (let index = 0; index < step; index++) {
        num = arr[arr.length - 1]
        arr.pop()
        arr.splice(0, 0, num)
    }
    console.log(arr.join(' '))
}