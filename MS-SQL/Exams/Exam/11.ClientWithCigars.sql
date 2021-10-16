CREATE FUNCTION udf_ClientWithCigars(@name NVARCHAR(30)) 
RETURNS INT
AS
BEGIN
	RETURN(
	SELECT TOP(1)
		COUNT(ci.ID) 
	FROM Clients cl
	JOIN ClientsCigars cc ON cl.Id = cc.ClientId
	JOIN Cigars ci ON ci.Id = cc.CigarId
	WHERE FirstName = @name)
END

SELECT dbo.udf_ClientWithCigars('Betty')