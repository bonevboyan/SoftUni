CREATE PROCEDURE usp_GetEmployeesFromTown 
	@Name VARCHAR(30)
AS
	SELECT
		FirstName AS [First Name],
		LastName AS [Last Name]
	FROM Employees e
	JOIN Addresses a ON e.AddressID = a.AddressID
	JOIN Towns t ON a.TownID = t.TownID
	WHERE t.Name = @Name
GO