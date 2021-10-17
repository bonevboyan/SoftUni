class Company {
    constructor() {
        this.departments = [];
    }

    getDepartment(name) {
        const department = this.departments.find(x => x.name === name)

        if (!department) {
            const temp = { name, employees: [], salaries: [], positions: [] };
            this.departments.push(temp);
            return temp;
        } else {
            return department;
        }
    }

    getSalariesSum(depart) {
        return depart.salaries.reduce((a, v) => a + v, 0);
    }

    bestSalaryDepart() {
        return this.departments.sort((a, b) => this.getSalariesSum(b) / b.salaries.length - this.getSalariesSum(a) / a.salaries.length)[0];
    }

    addEmployee(...args) {
        if (args.some(x => x === undefined || x === null || x === '') || args[1] < 0) {
            throw new Error('Invalid input!');
        }

        const department = this.getDepartment(args[3]);

        department.employees.push(args[0]);
        department.salaries.push(args[1]);
        department.positions.push(args[2]);

        return `New employee is hired. Name: ${args[0]}. Position: ${args[2]}`;
    }

    bestDepartment() {
        const best = this.bestSalaryDepart();

        const printData = best.employees
            .reduce((acc, curr, i) => {
                acc[i] = []
                acc[i].push(curr, best.salaries[i], best.positions[i]);
                return acc;
            }, [])
            .sort((a, b) => b[1] - a[1] === 0 ? a[0].localeCompare(b[0]) : b[1] - a[1])
            .map(x => x.join(' '))
            .join('\n');

        return `Best Department is: ${best.name}\nAverage salary: ${(this.getSalariesSum(best) / best.salaries.length).toFixed(2)}\n${printData}`;
    }
}