CREATE PROCEDURE usp_SwitchRoom(@TripId int, @TargetRoomId int)
AS
	DECLARE @SourceHotelId INT = 
	(SELECT h.Id
	FROM Hotels AS h
	JOIN Rooms AS r ON r.HotelId = h.Id
	JOIN Trips AS t ON t.RoomId = r.Id
	WHERE t.Id = @TripId)
 
	DECLARE @TargetHotelId INT = 
	(SELECT h.Id
	FROM Hotels AS h
	JOIN Rooms AS r ON h.Id = r.HotelId
	WHERE r.Id = @targetRoomId)
 
	IF (@SourceHotelId != @TargetHotelId)
		RAISERROR('Target room is in another hotel!', 16, 1)
 
	DECLARE @PeopleCount INT = (SELECT COUNT(*) FROM AccountsTrips WHERE TripId = @TripId)
	DECLARE @TargetRoomBeds INT = (SELECT Beds FROM Rooms WHERE Id = @TargetRoomId)
	IF (@PeopleCount > @TargetRoomBeds)
		RAISERROR('Not enough beds in target room!', 16, 1)
 
	UPDATE Trips
	SET RoomId = @TargetRoomId
	WHERE Id = @TripId
GO