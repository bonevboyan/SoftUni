USE SoftUni

SELECT TOP(50) FirstName, LastName, Towns.Name AS Town, AddressText
FROM Employees
JOIN Addresses ON Addresses.AddressID = Employees.AddressID
JOIN Towns ON Towns.TownID = Addresses.TownID
ORDER BY FirstName, LastName