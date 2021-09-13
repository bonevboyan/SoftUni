function timeToWalk(step, length, speed){
    let distance = step * length;
    let time = distance / 1000 / speed + Math.floor(distance / 500) / 60;

    let hours = Math.floor(time);

    time -= hours;
    time *= 60;
    let minutes = Math.floor(time)

    time -= minutes;
    time *= 60;
    let seconds = Math.ceil(time);

    console.log(`${('0' + hours).slice(-2)}:${('0' + minutes).slice(-2)}:${Math.round(('0' + seconds).slice(-2))}`);
}

timeToWalk(2564, 0.70, 5.5)