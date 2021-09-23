function solve(data){
    let list = [];
    for (const element of data){
        if(typeof element === 'number'){
            list.push(element);
        }else{
            if (list.length >= 2){
                let b = list.pop();
                let a = list.pop();
                list.push(eval(`${a}${element}${b}`));
            }else{
                return 'Error: not enough operands!';
            }
        }
    }

    if (list.length > 1){
        return 'Error: too many operands!';
    }else{
        return list[0];
    }
}