USE SoftUni

SELECT 
	e.EmployeeID,
	e.FirstName,
	e.LastName,
	d.Name
FROM Employees e
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'
ORDER BY EmployeeID ASC