USE SoftUni

SELECT 
	MIN(s.AverageSalary) AS MinAverageSalary
FROM
(
    SELECT 
		AVG(Salary) AS AverageSalary
    FROM Employees
    GROUP BY DepartmentID
) AS s; 