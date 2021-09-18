function find(arr){
    let biggestNum = arr[0];
    let longestArr = arr.reduce((acc, curr, index, array) => {
        if(biggestNum <= curr){
            acc.push(curr);
            biggestNum = curr;
        } 
        return acc;
    }, [])
    return longestArr;
}