function lookupChar(string, index) {
    if (!Number.isInteger(index)) {
        return undefined;
    }
    if (string.length <= index || index < 0) {
        return "Incorrect index";
    }

    return string.charAt(index);
}
console.log(Number.isInteger(5.5))
module.exports = { lookupChar };