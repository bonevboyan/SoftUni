function solve() {
    let input = document.getElementById('input');
    let result = document.getElementById('result');
    let selectMenuTo = document.getElementById('selectMenuTo');

    let optionBinary = document.createElement('option');
    optionBinary.value = 'Binary';
    optionBinary.innerHTML = 'Binary';

    let optionHexadecimal = document.createElement('option');
    optionHexadecimal.value = 'Hexadecimal';
    optionHexadecimal.innerHTML = 'Hexadecimal';

    selectMenuTo.appendChild(optionBinary);
    selectMenuTo.appendChild(optionHexadecimal);

    document.getElementsByTagName('button')[0].addEventListener("click", calculate);

    function calculate() {
        if (selectMenuTo.value === 'binary') {
            result.value = Number(input.value).toString(2);
        } else if (selectMenuTo.value === 'hexadecimal') {
            result.value = Number(input.value).toString(16).toUpperCase();
        }
    }
}