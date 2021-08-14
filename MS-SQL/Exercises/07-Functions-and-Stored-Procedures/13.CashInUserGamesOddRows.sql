CREATE FUNCTION ufn_CashInUsersGames
(@gameName NVARCHAR(MAX))
RETURNS TABLE
AS
	RETURN SELECT SUM(Cash) AS SumCash
	FROM (
		SELECT
			ug.Cash,
			ROW_NUMBER() OVER (ORDER BY ug.Cash DESC) AS Row
		FROM UsersGames AS ug
		INNER JOIN Games AS g ON ug.GameId = g.Id
		WHERE g.Name = @gameName) AS CashMoney
    WHERE Row % 2 = 1
	