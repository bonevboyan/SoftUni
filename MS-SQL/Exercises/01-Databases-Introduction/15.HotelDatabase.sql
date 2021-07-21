--CREATE DATABASE Hotel

USE Hotel

CREATE TABLE Employees
(
	Id INT PRIMARY KEY,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	Title VARCHAR(50) NOT NULL,
	Notes VARCHAR(MAX)
)

INSERT INTO Employees (Id, FirstName, LastName, Title, Notes) VALUES
(1, 'Bob', 'Tabor', 'Lecturer', NULL),
(2, 'Bobba', 'Tabora', 'CEO', NULL),
(3, 'Bobby', 'Tabory', 'Programmer', NULL)

CREATE TABLE Customers
(
	AccountNumber INT PRIMARY KEY,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	PhoneNumber CHAR(10) NOT NULL,
	EmergencyName VARCHAR(50) NOT NULL,
	EmergencyNumber CHAR(10) NOT NULL,
	Notes VARCHAR(MAX)
)

INSERT INTO Customers (AccountNumber, FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber, Notes) VALUES
(111, 'Amy', 'Wood', '9871222345', 'Ames', '8871222345', NULL),
(222, 'Emily', 'Woods', '9871222346', 'Emiles', '8871222346', NULL),
(333, 'Emma', 'Stone', '9871222347', 'Emmas', '8871222347', NULL)

CREATE TABLE RoomStatus
(
	RoomStatus VARCHAR(20) NOT NULL,
	Notes VARCHAR(MAX)
)

INSERT INTO RoomStatus VALUES
('Free', NULL),
('Occupied', NULL),
('WOP', NULL)

CREATE TABLE RoomTypes
(
	RoomType VARCHAR(20) NOT NULL,
	Notes VARCHAR(MAX)
)

INSERT INTO RoomTypes VALUES
('Studio' , NULL),
('Flat' , NULL),
('One Bedroom' , NULL)

CREATE TABLE BedTypes
(
	BedType VARCHAR(20) NOT NULL,
	Notes VARCHAR(MAX)
)

INSERT INTO BedTypes VALUES
('Single' , NULL),
('Double' , NULL),
('Triple' , NULL)

CREATE TABLE Rooms
(
	RoomNumber INT PRIMARY KEY,
	RoomType VARCHAR(20) NOT NULL,
	BedType VARCHAR(20) NOT NULL,
	Rate INT,
	RoomStatus VARCHAR(20) NOT NULL,
	Notes VARCHAR(MAX)
)

INSERT INTO ROOMS VALUES
(120, 'Studio', 'Single', 10,  'Free', NULL),
(121, 'Flat', 'Double', 10,  'Free', NULL),
(122, 'Flat', 'Triple', 10,  'Free', NULL)

CREATE TABLE Payments
(
	Id INT PRIMARY KEY,
	EmployeeId INT NOT NULL,
	PaymentDate DATETIME NOT NULL,
	AccountNumber INT NOT NULL,
	FirstDateOccupied DATETIME NOT NULL,
	LastDateOccupied DATETIME NOT NULL,
	TotalDays INT NOT NULL,
	AmountCharged DECIMAL(18,2),
	TaxRate INT,
	TaxAmount INT,
	PaymentsTotal DECIMAL(18,2),
	Notes VARCHAR(MAX)
)

INSERT INTO Payments VALUES
(1, 1, GETDATE(), 120, '5/5/2012', '5/8/2012', 3, 450, NULL, NULL, 450, NULL),
(2, 1, GETDATE(), 120, '5/5/2013', '5/8/2009', 3, 450, NULL, NULL, 450, NULL),
(3, 1, GETDATE(), 120, '5/7/2014', '5/8/2018', 3, 450, NULL, NULL, 450, NULL)

CREATE TABLE Occupancies
(
	Id INT PRIMARY KEY,
	EmployeeId INT NOT NULL,
	DateOccupied DATETIME NOT NULL,
	AccountNumber INT NOT NULL,
	RoomNumber INT NOT NULL,
	RateApplied INT,
	PhoneCharge DECIMAL(18,2),
	Notes VARCHAR(MAX)
)

INSERT INTO Occupancies VALUES
(1 ,120, GETDATE(), 12, 120, 0, 0, NULL),
(2, 120, GETDATE(), 78, 4, 0, 0, NULL),
(3, 120, GETDATE(), 86, 56, 0, 0, NULL)