function showArgumentInfo() {
    let record = [];
    for(var i = 0; i < arguments.length; i++){
        let type = typeof arguments[i];
        console.log(`${type}: ${arguments[i]}`);
        if(!record.hasOwnProperty(typeof arguments[i])){
            record[type] = 1;
        }else{
            record[type]++;
        }
    }
    Object.keys(record).sort((a, b) => record[b] - record[a]).forEach(k => console.log(`${k} = ${record[k]}`));
}