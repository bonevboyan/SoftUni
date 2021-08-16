CREATE FUNCTION udf_GetAvailableRoom
(@HotelId INT, @Date DATE, @People INT)
RETURNS VARCHAR(MAX)
AS 
BEGIN 
    DECLARE @RoomsBooked TABLE (Id INT)
    INSERT INTO @RoomsBooked
        SELECT DISTINCT r.Id 
        FROM Rooms AS r
        JOIN Trips AS t ON t.RoomId = r.Id
        WHERE r.HotelId = @HotelId AND @Date BETWEEN t.ArrivalDate AND t.ReturnDate AND t.CancelDate IS NULL
 
    DECLARE @Rooms TABLE (Id INT, Price DECIMAL(15,2), [Type] VARCHAR(20), Beds INT, TotalPrice DECIMAL(15,2))
    INSERT INTO @Rooms
        SELECT TOP(1) r.Id, r.Price, r.[Type], r.Beds, ((h.BaseRate + r.Price) * @People) AS TotalPrice
        FROM Rooms AS r
        JOIN Hotels AS h ON r.HotelId = h.Id
        WHERE r.HotelId = @HotelId AND r.Beds >= @People AND r.Id NOT IN (SELECT Id FROM @RoomsBooked)
        ORDER BY TotalPrice DESC
 
    DECLARE @RoomCount INT = (SELECT COUNT(*)  FROM @Rooms)
    IF (@RoomCount < 1)
	BEGIN
		RETURN 'No rooms available'
	END
 
    DECLARE @Result VARCHAR(MAX) = (SELECT CONCAT('Room ', Id, ': ', [Type],' (', Beds, ' beds',')', ' - ', '$', TotalPrice) FROM @Rooms)
    RETURN @Result
END