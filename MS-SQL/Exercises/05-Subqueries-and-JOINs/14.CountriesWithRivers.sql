USE Geography

SELECT TOP(5)
	c.CountryName,
	r.RiverName
FROM Countries AS c
FULL JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
FULL JOIN Rivers AS r ON cr.RiverId = r.Id
WHERE c.ContinentCode = 'AF'
ORDER BY CountryName ASC