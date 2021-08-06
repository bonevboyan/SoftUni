USE Diablo

SELECT Name AS Game,
CASE 
	WHEN DATEPART(HOUR, Start) Between 0 and 11 Then 'Morning'
	WHEN DATEPART(HOUR, Start) Between 12 and 17 Then 'Afternoon'
	WHEN DATEPART(HOUR, Start) Between 18 and 23 Then 'Evening'
END AS [Part of the Day],
CASE
	WHEN Duration <=3 THEN 'Extra Short'
	WHEN Duration Between 4 AND 6 THEN 'Short'
	WHEN Duration >6 THEN 'Long'
	WHEN Duration IS NULL THEN 'Extra Long'
END AS [Duration]
FROM Games
Order BY Game ASC, [Duration], [Part of the Day]