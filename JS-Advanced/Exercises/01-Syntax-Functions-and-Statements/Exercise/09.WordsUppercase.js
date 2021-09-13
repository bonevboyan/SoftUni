function coffee(str){
    let re = /(\w+)/g;
    let array = str.match(re).map(x => x.toUpperCase());
    console.log(`${array.join(', ')}`)
}