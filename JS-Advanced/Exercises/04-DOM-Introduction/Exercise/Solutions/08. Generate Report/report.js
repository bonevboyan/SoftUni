function generateReport() {
    let result = [];
    const thead = document.querySelector('thead tr').children;
    
    const rows = document.querySelector('tbody').children;
    for (const row of Array.from(rows)) {
        let rowObj = {};
        for (let i = 0; i < row.children.length; i++) {
            if (thead[i].lastElementChild.checked) {
                rowObj[thead[i].lastChild.name] = row.children[i].textContent;
            }
        }
        result.push(rowObj);
    }

    document.getElementById('output').textContent = JSON.stringify(result);
}