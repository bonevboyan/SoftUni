function solve() {
    let input = Array.from(document.getElementById("container").children);
    let button = input[input.length - 1];
    button.addEventListener("click", () => {
        
        let [name, age, kind, owner] = input.map(x => x.value);
        for (const token of input) {
            token.value = "";
        }

        let newDog = document.createElement("li");

        newDog.innerHTML = `<p><strong>${name}</strong> is a <strong>${age}</strong> year old <strong>${kind}</strong></p>
                            <span>Owner: ${owner}</span>`;

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
                forAdoption.removeChild(newDog);
                adopted.appendChild(newDog);

                newDog.removeChild(inputDiv);
                //newDog.removeChild(takeButton);

                let ownerSpan = document.createElement("span");
                ownerSpan.textContent = `New Owner: ${inputDiv.children[0].value}`;
                
                let checkedButton = document.createElement("button");
                checkedButton.textContent = "Checked";

                newDog.appendChild(ownerSpan);
                newDog.appendChild(checkedButton);

                console.log(newDog);
            })
        })
    })
}