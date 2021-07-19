CREATE DATABASE Movies

USE Movies

CREATE TABLE Directors
(
	Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	DirectorName VARCHAR(MAX),
	Notes VARCHAR(MAX)
)

CREATE TABLE Genres
(
	Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	GenreName VARCHAR(MAX),
	Notes VARCHAR(MAX)
)

CREATE TABLE Categories
(
	Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	CategoryName VARCHAR(MAX),
	Notes VARCHAR(MAX)
)

CREATE TABLE Movies
(
	Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Title VARCHAR(MAX),
	DirectorId INT,
	CopyrightYear INT,
	Length INT, 
	GenreId INT,
	CategoryId INT,
	Rating INT,
	Notes VARCHAR(MAX)
)

ALTER TABLE Movies
ADD FOREIGN KEY (DirectorId) REFERENCES Directors(Id)

ALTER TABLE Movies
ADD FOREIGN KEY (GenreId) REFERENCES Genres(Id)

ALTER TABLE Movies
ADD FOREIGN KEY (CategoryId) REFERENCES Categories(Id)

INSERT INTO Directors(DirectorName, Notes) VALUES
('Bob', 'nice'),
('Brush', 'nice'),
('Brock', 'nice'),
('Banana', 'nice'),
('Bowl', 'nice')

INSERT INTO Genres(GenreName, Notes) VALUES
('Drama', 'nice'),
('Crime', 'nice'),
('Thriller', 'nice'),
('Horror', 'nice'),
('Comedy', 'nice')

INSERT INTO Categories(CategoryName, Notes) VALUES
('ct1', 'nice'),
('ct2', 'nice'),
('ct3', 'nice'),
('ct4', 'nice'),
('ct5', 'nice')

INSERT INTO Movies(Title, DirectorId, CopyrightYear, Length, GenreId, CategoryId, Rating, Notes) VALUES
('The Phantom Menace', 1, 2000, 117, 2, 3, 5, 'nopp'),
('Attack of the Clones', 1, 2001, 117, 2, 3, 5, 'nopp'),
('Revenge of the Sith', 1, 2002, 117, 2, 3, 5, 'nopp'),
('A New Hope', 1, 1977, 117, 2, 3, 5, 'nopp'),
('The Empire Striles Back', 1, 1980, 117, 2, 3, 5, 'nopp')