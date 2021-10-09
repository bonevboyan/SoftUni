function sort(arr, arg){
    arr.sort((a,b) => a - b);
    if(arg == 'asc'){
        return arr;
    }else{
        return arr.reverse();
    }
}