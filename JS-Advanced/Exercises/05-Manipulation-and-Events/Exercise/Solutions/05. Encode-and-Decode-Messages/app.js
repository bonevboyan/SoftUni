function encodeAndDecodeMessages() {
    let buttons = Array.from(document.getElementsByTagName("button"));
    buttons[0].addEventListener("click", onEncode);
    buttons[1].addEventListener("click", onDecode);

    function onEncode(ev) {
        let textAreas = document.getElementsByTagName("textarea");
        let encodedMessage = textAreas[0].value.split("").map(x => String.fromCharCode(x.charCodeAt(0) + 1)).join("");

        textAreas[0].value = "";

        textAreas[1].value = encodedMessage;
    }

    function onDecode(ev) {
        let textAreas = document.getElementsByTagName("textarea");
        let encodedMessage = textAreas[1].value.split("").map(x => String.fromCharCode(x.charCodeAt(0) - 1)).join("");

        textAreas[1].value = "";

        textAreas[1].value = encodedMessage;
    }
}