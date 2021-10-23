class SummerCamp {
    constructor(organizer, location) {
        this.organizer = organizer;
        this.location = location;
        this.priceForTheCamp =
        {
            "child": 150,
            "student": 300,
            "collegian": 500
        }
        this.listOfParticipants = [];
    }
    registerParticipant(name, condition, money) {
        money = Number(money);

        if (!this.priceForTheCamp[condition]) {
            throw new Error("Unsuccessful registration at the camp.");
        }

        if (this.listOfParticipants.some(x => x.name == name)) {
            return `The ${name} is already registered at the camp.`;
        }

        if (this.priceForTheCamp[condition] > money) {
            return `The money is not enough to pay the stay at the camp.`;
        }

        this.listOfParticipants.push({
            name,
            condition,
            power: 100,
            wins: 0
        });

        return `The ${name} was successfully registered.`;
    }
    unregisterParticipant(name) {
        if (!this.listOfParticipants.some(x => x.name == name)) {
            throw new Error(`The ${name} is not registered in the camp.`);
        }

        this.listOfParticipants = this.listOfParticipants.filter(x => x.name != name);

        return `The ${name} removed successfully.`;
    }
    timeToPlay(typeOfGame, participant1, participant2) {
        if (typeOfGame == "WaterBalloonFights") {
            participant1 = this.listOfParticipants.find(x => x.name == participant1);
            participant2 = this.listOfParticipants.find(x => x.name == participant2);

            if (!participant1 || !participant2) {
                throw new Error(`Invalid entered name/s.`);
            }

            if (participant1.condition != participant2.condition) {
                throw new Error(`Choose players with equal condition.`);
            }

            if (participant1.power > participant2.power) {
                participant1.wins++;
                return `The ${participant1.name} is winner in the game ${typeOfGame}.`;
            } else if (participant2.power > participant1.power) {
                participant2.wins++;
                return `The ${participant2.name} is winner in the game ${typeOfGame}.`;
            } else {
                return `There is no winner.`;
            }
            
        } else if (typeOfGame == "Battleship") {
            participant1 = this.listOfParticipants.find(x => x.name == participant1);

            if (!participant1) {
                throw new Error(`Invalid entered name/s.`);
            }

            participant1.power += 20;

            return `The ${participant1.name} successfully completed the game ${typeOfGame}.`
        }
    }
    toString() {
        let output = `${this.organizer} will take ${this.listOfParticipants.length} participants on camping to ${this.location}\n`;

        let participants = this.listOfParticipants.sort((a, b) => b.wins - a.wins).map(x => `${x.name} - ${x.condition} - ${x.power} - ${x.wins}`).join('\n');

        return output + participants;
    }
}
let camp = new SummerCamp('Jane Austen', 'Pancharevo Sofia 1137, Bulgaria');
console.log(camp.registerParticipant('Petar Petarson', 'child', 300));
console.log(camp.registerParticipant('Sara Dickinson', 'child', 200));
console.log(camp.timeToPlay('Battleship', 'Sara Dickinson'));
console.log(camp.timeToPlay('WaterBalloonFights', 'Sara Dickinson', 'Petar Petarson'));
console.log(camp.toString());