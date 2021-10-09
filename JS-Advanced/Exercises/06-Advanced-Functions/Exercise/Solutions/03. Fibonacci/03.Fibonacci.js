function getFibonator(){
    let numbers = [0, 1];
    function nextNumber(){
        let next = numbers[numbers.length - 1] + numbers[numbers.length - 2];
        numbers.push(next);
        return numbers[numbers.length - 2];
    }
    return nextNumber;
}
let fib = getFibonator();
console.log(fib()); // 1
console.log(fib()); // 1
console.log(fib()); // 2
console.log(fib()); // 3
console.log(fib()); // 5
console.log(fib()); // 8
console.log(fib()); // 13
