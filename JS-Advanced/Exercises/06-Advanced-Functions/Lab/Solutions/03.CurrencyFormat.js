function createFormatter(separator, symbol, symbolFirst, formatter){
    function format(value){
        return formatter(separator, symbol, symbolFirst, value);
    }
    return format;
}

function currencyFormatter(separator, symbol, symbolFirst, value) {
    let result = Math.trunc(value) + separator;
    result += value.toFixed(2).substr(-2,2);
    if (symbolFirst) return symbol + ' ' + result;
    else return result + ' ' + symbol;
}