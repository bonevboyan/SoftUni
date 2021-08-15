CREATE TRIGGER tr_DeleteEmployees
ON Employees AFTER DELETE
AS
    INSERT INTO Deleted_Employees
	SELECT FirstName, LastName, MiddleName, JobTitle, DepartmentID, Salary
	FROM deleted
GO