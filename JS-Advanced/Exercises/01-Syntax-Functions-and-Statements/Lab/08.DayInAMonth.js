function dayInAMonth(month, year){
    console.log(new Date(year, month, 0).getDate());
}
dayInAMonth(1, 2012)