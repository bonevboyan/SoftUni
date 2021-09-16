function find(arr){
    let newArr = []
    let longestArr = []
    let prevElement = -Infinity
    for (let index = 0; index < arr.length; index++) {
        if(prevElement < arr[index]){
            newArr.push(arr[index])
        }else{
            if(longestArr.length < newArr.length){
                longestArr = newArr
            }
            newArr = []
        }
        prevElement = arr[index]
        
    }
    console.log(longestArr)
}