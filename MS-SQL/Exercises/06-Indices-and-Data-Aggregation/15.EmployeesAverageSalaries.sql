USE SoftUni

SELECT * INTO [Table] 
FROM Employees
WHERE Salary > 30000 

DELETE FROM [Table] 
WHERE ManagerID = 42

UPDATE [Table]  SET Salary += 5000
WHERE DepartmentID = 1

SELECT 
	DepartmentID, 
	AVG(Salary) AS AverageSalary
FROM [Table] 
GROUP BY DepartmentID