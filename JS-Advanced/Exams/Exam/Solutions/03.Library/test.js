const { assert } = require('chai');
const { expect } = require('chai');
const { library } = require('./library');

describe("library", function () {
    describe("calcPriceOfBook", function () {
        it("should throw error when input isn't the correct type", function () {
            expect(() => library.calcPriceOfBook(1,'abc')).to.throw();
            expect(() => library.calcPriceOfBook(1, 1)).to.throw();
            expect(() => library.calcPriceOfBook('abc', 'abc')).to.throw();
            expect(() => library.calcPriceOfBook('abc', 1999.5)).to.throw();
        });
        it("should return standard value when year is after 1980", function () {
            assert.equal(library.calcPriceOfBook('book', 2000), `Price of book is 20.00`);
            assert.equal(library.calcPriceOfBook('book', 1981), `Price of book is 20.00`);
            assert.equal(library.calcPriceOfBook('book', 3000), `Price of book is 20.00`);
        });
        it("should return half of the value when year is before 1980", function () {
            assert.equal(library.calcPriceOfBook('book', 1980), `Price of book is 10.00`);
            assert.equal(library.calcPriceOfBook('book', 1000), `Price of book is 10.00`);
            assert.equal(library.calcPriceOfBook('book', 1500), `Price of book is 10.00`);
            assert.equal(library.calcPriceOfBook('book', -2000), `Price of book is 10.00`);
        });
    });
    describe("findBook", function () {
        it("should throw when input arr is an empty array", function () {
            expect(() => library.findBook([],'abc')).to.throw();
        });
        it("should return correct output when array contains desired book", function () {
            assert.equal(library.findBook(['abc', 'bac', 'aaa'],'abc'), "We found the book you want.");
        });
        it("should return correct output when array doesn't contain desired book", function () {
            assert.equal(library.findBook(['aaa', 'bac', 'aaa'],'abc'), "The book you are looking for is not here!");
        });
    });
    describe("arrangeTheBooks", function () {
        it("should throw when num isn't an integer or positive", function () {
            expect(() => library.arrangeTheBooks(5.5)).to.throw();
            expect(() => library.arrangeTheBooks(-5)).to.throw();
            expect(() => library.arrangeTheBooks(-5.5)).to.throw();
        });
        it("should return correct output when there is enough space", function () {
            assert.equal(library.arrangeTheBooks(30), "Great job, the books are arranged.");
            assert.equal(library.arrangeTheBooks(40), "Great job, the books are arranged.");
            assert.equal(library.arrangeTheBooks(5), "Great job, the books are arranged.");
        });
        it("should return correct output when there isn't enough space", function () {
            assert.equal(library.arrangeTheBooks(41), "Insufficient space, more shelves need to be purchased.");
            assert.equal(library.arrangeTheBooks(100), "Insufficient space, more shelves need to be purchased.");
            assert.equal(library.arrangeTheBooks(200), "Insufficient space, more shelves need to be purchased.");
        });
    });
});
