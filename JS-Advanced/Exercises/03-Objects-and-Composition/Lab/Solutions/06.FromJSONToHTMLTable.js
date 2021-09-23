function ToHTML(input) {
    let students = JSON.parse(input);
    console.log('<table>');
    let keys = Object.keys(students[0]);
    console.log(keyRow(keys));
 
    for (student of students) {
        let values = Object.values(student);
        console.log(valueRow(values));
    }
    console.log('</table>');
 
    function escapeHTML(htmlCode) {
        const entryMap = {
            "&": "&amp;",
            "<": "&lt;",
            ">": "&gt;",
            '"': "&quot;",
            "'": "&#39;",
        };
 
        return htmlCode
            .toString()
            .replace(/[&<>"']/g, (char) => entryMap[char]);
    }
 
    function keyRow(arr) {
        let result = `   <tr>`;
        arr.forEach(element => {
            result += `<th>${escapeHTML(element)}</th>`;
        });
        result += `</tr>`;
        return result;
    }
 
    function valueRow(arr) {
        let result = `   <tr>`;
        arr.forEach(el => {
            result += `<td>${escapeHTML(el)}</td>`;
        });
        result += `</tr>`;
        return result;
    }
}