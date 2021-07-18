USE Minions

CREATE TABLE People
(
	Id INT PRIMARY KEY NOT NULL, 
	Name NVARCHAR(200) NOT NULL,
	Picture VARBINARY(MAX),
	Weight DECIMAL(18,2),
	Gender VARCHAR (1) CHECK (Gender in ('f','m')),
	Birthdate DATE NOT NULL,
	Biography NVARCHAR(MAX)
)

INSERT INTO People (Id, Name, Picture, Weight, Gender, Birthdate, Biography) VALUES
(1, 'Andy', NULL, 5, 'f', '2008-11-11', 'dfdf'),
(2, 'Andy', NULL, 5, 'm', '2008-11-11', 'dfdf'),
(3, 'Andy', NULL, 5, 'f', '2008-11-11', 'dfdf'),
(4, 'Andy', NULL, 5, 'f', '2008-11-11', 'dfdf'),
(5, 'Andy', NULL, 5, 'f', '2008-11-11', 'dfdf')