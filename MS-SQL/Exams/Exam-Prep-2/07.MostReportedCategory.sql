SELECT TOP(5)
	c.Name, 
	COUNT(c.Id) AS 'Reports Number'
FROM Categories c
JOIN Reports r ON c.Id = r.CategoryId
GROUP BY c.Name
ORDER BY [Reports Number] DESC ,c.Name ASC