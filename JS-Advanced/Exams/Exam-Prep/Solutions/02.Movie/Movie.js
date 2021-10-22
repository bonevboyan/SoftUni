class Movie {
    constructor(movieName, ticketPrice) {
        this.movieName = movieName;
        this.ticketPrice = Number(ticketPrice);
        this.totalProfit = 0;
        this.ticketsSold = 0;
        this.screenings = [];
    }
    newScreening(date, hall, description) {
        if (this.screenings.some(s => s.date === date && s.hall === hall)) {
            throw new Error(`Sorry, ${hall} hall is not available on ${date}`);
        } else {
            this.screenings.push({
                date,
                hall,
                description
            });
            return `New screening of ${this.movieName} is added.`
        }
    }
    endScreening(date, hall, soldTickets) {
        let currScreening = this.screenings.find(s => s.date === date && s.hall === hall);
        if (typeof currScreening == 'undefined') {
            throw new Error(`Sorry, there is no such screening for ${this.movieName} movie.`);
        } else {
            let currentProfit = soldTickets * this.ticketPrice;
            this.totalProfit += currentProfit;
            this.ticketsSold += soldTickets;
            let currIndex = this.screenings.indexOf(currScreening);
            this.screenings.splice(currIndex, 1);
            return `${this.movieName} movie screening on ${date} in ${hall} hall has ended. Screening profit: ${currentProfit}`;
        }
    }
    toString() {
        return `${this.movieName} full information:\nTotal profit: ${this.totalProfit.toFixed(0)}$\nSold Tickets: ${this.ticketsSold}\n${this.screenings.length != 0 ? 
            `Remaining film screenings:\n${this.screenings.sort((a, b) => a.hall.localeCompare(b.hall)).map(s => `${s.hall} - ${s.date} - ${s.description}`).join('\n')}` :
            "No more screenings"}`;
    }
}