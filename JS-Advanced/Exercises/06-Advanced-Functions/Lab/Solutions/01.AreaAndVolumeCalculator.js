function solve(area, vol, input) {
	let objects = JSON.parse(input);
	function calc(obj) {
		let areaObj = Math.abs(area.call(obj));
		let volumeObj = Math.abs(vol.call(obj));
		return { area: areaObj, volume: volumeObj }
	}
	return objects.map(calc);
}

function area() {
	return Math.abs(this.x * this.y);
}

function vol() {
	return Math.abs(this.x * this.y * this.z);
}