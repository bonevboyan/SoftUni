function printDeckOfCards(cards) {
    try {
        let output = [];
        for (const iterator of cards) {
            let tokens = iterator.split("");
            if (tokens.length == 3) {
                output.push(createCard(tokens[0] + tokens[1], tokens[2]));
            } else {
                output.push(createCard(tokens[0], tokens[1]));
            }
        }
        console.log(output.join(" "))
    } 
    catch (e) {
        console.log(e.message);
    }

    function createCard(value, suit) {
        const values = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];

        const suits = {
            S: '\u2660',
            H: '\u2665',
            D: '\u2666',
            C: '\u2663'
        }

        if (!values.includes(value) || suits[suit] === undefined) {
            throw new Error(`Invalid card: ${value}${suit}`);
        }

        return `${value}${suits[suit]}`
    }
}