function subtract() {
    let n1 = Number(document.getElementById("firstNumber").value);
    let n2 = Number(document.getElementById("secondNumber").value);

    let div = document.getElementById("result");

    div.textContent += n1 - n2;
    
}