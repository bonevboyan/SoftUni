function names(arr){
    console.log(arr.sort((a, b) => a.localeCompare(b)).map((element, index) => `${index + 1}.${element}`).join('\n'));
}