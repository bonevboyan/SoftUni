function createPatientCard(name, age, weightInKg, heightInCm) {
    let patient = {
        name: name,
        personalInfo: {
            age: age,
            weight: weightInKg,
            height: heightInCm
        },
        // BMI : 0,
        calculateBMI: function () {
            this.BMI = Math.round(this.personalInfo.weight / Math.pow(this.personalInfo.height / 100, 2))
        },
        getStatus: function () {
            if (this.BMI < 18.5) {
                this.status = 'underweight';
            } else if (this.BMI >= 18.5 && this.BMI < 25) {
                this.status = 'normal';
            } else if (this.BMI >= 25 && this.BMI < 30) {
                this.status = 'overweight';
            } else {
                this.status = 'obese';
            }
        },
        getRecommendation : function () {
            if(this.BMI>=30){
                this.recommendation = 'admission required';
            }
        }

    };
    patient.calculateBMI();
    patient.getStatus();
    patient.getRecommendation();
    return patient;
}