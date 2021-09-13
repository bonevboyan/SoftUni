function isOverLimit(speed, area){
    let limit = 0;
    switch(area){
        case 'motorway':
            limit = 130;
            break;
        case 'interstate':
            limit = 90;
            break;
        case 'city':
            limit = 50;
            break;
        case 'residential':
            limit = 20;
            break;
    }
    if(speed > limit){
        let message = `The speed is ${speed - limit} km/h faster than the allowed speed of ${limit} - `
        if(speed - limit <= 20){
            message += 'speeding';
        }else if(speed - limit <= 40){
            message += 'excessive speeding';
        }else{
            message += 'reckless driving';
        }
        console.log(message);
    }else{
        console.log(`Driving ${speed} km/h in a ${limit} zone`);
    }
}