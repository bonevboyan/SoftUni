function diagonalsAttack(matrixRows) {
    let matrix = matrixRows.map(row => row.split(' ').map(Number));
 
    let sumFirstDiagonal = 0;
    for (let i = 0; i < matrix.length; i++) {
        sumFirstDiagonal = sumFirstDiagonal + matrix[i][i];
    }
    let sumSecondDiagonal = 0;
    for (let j = 0; j < matrix.length; j++) {
        sumSecondDiagonal = sumSecondDiagonal + matrix[j][matrix.length-1-j];
    }
 
    if (sumFirstDiagonal == sumSecondDiagonal){
        for (let i = 0; i < matrix.length; i++) {
            for (let j = 0; j < matrix.length; j++) {
                if( i != j && i != matrix.length-1-j)  {
                    matrix[i][j] = sumFirstDiagonal;
                }
            }
        }
        for (let i = 0; i < matrix.length; i++) {
            console.log(matrix[i].join(' '))
        }
    }else{
        for (let i = 0; i < matrix.length; i++) {
            console.log(matrix[i].join(' '))
        }
    }
}