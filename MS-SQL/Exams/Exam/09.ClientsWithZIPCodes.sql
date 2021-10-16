SELECT 
	CONCAT(cl.FirstName, ' ', cl.LastName) AS FullName,
	a.Country,
	a.ZIP,
	CONCAT('$', MAX(ci.PriceForSingleCigar)) AS CigarPrice
FROM Clients cl
JOIN Addresses a ON cl.AddressId = a.Id
JOIN ClientsCigars cc ON cl.Id = cc.ClientId
JOIN Cigars ci ON ci.Id = cc.CigarId
WHERE ISNUMERIC(a.ZIP) = 1
GROUP BY cl.FirstName, cl.LastName, a.Country, a.ZIP
ORDER BY FullName ASC