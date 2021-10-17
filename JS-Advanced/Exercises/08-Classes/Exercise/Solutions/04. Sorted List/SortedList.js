class List {
    constructor () {
        this.list = [];
        this.size = this.list.length;
    }

    updateList () { 
        this.size = this.list.length;
        this.list.sort((a, b) => a - b);
    }

    add (e) {
        this.list.push(e)
        this.updateList();
    }
    remove (i) {
        if (this.list[i] !== undefined) {
            this.list.splice(i, 1);
            this.updateList();
        }
    }
    get (i) {
        if (this.list[i] !== undefined) {
            this.updateList();
            return this.list[i]
        }
    }
}