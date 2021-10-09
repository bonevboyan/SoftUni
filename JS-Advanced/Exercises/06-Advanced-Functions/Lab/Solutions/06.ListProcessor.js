function processList(arr){
    let output = [];
    for (const command of arr) {
        let tokens = command.split(' ');
        if(tokens.length == 2){
            eval(`${tokens[0]}("${tokens[1]}")`);
        }else{
            console.log(output.join(','))
        }
    }
    function add(element){
        output.push(element);
    }
    function remove(element){
        while(output.includes(element)){
            output.splice(output.indexOf(element), 1);
        }
    }
}