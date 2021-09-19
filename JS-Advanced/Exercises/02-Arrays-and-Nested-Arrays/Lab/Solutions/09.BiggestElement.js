function big(arr) {
    return arr.reduce((acc, curr) => {
        return acc.concat(curr);
    }, []).reduce((a, b) => {
        return Math.max(a, b);
    }, -Infinity);
}