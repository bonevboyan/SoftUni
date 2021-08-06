USE Diablo

SELECT 
	Username,
	RIGHT(Email, LEN(Email) - CHARINDEX('@', Email)) [Email Provider] 
	FROM Users
	ORDER BY [Email Provider], Username