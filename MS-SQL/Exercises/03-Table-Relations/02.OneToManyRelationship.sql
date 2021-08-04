CREATE TABLE Manufacturers
(
	ManufacturerID INT IDENTITY PRIMARY KEY,
	Name VARCHAR(20),
	EstablishedOn DATE 

)

CREATE TABLE Models
(
	ModelID INT IDENTITY(101, 1) PRIMARY KEY,
	Name VARCHAR(20),
	ManufacturerID INT REFERENCES Manufacturers(ManufacturerID)
)

INSERT INTO Manufacturers VALUES
('BMW', '1916-03-07'),
('Tesla', '2003-01-01'),
('Lada', '1916-05-01')

INSERT INTO Models VALUES
('X1', 1),
('i6', 1),
('Model S', 2),
('Model X', 2),
('Model 3', 2),
('Nova', 3)