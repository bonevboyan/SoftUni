class Stringer {
    constructor(string, initLength) {
        this.innerString = string;
        this.innerLength = initLength;
    }

    increase(length) {
        this.innerLength += length;
    }

    decrease(length) {
        const result = this.innerLength - length;
        this.innerLength = result < 0 ? 0 : result;
    }

    toString() {
        if (this.innerLength === 0) {
            return '...';
        }

        if (this.innerString.length > this.innerLength) {
            return `${this.innerString.slice(0, this.innerLength)}...`;
        }

        return this.innerString;
    }
}