USE SoftUni

SELECT 
	DepartmentID,
	SUM(Salary) As TotalSalary
FROM Employees
GROUP BY DepartmentID
ORDER BY DepartmentID