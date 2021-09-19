function odd(arr){
    console.log(arr.map(x => Number(x)).filter((element, index) =>{
        if(index % 2 == 1){
            return true;
        }
    }).map(x => x * 2).reverse().join(' '))
}
odd([3, 0, 10, 4, 7, 3])