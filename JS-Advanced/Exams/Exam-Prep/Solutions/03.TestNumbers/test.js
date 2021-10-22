const { assert } = require('chai');
const { testNumbers } = require('./testNumbers');

describe("testNumbers", function () {
    describe("sumNumbers", function () {
        it("should return undefinded when params are not numbers", function () {
            assert.isUndefined(testNumbers.sumNumbers("abc", 10));
            assert.isUndefined(testNumbers.sumNumbers(10, "abc"));
            assert.isUndefined(testNumbers.sumNumbers(10, "5.5"));
            assert.isUndefined(testNumbers.sumNumbers("5.5", 10));
            assert.isUndefined(testNumbers.sumNumbers("5.5", "10"));
            assert.isUndefined(testNumbers.sumNumbers("abc", "abc"));
        });
        it("should work with positive and negative numbers", function () {
            assert.equal(testNumbers.sumNumbers(-10, 10), 0);
            assert.equal(testNumbers.sumNumbers(10, -10), 0);
            assert.equal(testNumbers.sumNumbers(-10, -10), -20);
            assert.equal(testNumbers.sumNumbers(10.5, -10.3), 0.2);
        });
        it("should return rounded to second decimal point", function () {
            assert.equal(testNumbers.sumNumbers(-10.522, 10), -0.52);
            assert.equal(testNumbers.sumNumbers(1.1111, 0), 1.11);
        });
    });
    describe("numberChecker", function () {
        it("should throw error when input is not a number", function () {
            try{
                testNumbers.numberChecker("abc");
            } catch(e){
                assert.equal(e.message, 'The input is not a number!');
            }
        });
        it("should work when input is a number as a string", function () {
            assert.equal(testNumbers.numberChecker("5.5"), "The number is odd!");
            assert.equal(testNumbers.numberChecker("4"), "The number is even!");
        });
    });
    describe("averageSumArray", function () {
        it("should sum numbers", function () {
            assert.equal(testNumbers.averageSumArray([7, 8, 9]), 8);
        });
    });
});
