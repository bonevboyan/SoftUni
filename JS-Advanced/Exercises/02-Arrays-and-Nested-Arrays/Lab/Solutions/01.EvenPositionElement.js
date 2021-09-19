function evenElements(arr){
    console.log(arr.filter((element, index) => {
        if(index % 2 ==0){
            return element;
        }
    }).join(' '))
}