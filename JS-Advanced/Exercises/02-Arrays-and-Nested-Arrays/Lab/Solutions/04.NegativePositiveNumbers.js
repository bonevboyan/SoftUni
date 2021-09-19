function negativePositive(arr){
    console.log(arr.reduce((acc, curr) => {
        if(curr >= 0){
            acc.push(curr)
        }else{
            acc.unshift(curr);
        }
        return acc;
    },[]))
}