async function loadRepos() {
	let list = document.getElementById('repos');
	let username = document.getElementById('username').value;

	try {
		let result = await fetch(`https://api.github.com/users/${username}/repos`);

		if(result.ok == false){
			throw new Error(`${result.status} ${result.statusText}`)
		}

		let repos = await result.json();
	
		list.innerHTML = '';
	
		for (const repo of repos) {
			let liElement = document.createElement('li');
	
			liElement.innerHTML = `<a href = "${repo.html_url}">${repo.full_name}</a>`
	
			list.appendChild(liElement);
		}
	} catch(error) {
		console.log('Error', error);
	}
}