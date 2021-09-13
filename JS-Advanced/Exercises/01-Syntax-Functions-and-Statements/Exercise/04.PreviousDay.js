function previousDay(year, month, day){
    if(day != 1){
        day--;
    }else{
        month--;
        if(month == 0){
            month = 12; 
            year--;
        }
        switch (month) {
            case 1:
            case 3:
            case 5:
            case 7:
            case 8:
            case 10:
            case 12:
                day = 31;
                break;
            case 2:
                day = 28;
                if((year % 4 == 0 && year % 100 != 0) || (year % 400 == 0)){
                    day = 29;
                }
                break;
            default:
                day = 30;
                break;
        }
    }
    console.log(`${year}-${month}-${day}`)
}