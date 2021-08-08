USE SoftUni

SELECT TOP(10) 
	FirstName, 
	LastName, 
	DepartmentID 
FROM Employees as e
WHERE Salary > (
	SELECT 
		AVG(Salary)  
	FROM Employees as em
	WHERE e.DepartmentID = em.DepartmentID
	GROUP BY DepartmentID)
ORDER BY DepartmentID