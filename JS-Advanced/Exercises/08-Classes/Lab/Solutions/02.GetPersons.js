const { Person } = require('./01.Person');

function getPersons(){
    return [new Person('Anna', 'Simpson', 22, 'anna@yahoo.com'),
            new Person('SoftUni'),
            new Person('Anna', 'Johnson', 25),
            new Person('Gabriel', 'Peterson', 24, 'g.p@gmail.com')];
}