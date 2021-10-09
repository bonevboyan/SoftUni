function filter(data, criteria){
    data = JSON.parse(data);
    if(criteria != 'all'){
        let [criteriaName, criteriaValue] = criteria.split("-");
        data = data.filter(x => x[criteriaName] == criteriaValue);
    }
    console.log(data.map((element, index) => `${index}. ${element.first_name} ${element.last_name} - ${element.email}`).join("\n"));
}