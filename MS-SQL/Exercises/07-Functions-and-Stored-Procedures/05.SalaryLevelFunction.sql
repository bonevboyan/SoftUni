CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS VARCHAR(30)
AS
BEGIN
    IF (@salary < 30000)
		RETURN 'Low'
	IF (@salary < 50000)
		RETURN 'Average'
	RETURN 'High'
END

