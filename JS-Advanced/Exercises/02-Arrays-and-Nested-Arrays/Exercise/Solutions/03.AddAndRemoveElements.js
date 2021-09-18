function addAndRemoveElements(arr) {
    let num = 0;
    arr = arr.reduce((acc, curr) => {
        num++;
        if(curr == 'add'){
            acc.push(num);
        }else{
            acc.pop(num);
        }
        return acc;
    }, [])
    console.log(arr.length != 0 ? arr.join('\n') : 'Empty');
}