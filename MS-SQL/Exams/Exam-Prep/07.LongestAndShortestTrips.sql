SELECT 
	a.Id, 
	a.FirstName + ' ' + a.LastName AS FullName,
	MAX(DATEDIFF ( DAY , t.ArrivalDate, t.ReturnDate)) AS LongestTrip,  
	MIN(DATEDIFF ( DAY , t.ArrivalDate, t.ReturnDate)) AS ShortestTrip  
FROM AccountsTrips at
JOIN Accounts a ON at.AccountId = a.Id
JOIN Trips t ON at.TripId = t.Id
WHERE a.MiddleName IS NULL AND t.CancelDate IS NULL
GROUP BY a.Id, a.FirstName, a.LastName
ORDER BY LongestTrip DESC, ShortestTrip ASC