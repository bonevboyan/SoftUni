function pie(arr, start, end){
    let shouldCount = false;
    return arr.reduce((acc, curr) => {
        if(curr == start) {
            shouldCount = true;
        }
        if(shouldCount){
            acc.push(curr);
        }
        if(curr == end) {
            shouldCount = false;
        }
        return acc;
    }, [])
}