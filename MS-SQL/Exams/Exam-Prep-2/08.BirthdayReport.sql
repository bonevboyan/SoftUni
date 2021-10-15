SELECT 
	u.Username,
	c.Name
FROM Categories AS c 
INNER JOIN Reports AS r ON r.CategoryId = c.Id
INNER JOIN Users AS u ON r.UserId = u.id
WHERE DAY(r.OpenDate) = DAY(u.Birthdate) AND MONTH(r.OpenDate) = MONTH(u.Birthdate)
ORDER BY u.Username, c.Name