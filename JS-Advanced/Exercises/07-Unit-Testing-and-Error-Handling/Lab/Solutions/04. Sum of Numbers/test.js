const { assert } = require('chai');
const subNumbers = require('./subNumbers');

describe("title", function () {
    it("title", function () { 
        assert.equal(subNumbers([5, 2]), 7);
    });
});
