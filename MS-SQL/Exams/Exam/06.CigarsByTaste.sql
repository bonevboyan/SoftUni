SELECT 
	c.Id,
	c.CigarName,
	c.PriceForSingleCigar,
	t.TasteType,
	t.TasteStrength
FROM Cigars c
JOIN Tastes t ON t.Id = c.TastId
WHERE t.TasteType IN ('Earthy', 'Woody')
ORDER BY PriceForSingleCigar DESC