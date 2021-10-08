function solution(num){
    function add(addition){
        return num + addition;
    }
    return add;
}
let add5 = solution(5);
console.log(add5(2));
console.log(add5(3));
