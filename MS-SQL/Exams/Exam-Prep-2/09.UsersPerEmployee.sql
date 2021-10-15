SELECT
	e.FirstName + ' ' + e.LastName AS FullName,
	COUNT(u.Id) AS UsersCount
FROM Employees e
FULL JOIN Reports r ON r.EmployeeId = e.Id
FULL JOIN Users u ON r.UserId = u.Id
WHERE e.LastName IS NOT NULL AND e.FirstName IS NOT NULL
GROUP BY e.FirstName, e.LastName
ORDER BY UsersCount DESC, FullName ASC