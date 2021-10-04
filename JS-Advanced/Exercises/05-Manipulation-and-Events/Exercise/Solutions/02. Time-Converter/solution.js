function attachEventsListeners() {
    let days = document.getElementById('days');
    let hours = document.getElementById('hours');
    let minutes = document.getElementById('minutes');
    let seconds = document.getElementById('seconds');

    document.getElementById('daysBtn').addEventListener('click', (e) => {
        hours.value = Number(days.value) * 24;
        minutes.value = Number(days.value) * 24 * 60;
        seconds.value = Number(days.value) * 24 * 60 * 60;
    });

    document.getElementById('hoursBtn').addEventListener('click', (e) => {
        days.value = Number(hours.value) / 24;
        minutes.value = Number(hours.value) * 60;
        seconds.value = Number(hours.value) * 60 * 60;
    });

    document.getElementById('minutesBtn').addEventListener('click', (e) => {
        days.value = Number(minutes.value) / 60 / 24;
        hours.value = Number(minutes.value) / 60
        seconds.value = Number(minutes.value) * 60
    });

    document.getElementById('secondsBtn').addEventListener('click', (e) => {
        days.value = Number(seconds.value) / 60 / 60 / 24;
        hours.value = Number(seconds.value) / 60 / 60;
        minutes.value = Number(seconds.value) / 60;
    });
}