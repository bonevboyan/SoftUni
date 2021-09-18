function print(arr, step){
    return arr.filter((x, index) => {
        if(index % step == 0){
            return x;
        }
    });
}