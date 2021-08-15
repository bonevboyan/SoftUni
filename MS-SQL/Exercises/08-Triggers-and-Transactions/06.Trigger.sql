CREATE PROC usp_BuyItem 
(@userId INT, @itemId INT, @gameId INT)
AS
	BEGIN TRANSACTION
		DECLARE @user INT = (SELECT Id FROM Users WHERE Id = @userId)
		DECLARE @item INT = (SELECT Id FROM Items WHERE Id = @itemId)

		IF(@user IS NULL OR @item IS NULL)
		BEGIN
			ROLLBACK
			RAISERROR('Invalid user or item id!', 16, 1)
			RETURN
		END

		DECLARE @userCash DECIMAL(15, 2) = (SELECT Cash FROM UsersGames WHERE UserId = @userId AND GameId = @gameId)
		DECLARE @itemPrice DECIMAL(15,2) = (SELECT Price FROM Items WHERE Id = @itemId)

		IF(@userCash - @itemPrice < 0)
		BEGIN
			ROLLBACK
			RAISERROR('Insufficient funds!', 16, 2)
			RETURN
		END

		UPDATE UsersGames SET Cash -= @itemPrice
		WHERE UserId = @userId AND GameId = @gameId

		DECLARE @userGameId INT = (SELECT Id FROM UsersGames WHERE UserId = @userId AND GameId = @gameId)

		INSERT INTO UserGameItems VALUES (@userId, @userGameId)
		COMMIT
GO

IF OBJECT_ID(N'tempdb..#UsersIds') IS NOT NULL
BEGIN
DROP TABLE #UsersIds
END
GO

CREATE TABLE #UsersIds (Id INT IDENTITY PRIMARY KEY, UserId INT)
INSERT INTO #UsersIds
SELECT Id FROM Users 
WHERE Username IN ('baleremuda', 'loosenoise', 'inguinalself', 'buildingdeltoid', 'monoxidecos')
DECLARE @gameId INT = (SELECT Id FROM Games WHERE Name = 'Bali')

DECLARE @I INT = 1
WHILE(@I <= (SELECT COUNT(*) FROM #UsersIds))
BEGIN 
	DECLARE @userId2 INT 
	SET @userId2 = (SELECT UserId FROM #UsersIds WHERE Id = @I)

	UPDATE UsersGames SET Cash = Cash + 50000
	WHERE GameId = @gameId AND UserId = @userId2

	SET @I += 1
END

DECLARE @itemId INT = 251;

WHILE (@itemId <= 299)
BEGIN

	DECLARE @counter INT 
	SET @counter = 1
	WHILE(@counter <= (SELECT COUNT(*) FROM #UsersIds))
	BEGIN 
		DECLARE @userId INT 
		SET @userId = (SELECT UserId FROM #UsersIds WHERE Id = @counter)

		EXEC usp_BuyItem @userId, @itemId, @gameId

		SET @counter += 1
	END
	SET @gameId += 1
END

SET @itemId = 501;

WHILE (@itemId <= 539)
BEGIN
	DECLARE @counter1 INT 
	SET @counter1 = 1
	WHILE(@counter1 <= (SELECT COUNT(*) FROM #UsersIds))
	BEGIN 
		DECLARE @userId1 INT = (SELECT UserId FROM #UsersIds WHERE Id = @counter1)

		EXEC usp_BuyItem @userId1, @itemId, @gameId

		SET @counter1 += 1
	END
	SET @gameId += 1
END

SELECT 
	u.Username, g.Name, ug.Cash, i.Name
FROM Users As u
JOIN UsersGames As ug ON ug.UserId = u.Id
JOIN Games AS g ON g.Id = ug.GameId
JOIN UserGameItems AS ugi ON ugi.UserGameId = ug.Id
JOIN Items AS i ON i.Id = ugi.ItemId
WHERE g.Name = 'Bali'
ORDER BY u.Username, i.Name