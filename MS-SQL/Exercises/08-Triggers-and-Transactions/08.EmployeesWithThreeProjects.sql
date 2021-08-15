CREATE PROCEDURE usp_AssignProject
(@employeeId INT, @projectID INT)
AS
    BEGIN TRANSACTION
    IF (SELECT COUNT(ProjectID) FROM EmployeesProjects WHERE EmployeeID = @employeeId) > 3
	BEGIN
		RAISERROR ('The employee has too many projects!', 16, 1)
		ROLLBACK
		RETURN
	END
    INSERT INTO EmployeesProjects VALUES (@employeeId, @projectID)
    COMMIT