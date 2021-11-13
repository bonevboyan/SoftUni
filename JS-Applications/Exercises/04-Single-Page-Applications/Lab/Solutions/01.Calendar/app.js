const yearsCalendar = document.getElementById("years");
const monthCalendars = [...document.getElementsByClassName("monthCalendar")];
const dayCalendar = [...document.getElementsByClassName("daysCalendar")];

const body = document.querySelector("body");

body.innerHTML = '';
body.appendChild(yearsCalendar);

yearsCalendar.addEventListener("click", selectYear);
monthCalendars.forEach(x => x.addEventListener("click", selectMonth));
dayCalendar.forEach(x => x.addEventListener("click", returnToMonth));

const months = {
    'Jan': 1,
    'Feb': 2,
    'Mar': 3,
    'Apr': 4,
    'May': 5,
    'Jun': 6,
    'Jul': 7,
    'Aug': 8,
    'Sep': 9,
    'Oct': 10,
    'Nov': 11,
    'Dec': 12
}

function selectYear(event) {
    event.preventDefault();

    const target = event.target;
    let year;

    if (target.tagName == 'TD') {
        year = target.children[0].textContent;
    } else if (target.tagName == 'DIV') {
        year = target.textContent;
    }

    if (year) {
        body.removeChild(document.querySelector("table").parentElement);
        const newTable = monthCalendars.find(x => x.id == `year-${year}`);
        body.appendChild(newTable);
    }
}

function selectMonth(event) {
    event.preventDefault();

    const target = event.target;
    let monthNumber;

    if (target.tagName == 'TD') {
        monthNumber = months[target.children[0].textContent];
    } else if (target.tagName == 'DIV') {
        monthNumber = months[target.textContent];
    } else if (target.tagName == 'CAPTION') {
        body.removeChild(document.querySelector("table").parentElement);
        body.appendChild(yearsCalendar);
    }

    if (monthNumber) {
        const id = `month-${document.querySelector('caption').textContent}-${monthNumber}`;
        body.removeChild(document.querySelector("table").parentElement);
        body.appendChild(dayCalendar.find(x => x.id == id));
    }
}

function returnToMonth(event) {
    event.preventDefault();

    const target = event.target;

    if (target.tagName == 'CAPTION') {
        const id = `year-${document.querySelector('caption').textContent.split(' ')[1]}`;
        console.log(id)
        body.removeChild(document.querySelector("table").parentElement);
        body.appendChild(monthCalendars.find(x => x.id == id));
    }
}