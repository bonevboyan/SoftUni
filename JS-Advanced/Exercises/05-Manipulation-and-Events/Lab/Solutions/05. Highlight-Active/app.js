function focused() {
    let elements = Array.from(document.getElementsByTagName("input"));

    for (let el of elements) {
        el.addEventListener('focus', onFocus);
        el.addEventListener('blur', onBlur);
    }

    function onFocus(ev){
        ev.target.parentNode.className = 'focused';
    }

    function onBlur(ev){
        ev.target.parentNode.className = '';
    }
}