USE Geography

SELECT 
	PeakName, RiverName,
	CONCAT(LOWER(SUBSTRING(PeakName, 1, LEN(PeakName) - 1)), LOWER(RiverName)) AS Mix
	FROM Peaks
	JOIN Rivers ON RIGHT(PeakName, 1) = LEFT(RiverName, 1)
	ORDER BY Mix