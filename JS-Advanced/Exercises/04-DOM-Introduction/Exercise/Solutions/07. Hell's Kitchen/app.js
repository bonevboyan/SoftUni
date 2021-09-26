function solve() {
	document.querySelector('#btnSend').addEventListener('click', onClick);

	function onClick () {
		let input = document.getElementById("inputs").children[1].value;
		
		input = input.replaceAll('\n',' ').trim().slice(1, input.length - 1).split('\",\"').map(x => {
			return x.replaceAll('\"', '').split(' - ').map(y =>{
				return y.split(', ').map(z => {
					return z.split(' ');
				});
			});
		});

		let bestRestaurant = input.sort((a, b) => {
			let arr = a[1].map(x => Number(x[1]));
			let sum = arr.reduce((acc, curr) => acc + curr, 0);
			let avg = sum / arr.length;
			
			let brr = b[1].map(x => Number(x[1]));
			let bum = brr.reduce((acc, curr) => acc + curr, 0);
			let bvg = bum / brr.length;
			return bvg - avg;
		})[0];

		let arr = bestRestaurant[1].map(x => Number(x[1]));
		let sum = arr.reduce((acc, curr) => acc + curr, 0);
		let avgSalary = sum / arr.length;

		let bestSalary = arr.sort((a, b) => b - a)[0];

		document.getElementById("bestRestaurant").children[2].textContent = `Name: ${bestRestaurant[0]} Average Salary: ${avgSalary.toFixed(2)} Best Salary: ${bestSalary.toFixed(2)}`;

		let workers = bestRestaurant[1].sort((a, b) => Number(b[1]) - Number(a[1])).reduce((acc, curr) =>{
			let currName = curr[0];
			let currSalary = Number(curr[1]);
			acc += `Name: ${currName} With Salary: ${currSalary} `;
			return acc;
		}, '');

		document.getElementById("workers").children[2].textContent = workers.trim();

      
   }
}
