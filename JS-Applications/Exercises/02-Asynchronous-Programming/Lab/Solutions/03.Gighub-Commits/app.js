async function loadCommits() {
    let list = document.getElementById('commits');
    let username = document.getElementById('username').value;
    let repo = document.getElementById('repo').value;
    list.innerHTML = '';

    try {
        let result = await fetch(`https://api.github.com/repos/${username}/${repo}/commits`);

        if (result.ok == false) {
            throw new Error(`${result.status} (${result.statusText})`)
        }

        let commits = await result.json();



        console.log(commits)
        for (const commit of commits) {
            let liElement = document.createElement('li');

            liElement.innerHTML = `${commit.commit.author.name}: ${commit.commit.message}`

            list.appendChild(liElement);
        }
    } catch (error) {
        let liElement = document.createElement('li');

        liElement.innerHTML = `Error: ${error.message}`

        list.appendChild(liElement);
    }
}