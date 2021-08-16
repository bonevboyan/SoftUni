SELECT
	t.Id,
	CONCAT(a.FirstName, ' ', ISNULL(a.MiddleName + ' ', ''), a.LastName) AS [Full Name],
	c.Name AS [From],
	c1.Name AS [To],
	CASE 
		WHEN t.CancelDate IS NOT NULL THEN 'Canceled'
		ELSE CAST(DATEDIFF ( DAY , t.ArrivalDate, t.ReturnDate) AS varchar) + ' days' 
	END AS Duration  
FROM AccountsTrips at
JOIN Accounts a ON a.Id = at.AccountId
JOIN Trips t ON t.Id = at.TripId
JOIN Cities c ON c.Id = a.CityId
JOIN Rooms r ON r.Id = t.RoomId
JOIN Hotels h ON h.Id = r.HotelId
JOIN Cities c1 ON c1.Id = h.CityId
ORDER BY [Full Name] , t.Id