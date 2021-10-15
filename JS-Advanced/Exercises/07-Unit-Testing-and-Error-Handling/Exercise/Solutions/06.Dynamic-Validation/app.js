function validate() {
    const input = document.getElementById("email");
    input.addEventListener("change", e => applyStyle(e.target, e.target.value))

    function isValidEmail(str) {
        if (/^[a-z]+@[a-z]+\.[a-z]+/g.test(str)) {
            return true;
        }
        return false;
    }

    function applyStyle(e, email) {
        e.className = isValidEmail(email) ? "" : "error";
    }
}