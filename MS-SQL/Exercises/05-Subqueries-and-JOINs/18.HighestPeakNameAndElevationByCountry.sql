USE Geography

SELECT TOP 5
  d.CountryName AS [Country],
  ISNULL(d.PeakName, '(no highest peak)') AS [Highest Peak Name],
  ISNULL(d.Elevation, 0) AS [Highest Peak Elevation],
  CASE 
  WHEN d.PeakName IS NOT NULL
    THEN d.MountainRange
	ELSE '(no mountain)' END AS [Mountain]
FROM (
SELECT
   c.CountryName,
   p.PeakName,
   p.Elevation,
   m.MountainRange,
   ROW_NUMBER()
   OVER ( PARTITION BY c.CountryName ORDER BY p.Elevation DESC ) AS rn
FROM Countries AS c
LEFT JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
LEFT JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
LEFT JOIN Mountains AS m ON mc.MountainId = m.Id
LEFT JOIN Peaks p ON p.MountainId = m.Id) AS d
WHERE rn = 1
ORDER BY d.CountryName ASC, d.PeakName ASC