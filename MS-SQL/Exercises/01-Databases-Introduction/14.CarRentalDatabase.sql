CREATE DATABASE CarRental

USE CarRental

CREATE TABLE Categories
(
	Id INT PRIMARY KEY,
	CategoryName VARCHAR(30) NOT NULL, 
	DailyRate DECIMAL(18,2),
	WeeklyRate DECIMAL(18,2),
	MonthlyRate DECIMAL(18,2),
	WeekendRate DECIMAL(18,2)
)

INSERT INTO Categories VALUES
(1, 'Truck', 1, 2, 3, 4),
(2, 'Car', 1, 2, 3, 4),
(3, 'Jeep', 1, 2, 3, 4)

CREATE TABLE Cars
(
	Id INT PRIMARY KEY,
	PlateNumber VARCHAR(30) NOT NULL, 
	Manufacturer VARCHAR(30),
	Model VARCHAR(30),
	CarYear INT,
	CategoryId INT,
	Doors VARCHAR(30),
	Picture VARBINARY(MAX),
	Condition VARCHAR(30),
	Available BIT
)

INSERT INTO Cars VALUES
(1, 'CA000CA', 'Toyota', 'Corolla', 2009, 1, 'Open', NULL, 'Good', 1),
(2, 'CA001DA', 'BMW', '6', 2012, 1, 'Open', NULL, 'Good', 1),
(3, 'CA002CA', 'Citroen', 'E3', 2015, 1, 'Open', NULL, 'Good', 1)

CREATE TABLE Employees
(
	Id INT PRIMARY KEY,
	FirstName VARCHAR(30) NOT NULL,
	LastName VARCHAR(30) NOT NULL,
	Title VARCHAR(30) NOT NULL,
	Notes VARCHAR(MAX)
)

INSERT INTO Employees VALUES
(1, 'Alice', 'Alos', 'CEO', NULL),
(2, 'Cesar', 'Alos', 'CTO', NULL),
(3, 'Zeus', 'Alos', 'HR', NULL)

CREATE TABLE Customers
(
	Id INT PRIMARY KEY,
	DriverLicenceNumber VARCHAR(30) NOT NULL,
	FullName VARCHAR(100) NOT NULL,
	Address VARCHAR(150),
	City VARCHAR(30),
	ZIPCode CHAR(4),
	Notes VARCHAR(MAX)
)

INSERT INTO Customers VALUES
(1, 'NUMBER1987', 'George Michael', NULL, NULL, NULL, NULL),
(2, 'NUMBER1789', 'George Johnson', NULL, NULL, NULL, NULL),
(3, 'NUMBER2004', 'George Stevens', NULL, NULL, NULL, NULL)

CREATE TABLE RentalOrders
(
	Id INT PRIMARY KEY,
	EmployeeId INT NOT NULL,
	CustomerId INT NOT NULL,
	CarId INT NOT NULL,
	TankLevel DECIMAL(3,2),
	KilometrageStart INT,
	KilometrageEnd INT,
	TotalKilometrage INT,
	StartDate DATE,
	EndDate DATE,
	TotalDays INT,
	RateApplied INT,
	TaxRate INT,
	OrderStatus VARCHAR(30),
	NOTES VARCHAR(MAX)
)

INSERT INTO RentalOrders VALUES
(1, 2, 1, 3, NULL, 1, 100, 50, GETDATE(), GETDATE(),  4, 1, 2, 'Shipping', NULL),
(2, 1, 3, 2, NULL, 1, 100, 50, GETDATE(), GETDATE(),  4, 1, 2, 'Shipping', NULL),
(3, 2, 1, 2, NULL, 1, 100, 50, GETDATE(), GETDATE(),  4, 1, 2, 'Shipping', NULL)