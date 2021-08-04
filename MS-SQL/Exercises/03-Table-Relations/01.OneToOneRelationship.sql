CREATE TABLE Passports
(
	PassportID INT PRIMARY KEY,
	PassportNumber CHAR(8)
)

CREATE TABLE Persons
(
	PersonId INT IDENTITY PRIMARY KEY,
	FirstName NVARCHAR(20),
	Salary DECIMAL(18,2),
	PassportID INT UNIQUE REFERENCES Passports(PassportID)

)

INSERT INTO Passports VALUES
(101, 'N34FG21B'),
(102, 'K65LO4R7'),
(103, 'ZE657QP2')

INSERT INTO Persons VALUES
('Roberto', 43300, 102),
('Tom', 56100, 103),
('Yana', 60200, 101)