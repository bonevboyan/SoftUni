SELECT
	cl.Id,
	CONCAT(cl.FirstName, ' ', cl.LastName) AS ClientName,
	cl.Email
FROM Clients cl
LEFT JOIN ClientsCigars cc ON cl.Id = cc.ClientId
LEFT JOIN Cigars ci ON ci.Id = cc.CigarId
WHERE cc.CigarId IS NULL
ORDER BY ClientName