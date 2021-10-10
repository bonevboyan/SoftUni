function add(init) {
    let sum = init;

    function addUp(num) {
        sum += num;
        return addUp;
    }

    addUp.toString = () => sum;

    return addUp;
}