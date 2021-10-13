const { assert } = require('chai');
const { createCalculator } = require('./addSubtract');

describe("createCalculator", function () {
    it("should add number", function () {
        let calc = createCalculator();
        calc.add(10);
        assert.equal(10, calc.get())
    });
    it("should subtract number", function () {
        let calc = createCalculator();
        calc.subtract(10);
        assert.equal(-10, calc.get())
    });
    it("should and and subtract number", function () {
        let calc = createCalculator();
        calc.add(20);
        calc.subtract(10);
        assert.equal(10, calc.get())
    });
    it("should add rational numbers", function () {
        let calc = createCalculator();
        calc.add(10.5);
        assert.equal(10.5, calc.get())
    });
    it("should add string values", function () {
        let calc = createCalculator();
        calc.add('12');
        assert.equal(12, calc.get())
    });
    it("should add and subtract string values", function () {
        let calc = createCalculator();
        calc.add('12');
        calc.subtract('12');
        assert.equal(0, calc.get())
    });
    it('should return NaN if value is string', () => {
        let calc = createCalculator();
        calc.add('str');
        assert.equal(true, Number.isNaN(calc.get()));
    });
});
