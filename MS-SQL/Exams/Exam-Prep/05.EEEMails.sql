SELECT 
	FirstName,
	LastName,
	FORMAT (BirthDate, 'MM-dd-yyyy') as BirthDate,
	Cities.Name AS Hometown,
	Email
FROM Accounts
JOIN Cities ON Cities.Id = Accounts.CityId
WHERE LEFT(Email, 1) = 'e'
ORDER BY Cities.Name ASC