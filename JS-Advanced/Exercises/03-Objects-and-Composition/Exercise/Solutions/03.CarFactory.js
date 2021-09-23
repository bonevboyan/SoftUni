function carFactory(description){
    let power = description.power;
    let volume = 0;

    if(power <= 90){
        power = 90;
        volume = 1800;
    }else if(power <= 120){
        power = 120;
        volume = 2400;
    }else if(power <= 200){
        power = 200;
        volume = 3500;
    }

    let wheelsize = description.wheelsize % 2 == 1 ? description.wheelsize : description.wheelsize - 1;

    let car = {
        model: description.model,
        engine: {
            power: power,
            volume: volume
        },
        carriage: {
            type: description.carriage,
            color: description.color
        },
        wheels: [wheelsize, wheelsize, wheelsize, wheelsize]
    }
    return car;
}