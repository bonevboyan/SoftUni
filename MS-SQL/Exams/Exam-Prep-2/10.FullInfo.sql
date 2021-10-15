SELECT 
	CASE
		WHEN e.FirstName IS NULL THEN 'None'
		ELSE e.FirstName + ' ' + e.LastName
	END AS [Employee],
	CASE
		WHEN d.[Name] IS NULL THEN 'None'
		ELSE d.[Name]
	END AS [Department],
	CASE
		WHEN c.[Name] IS NULL THEN 'None'
		ELSE c.[Name]
	END AS [Category],
	r.[Description],
	FORMAT(r.OpenDate, 'dd.MM.yyyy') AS [OpenDate],
	CASE
		WHEN s.[Label] IS NULL THEN 'None'
		ELSE s.[Label]
	END AS [Status],
	CASE
		WHEN u.[Name] IS NULL THEN 'None'
		ELSE u.[Name]
	END AS [Users]
FROM Reports r
LEFT JOIN Employees e ON r.EmployeeId = e.Id
LEFT JOIN Users u ON r.UserId = u.Id
LEFT JOIN Categories c ON r.CategoryId = c.Id
LEFT JOIN Departments d ON e.DepartmentId = d.Id
LEFT JOIN Status s ON r.StatusId = s.Id
ORDER BY e.FirstName DESC,
	e.LastName DESC,
	d.Name ASC, 
	c.Name ASC, 
	r.Description ASC, 
	r.OpenDate ASC,
	s.Label ASC,
	u.Name ASC
