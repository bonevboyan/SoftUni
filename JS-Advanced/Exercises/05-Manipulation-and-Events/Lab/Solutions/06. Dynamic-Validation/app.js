function validate() {
    document.getElementById("email").addEventListener("change", onChange);

    function onChange(ev){
        let regex = /^[a-z]+@[a-z]+\.[a-z]+$/; 

        let email = ev.target.value;

        if(regex.test(email)){
            ev.target.classList.remove('error');
        }else{
            ev.target.classList.add('error');
        }
    }
}