function createSortedList(){
    let list = {
        innerArray: [],
        add(element){
            this.innerArray.push(element);
            this.innerArray.sort((a, b) => a - b);
        },
        remove(index){
            if (index > -1) {
                this.innerArray.splice(index, 1);
            }
        },
        get(index){
            if (index > -1) {
                return this.innerArray[index];
            }
        },
        get size(){
            return this.innerArray.length;
        }
    };
    return list;
}