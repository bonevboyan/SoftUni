async function attachEvents() {
    document.getElementById("submit").addEventListener("click", onSubmit);

    const firstName = document.querySelector('input[name="firstName"]');
    const lastName = document.querySelector('input[name="lastName"]');
    const facultyNumber = document.querySelector('input[name="facultyNumber"]');
    const grade = document.querySelector('input[name="grade"]');

    const table = document.querySelector('#results tbody');

    const url = "http://localhost:3030/jsonstore/collections/students";

    const students = await getStudents();
    students.forEach(addToTable);

    function addToTable(student) {
        const newRow = document.createElement('tr');

        for (const key in student) {
            if (key !== '_id') {
                const newCell = document.createElement('th');
                newCell.textContent = student[key];
                newRow.appendChild(newCell);
            }
        }

        table.appendChild(newRow);
    }

    function onSubmit(ev) {
        ev.preventDefault();
        const newStudent = {
            FirstName: firstName.value,
            LastName: lastName.value,
            FacultyNumber: facultyNumber.value,
            Grade: Number(grade.value)
        }

        if (Object.entries(newStudent).some(x => x[1] === '') ||
            isNaN(newStudent.Grade) ||
            newStudent.FacultyNumber.split('').some(x => isNaN(Number(x)))) {
            return;
        }

        postStudent(newStudent);
        addToTable(newStudent);
    }

    async function getStudents() {
        try {
            const response = await fetch(url);

            if (response.ok == false) {
                const error = await response.json();
                throw new Error(error.message);
            }

            const result = await response.json();

            return Object.entries(result).map(x => x[1]);

        } catch (error) {
            console.log(error.message)
        }
    }

    async function postStudent(student) {
        try {
            const response = await fetch(url, {
                method: 'post',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(student)
            });

            if (response.ok == false) {
                const error = await response.json();
                throw new Error(error.message);
            }

            const result = await response.json();

        } catch (error) {
            console.log(error.message)
        }
    }
}

attachEvents();