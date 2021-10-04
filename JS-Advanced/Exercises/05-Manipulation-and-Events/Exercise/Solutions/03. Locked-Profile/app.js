function lockedProfile() {
    Array.from(document.getElementsByTagName("button")).forEach(x => {
        x.addEventListener("click", onClick);
    });

    function onClick(ev){
        const children = ev.target.parentElement.children;
        if(Array.from(document.getElementsByName(children[2].name)).filter(x => x.value == "unlock")[0].checked){
            let element = Array.from(document.querySelectorAll('input[type="email"]'))
                .find(x => x.parentElement.id == children[9].id).parentElement;
            element.style.display = element.style.display == "block" ? "none" : "block";
            ev.target.textContent =  ev.target.textContent == "Show more" ? "Hide it" : "Show more";
        }
    }
}