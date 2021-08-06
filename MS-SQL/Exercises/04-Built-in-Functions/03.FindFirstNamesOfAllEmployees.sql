USE SoftUni

SELECT FirstName FROM Employees
	WHERE YEAR(HireDate) BETWEEN 1995 AND 2005 AND 
		DepartmentID = 3 OR DepartmentID = 10