USE Minions

CREATE TABLE Users
(
	Id BIGINT PRIMARY KEY NOT NULL,
	Username VARCHAR(30) UNIQUE NOT NULL,
	Password VARCHAR(26) NOT NULL,
	ProfilePicture VARBINARY(MAX),
	LastLoginTime DATETIME,
	IsDeleted BIT
)

INSERT INTO Users (Id, Username, Password, ProfilePicture, LastLoginTime, IsDeleted) VALUES
(1, 'Bob', 'a', NULL,'2008-11-11', 0),
(2, 'Bubba', 'a', NULL, '2008-11-11', 0),
(3, 'Bobby', 'a', NULL,'2008-11-11', 0),
(4, 'Boy', 'a', NULL, '2008-11-11', 0),
(5, 'Brick', 'a', NULL,'2008-11-11', 0)