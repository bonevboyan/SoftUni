function solve(juicesArr) {
    let juicesAmount = new Map();
    let juicesBottles = new Map();

    for (let i = 0; i < juicesArr.length; i++) {
        let [juiceName, juiceQuantity] = juicesArr[i].split(' => ');
        juiceQuantity = Number(juiceQuantity);

        if (!juicesAmount.has(juiceName)) {
            juicesAmount.set(juiceName, 0);
        }

        let totalAmount = juicesAmount.get(juiceName) + juiceQuantity;

        if (totalAmount >= 1000) {
            if (!juicesBottles.has(juiceName)) {
                juicesBottles.set(juiceName, 0);
            }

            let newBottles = Math.trunc(totalAmount / 1000);
            let totalBottles = juicesBottles.get(juiceName) + newBottles;

            juicesBottles.set(juiceName, totalBottles);
        }

        juicesAmount.set(juiceName, totalAmount % 1000);
    }

    return [...juicesBottles].map(([key, value]) => `${key} => ${value}`).join('\n');
}