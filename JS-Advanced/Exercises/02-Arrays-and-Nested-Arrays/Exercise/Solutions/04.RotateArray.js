function rotate(arr, number) {
    for (let index = 0; index < number; index++) {
        let element = arr[arr.length - 1];
        arr.pop();
        arr.unshift(element);
    }
    console.log(arr.join(' '));
}