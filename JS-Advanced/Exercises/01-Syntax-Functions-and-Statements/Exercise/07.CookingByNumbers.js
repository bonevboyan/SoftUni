function cook(num, ...arr){
    let number = parseInt(num);
    for (let index = 0; index < arr.length; index++) {
        switch(arr[index]){
            case 'chop':
                num /= 2;
                break;
            case 'dice':
                num = Math.sqrt(num);
                break;
            case 'spice':
                num++;
                break;
            case 'bake':
                num *= 3;
                break;
            case 'fillet':
                num *= 0.80;
                break;
        }
        console.log(`${num}`);
    }
}