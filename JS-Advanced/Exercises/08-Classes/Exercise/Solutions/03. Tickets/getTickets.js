function getTickets(ticketsArr, sortingCriteria) {
    class Ticket {
        constructor(destination, price, status) {
            this.destination = destination;
            this.price = Number(price);
            this.status = status;
        }
    }

    let tickets = [];

    for (let ticket of ticketsArr) {
        let info = ticket.split('|');
        tickets.push(new Ticket(...info))
    }

    let sorted = tickets.sort((a, b) => {
        if (sortingCriteria == 'destination' || sortingCriteria == 'status') {
            return a[sortingCriteria].localeCompare(b[sortingCriteria]);
        } else if (sortingCriteria == 'price') {
            return a.price - b.price;
        }
    })

    return sorted;
}