function lockedProfile() {
    loadProfiles();

    function onClick(ev) {
        const children = ev.target.parentElement.children;
        if (Array.from(document.getElementsByName(children[2].name)).filter(x => x.value == "unlock")[0].checked) {
            let element = Array.from(document.querySelectorAll('input[type="email"]'))
                .find(x => x.parentElement.id == children[9].id).parentElement;
            element.style.display = element.style.display == "block" ? "none" : "block";
            ev.target.textContent = ev.target.textContent == "Show more" ? "Hide it" : "Show more";
        }
    }

    async function loadProfiles() {
        try {
            let response = await fetch("http://localhost:3030/jsonstore/advanced/profiles");

            if (response.ok == false) {
                throw new Error(`${response.status} ${response.statusText}`)
            }
    
            let profiles = await response.json();
    
            let profileDiv = document.querySelector(".profile");
            let main = document.getElementById("main");
    
            let counter = 1;
    
            for (const profile in profiles) {
                let newProfile = document.createElement("div");
                newProfile.classList.add("profile");
                newProfile.innerHTML = profileDiv.innerHTML;
    
                let profileName = profiles[profile].username;
                let profileEmail = profiles[profile].email;
                let profileAge = profiles[profile].age;
    
                newProfile.querySelectorAll('input[name="user1Locked"]')[0].setAttribute("name", `user${counter}Locked`);
                newProfile.querySelectorAll('input[name="user1Locked"]')[0].setAttribute("name", `user${counter}Locked`);
                newProfile.querySelectorAll('input[name="user1Username"]')[0].setAttribute("name", `user${counter}Username`);
                newProfile.querySelectorAll('input[name="user1Email"]')[0].setAttribute("name", `user${counter}Email`);
                newProfile.querySelectorAll('input[name="user1Age"]')[0].setAttribute("name", `user${counter}Age`);
                newProfile.querySelectorAll('#user1HiddenFields')[0].style.display = 'none';
                newProfile.querySelectorAll('#user1HiddenFields')[0].id = `user${counter}HiddenFields`;
    
                newProfile.querySelector(`input[name="user${counter}Username"]`).value = profileName;
                newProfile.querySelector(`input[name="user${counter}Email"]`).value = profileEmail;
                newProfile.querySelector(`input[name="user${counter}Age"]`).value = profileAge;
                counter++;
    
                main.appendChild(newProfile);
            }
            main.removeChild(profileDiv);
    
            let buttons = document.getElementsByTagName("button");
    
            Array.from(buttons).forEach(x => {
                x.addEventListener("click", onClick);
            });
        } catch (error) {
            console.log(error.message);
        }
    }
}