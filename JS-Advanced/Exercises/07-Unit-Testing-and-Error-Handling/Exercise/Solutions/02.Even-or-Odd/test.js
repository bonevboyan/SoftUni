const { assert } = require('chai');
const { isOddOrEven } = require('./isOddOrEven');

describe("isOddOrEven", function () {
    it("should return undefinded when value is not a string", function () { 
        assert.isUndefined(isOddOrEven([]));
    });
    it("should return even when string length is even", function () { 
        assert.equal(isOddOrEven("even"), "even");
    });
    it("should return odd when string length is even", function () { 
        assert.equal(isOddOrEven("odd"), "odd");
    });
});
