function sameNumbers(number){
    let f = true;
    let ch = number % 10;
    let sum = ch;

    for(let i = Math.floor(number / 10); i != 0; i = Math.floor(i/10)){
        sum += i % 10;
        if(i % 10 != ch){
            f = false;
        }
    }

    console.log(f);
    console.log(sum);
}