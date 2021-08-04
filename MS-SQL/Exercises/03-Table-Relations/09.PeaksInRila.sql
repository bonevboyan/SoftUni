SELECT Mountains.MountainRange, Peaks.PeakName, Peaks.Elevation
	FROM Mountains
	JOIN Peaks ON Mountains.Id = Peaks.MountainId
	WHERE MountainRange = 'Rila'
	ORDER BY Elevation DESC