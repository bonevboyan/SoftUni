function createAssemblyLine() {
    return {
        hasClima(car) {
            car.temp = 23;
            car.tempSettings = 23;
            car.adjustTemp = () => {
                if (car.temp < car.tempSettings) {
                    car.temp++;
                } else if (car.temp > car.tempSettings) {
                    car.temp--;
                }
            };
        },
        hasAudio(car) {
            car.currentTrack = null;
            car.nowPlaying = () => {
                console.log(`Now playing ${car.currentTrack.name} by ${car.currentTrack.artist}`);
            };
        },
        hasParktronic(car) {
            car.checkDistance = (distance) => {
                let signal = '';
                if (distance < 0.5) {
                    signal = 'Beep!';
                } else if (distance < 0.25) {
                    signal = 'Beep! Beep!';
                } else if (distance < 0.1) {
                    signal = 'Beep! Beep! Beep!';
                }
                console.log(signal);
            };
        }
    };
}