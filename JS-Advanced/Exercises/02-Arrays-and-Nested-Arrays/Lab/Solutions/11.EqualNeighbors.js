function neighbors(arr) {
    let count = 0;
    for (let row = 0; row < arr.length; row++) {
        for (let col = 0; col < arr[row].length; col++) {
            if (row < arr.length - 1) {
                if (arr[row][col] == arr[row + 1][col]) {
                    count++;
                }
            }
            if (col < arr[row].length) {
                if (arr[row][col] == arr[row][col + 1]) {
                    count++;
                }
            }
        }
    }
    return count;
}