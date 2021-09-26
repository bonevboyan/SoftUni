function sumTable() {
    let tableRowsElements = document.querySelectorAll('table tr');
    let total = 0;

    for(let i = 1; i < tableRowsElements.length; i++) {
        let cols = tableRowsElements[i].children;
        let cost = cols[cols.length - 1].textContent;

        total += Number(cost);
    }

    document.getElementById('sum').textContent = total;
}