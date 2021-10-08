function attachEventsListeners() {
    document.getElementById("convert").addEventListener("click", onClick);

    function onClick(ev){
        let inputValue = Number(document.getElementById("inputDistance").value);
        let inputUnit = document.getElementById("inputUnits").value;

        const unitConverter = {
            km: 1000,
            m: 1,
            cm: 0.01,
            mm: 0.001,
            mi: 1609.34,
            yrd: 0.9144,
            ft: 0.3048,
            in: 0.0254
        }

        let valueInMeters = inputValue * unitConverter[inputUnit];

        let outputUnit = document.getElementById("outputUnits").value;

        document.getElementById("outputDistance").value = valueInMeters / unitConverter[outputUnit];
    }
}