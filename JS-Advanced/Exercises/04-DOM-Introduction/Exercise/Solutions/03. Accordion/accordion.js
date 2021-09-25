function toggle() {
    let title = document.getElementsByClassName("button")[0];
    if (title.textContent == "More") {
        document.getElementById("extra").style.display = "block";
        title.textContent = "Less";
    } else {
        document.getElementById("extra").style.display = 'none';
        title.textContent = "More";
    }
}