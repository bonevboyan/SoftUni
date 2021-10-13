const { assert } = require('chai');
const { isSymmetric } = require('./checkForSymmetry');

describe("isSymmetric", function () {
    it("should return false when value is non-array", function () { 
        assert.equal(isSymmetric(6), false);
    });
    it("should return true array is symmetric", function () { 
        assert.equal(isSymmetric([1, 2, 3, 2, 1]), true);
    });
    it("should return true array is empty", function () { 
        assert.equal(isSymmetric([]), true);
    });
    it("should return true when string array is symmetric", function () { 
        assert.equal(isSymmetric(['1a', '2a', '1a']), true);
    });
    it("should return true when array types don't match", function () { 
        assert.equal(isSymmetric(['1', 'a', 1]), false);
    });
});
