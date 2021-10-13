const { assert } = require('chai');
const { sum } = require('./subNumbers');

describe("sum", function () {
    it("should add numbers correctly", function () { 
        assert.equal(sum([5, 2]), 7);
    });
});
