function hero(input){
    let heroInfo = [];
    for (const item of input) {
        let [name, level, items] = item.split(' / ');
        level = Number(level);

        items = items ? items.split(', ') : [];

        heroInfo.push({name, level, items});
    }
    console.log(JSON.stringify(heroInfo))
}