const { assert } = require('chai');
const { rgbToHexColor } = require('./rgb-to-hex');

describe("rgbToHexColor", function () {
    it("should return correct hex value", function () { 
        assert.equal(rgbToHexColor(235, 64, 52), '#EB4034')
    });
    it("should return correct hex value", function () { 
        assert.equal(rgbToHexColor(0, 0, 0), '#000000')
    });
    it("should return correct hex value", function () { 
        assert.equal(rgbToHexColor(255, 255, 255), '#FFFFFF')
    });
    it("should return undefined when rgb values are over range", function () { 
        assert.equal(rgbToHexColor(2365, 64, 52), undefined)
    });
    it("should return undefined when rgb values are over range", function () { 
        assert.equal(rgbToHexColor(5, 654, 552), undefined)
    });
    it("should return undefined when rgb values are over range", function () { 
        assert.equal(rgbToHexColor(5, 5, 552), undefined)
    });
    it("should return undefined when rgb values are under range", function () { 
        assert.equal(rgbToHexColor(-2365, 64, 52), undefined)
    });
    it("should return undefined when rgb values are under range", function () { 
        assert.equal(rgbToHexColor(5, -654, 552), undefined)
    });
    it("should return undefined when rgb values are under range", function () { 
        assert.equal(rgbToHexColor(5, 5, -552), undefined)
    });
    it("should return undefined when passed values aren't integers", function () { 
        assert.equal(rgbToHexColor('5', {}, []), undefined)
    });
});
