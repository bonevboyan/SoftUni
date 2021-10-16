SELECT 
	cl.LastName,
	CEILING(AVG(s.Length)) AS CigarLength,
	CEILING(AVG(s.RingRange)) AS CigarRingRange
FROM Clients cl
JOIN ClientsCigars cc ON cl.Id = cc.ClientId
JOIN Cigars ci ON ci.Id = cc.CigarId
JOIN Sizes s ON ci.SizeId = s.Id
WHERE cc.CigarId IS NOT NULL
GROUP BY cl.LastName
ORDER BY CigarLength DESC