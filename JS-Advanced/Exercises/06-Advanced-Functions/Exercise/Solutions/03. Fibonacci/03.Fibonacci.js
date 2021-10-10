function getFibonator(){
    let numbers = [0, 1];
    function nextNumber(){
        let next = numbers[numbers.length - 1] + numbers[numbers.length - 2];
        numbers.push(next);
        return numbers[numbers.length - 2];
    }
    return nextNumber;
}
