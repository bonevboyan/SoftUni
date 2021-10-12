function solve(value, suit){
    const values = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];

    const suits = {
        S: '\u2660',
        H: '\u2665',
        D: '\u2666',
        C: '\u2663'
    }

    if(!values.includes(value) || suits[suit] === undefined){
        throw new Error('Error');
    }

    return `${values[values.indexOf(value)]}${suits[suit]}`
}