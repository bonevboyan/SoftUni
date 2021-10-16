CREATE PROCEDURE usp_SearchByTaste(@taste VARCHAR(20))
AS
	SELECT 
		ci.CigarName,
		CONCAT('$', ci.PriceForSingleCigar) AS Price,
		t.TasteType,
		b.BrandName,
		CONCAT(s.Length, ' cm') AS CigarLength, 
		CONCAT(s.RingRange, ' cm') AS CigarRingRange
	FROM Cigars ci
	JOIN Sizes s ON ci.SizeId = s.Id
	JOIN Tastes t ON ci.TastId = t.Id
	JOIN Brands b ON ci.BrandId = b.Id
	WHERE t.TasteType = @taste
	ORDER BY CigarLength ASC, CigarRingRange DESC
GO

EXEC usp_SearchByTaste 'Woody'