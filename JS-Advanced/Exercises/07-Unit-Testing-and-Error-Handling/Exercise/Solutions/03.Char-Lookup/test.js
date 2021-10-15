const { assert } = require('chai');
const { lookupChar } = require('./charLookUp');

describe("lookupChar", function () {
    it("should return undefinded when value is not a string", function () { 
        assert.isUndefined(lookupChar([], 5));
    });
    it("should return message when index is under the range", function () { 
        assert.equal(lookupChar("hello", 6), "Incorrect index");
    });
    it("should return message when index is over the range", function () { 
        assert.equal(lookupChar("hello", -1), "Incorrect index");
    });
    it("should return char when index is in range", function () { 
        assert.equal(lookupChar("hello", 0), "h");
    });
    it("should return char when index is in range", function () { 
        assert.equal(lookupChar("hello", 1), "e");
    });
    it("should return undefined when index isnt an integer", function () { 
        assert.isUndefined(lookupChar('567', 'abv'));
    });
    it("should return undefined when index isnt an integer", function () { 
        assert.isUndefined(lookupChar('567', 1.5));
    });
});
