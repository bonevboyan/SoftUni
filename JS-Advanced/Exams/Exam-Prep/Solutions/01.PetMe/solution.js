function solve() {
    let input = Array.from(document.getElementById("container").children);
    let button = input[input.length - 1];
    button.addEventListener("click", () => {
        
        let [name, age, kind, owner] = input.map(x => x.value);

        if(!name || !kind || !owner || !age || isNaN(Number(age))){
            return;
        }
        
        for (const token of input) {
            token.value = "";
        }

        let newDog = document.createElement("li");

        newDog.innerHTML = `<p><strong>${name}</strong> is a <strong>${age}</strong> year old <strong>${kind}</strong></p>`;
        let oldOwnerSpan = document.createElement("span");
        oldOwnerSpan.textContent = `Owner: ${owner}`;
        newDog.appendChild(oldOwnerSpan);

        let contactButton = document.createElement("button");
        contactButton.textContent = "Contact with owner";
        newDog.appendChild(contactButton);

        let forAdoption = document.getElementById("adoption").children[1];
        let adopted = document.getElementById("adopted").children[1];

        forAdoption.appendChild(newDog);

        contactButton.addEventListener("click", () => {
            newDog.removeChild(contactButton);
            let inputDiv = document.createElement("div");
            inputDiv.innerHTML = `<input placeholder="Enter your names">`;

            let takeButton = document.createElement("button");
            takeButton.textContent = "Yes! I take it!";

            inputDiv.appendChild(takeButton);
            newDog.appendChild(inputDiv);

            takeButton.addEventListener("click", () => {
                let newOwner = inputDiv.children[0].value;

                if(!newOwner){
                    return;
                }

                forAdoption.removeChild(newDog);
                adopted.appendChild(newDog);

                newDog.removeChild(inputDiv);

                newDog.removeChild(oldOwnerSpan);

                let ownerSpan = document.createElement("span");
                ownerSpan.textContent = `New Owner: ${newOwner}`;
                
                let checkedButton = document.createElement("button");
                checkedButton.textContent = "Checked";

                newDog.appendChild(ownerSpan);
                newDog.appendChild(checkedButton);

                checkedButton.addEventListener("click", () => {
                    adopted.removeChild(newDog);
                })
            })
        })
    })
}