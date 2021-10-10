function calculator() {
    let number1;
    let number2;
    let result;

    return {
        init(num1 ,num2, res) {
            number1 = document.querySelector(num1);
            number2 = document.querySelector(num2);
            result = document.querySelector(res);
        },
        add() {
            result.value = Number(number1.value) + Number(number2.value);
        },
        subtract() {
            result.value = Number(number1.value) - Number(number2.value);
        }
    }
}
const calculate = calculator (); 
calculate.init ('#num1', '#num2', '#result'); 