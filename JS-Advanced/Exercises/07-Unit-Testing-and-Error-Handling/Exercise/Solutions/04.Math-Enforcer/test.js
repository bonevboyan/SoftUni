const { assert, expect } = require('chai');
const { mathEnforcer } = require('./mathEnforcer');

describe("mathEnforcer", function () {
    describe('addFive', function () {
        it("should return correct result with a non-number parameter", function () { 
            assert.isUndefined(mathEnforcer.addFive('abc'));
        });
        it("should return correct result with a positive number parameter", function () { 
            assert.equal(mathEnforcer.addFive(5), 10);
        });
        it("should return correct result with a negative number parameter", function () { 
            assert.equal(mathEnforcer.addFive(-5), 0);
        });
        it("should return correct result with a floating point number parameter", function () { 
            expect(mathEnforcer.addFive(-5.5)).to.equal(-0.5);
        });
    });
    describe('subtractTen', function () {
        it("should return correct result with a non-number parameter", function () { 
            assert.isUndefined(mathEnforcer.subtractTen('abc'));
        });
        it("should return correct result with a positive number parameter", function () { 
            assert.equal(mathEnforcer.subtractTen(5), -5);
        });
        it("should return correct result with a negative number parameter", function () { 
            assert.equal(mathEnforcer.subtractTen(-5), -15);
        });
        it("should return correct result with a floating point number parameter", function () { 
            expect(mathEnforcer.subtractTen(-5.5)).to.equal(-15.5);
        });
    });
    describe('sum', function () {
        it("should return correct result with a non-number parameter", function () { 
            assert.isUndefined(mathEnforcer.sum('abc', 123));
        });
        it("should return correct result with a non-number parameter", function () { 
            assert.isUndefined(mathEnforcer.sum(123, 'abc'));
        });
        it("should return correct result with positive number parameters", function () { 
            assert.equal(mathEnforcer.sum(5, 5), 10);
        });
        it("should return correct result with negative number parameters", function () { 
            assert.equal(mathEnforcer.sum(-5, 5), 0);
        });
        it("should return correct result with floating point number parameters", function () { 
            expect(mathEnforcer.sum(-5.5, 5)).to.equal(-0.5);
        });
        it("should return correct result with floating point number parameters", function () { 
            expect(mathEnforcer.sum(-5.5, 5.5)).to.equal(0);
        });
    });
});