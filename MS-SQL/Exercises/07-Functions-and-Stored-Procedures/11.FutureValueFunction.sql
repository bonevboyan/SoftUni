CREATE FUNCTION ufn_CalculateFutureValue
(@Sum MONEY, @YearlyInterestRate FLOAT, @NumberOfYears INT)
RETURNS MONEY
AS
BEGIN
    RETURN @Sum * POWER(1 + @YearlyInterestRate, @NumberOfYears)
END
