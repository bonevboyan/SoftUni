USE SoftUni

SELECT TOP(5) EmployeeID, JobTitle, Employees.AddressID, AddressText
FROM Employees
JOIN Addresses ON Employees.AddressID = Addresses.AddressID
ORDER BY Employees.AddressID