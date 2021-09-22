function main(input){
    let heroInfo = [];
    for (let index = 0; index < input.length; index++) {
        let currHero = input[index].split(' / ');
         
        let heroName = currHero[0];
        let heroLevel = Number (currHero[1]);
        let heroItems = currHero[2].split(", ");

        let hero = {
            name: heroName,
            level: heroLevel,
            items: heroItems
        }

        heroInfo.push(hero);
    }
    console.log(JSON.stringify(heroInfo))
}