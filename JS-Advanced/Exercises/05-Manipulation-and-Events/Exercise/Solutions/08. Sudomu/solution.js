function solve() {
    document.getElementsByTagName("button")[0].addEventListener("click", onCheck);

    document.getElementsByTagName("button")[1].addEventListener("click", onClear);

    let htmlTable = document.querySelector("table tbody");

    let outputElement = document.getElementById("check").children[0];

    function onCheck(ev){
        let myTable = [];
        
        for (i = 0; i < htmlTable.rows.length; i++) {
            
            let objCells = htmlTable.rows.item(i).cells;
            let tableRow = [];
            
            for (let j = 0; j < objCells.length; j++) {
                tableRow.push(Number(objCells.item(j).children[0].value));
            }
            myTable.push(tableRow);
        }

        if(sudokuIsSolved(myTable)){
            htmlTable.parentElement.style.border = "2px solid green";
            outputElement.textContent = "You solve it! Congratulations!";
            outputElement.style.color = "green";
        }else{
            htmlTable.parentElement.style.border = "2px solid red";
            outputElement.textContent = "NOP! You are not done yet...";
            outputElement.style.color = "red";
        }
    }
    function onClear(ev){
        for (i = 0; i < htmlTable.rows.length; i++) {
            let objCells = htmlTable.rows.item(i).cells;
            for (let j = 0; j < objCells.length; j++) {
                objCells.item(j).children[0].value = "";
            }
        }
        htmlTable.parentElement.style.border = "";
        outputElement.textContent = "";
    }
    function sudokuIsSolved(array) {
        let f = true;
        for (let index = 0; index < array.length; index++) {
            if((new Set(array[index])).size !== array[index].length){
                f = false;
            }
        }
        for (let index = 0; index < array.length; index++) {
            if(array[0][index] == array[1][index] == array[2][index]){
                f = false;
            }
        }
        return f;
    }
}