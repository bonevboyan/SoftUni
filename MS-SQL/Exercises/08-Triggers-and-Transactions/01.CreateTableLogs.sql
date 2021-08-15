USE Bank

CREATE TABLE Logs
(
	LogId INT IDENTITY PRIMARY KEY,
	AccountId INT REFERENCES Accounts(Id),
	OldSum MONEY,
	NewSum MONEY
)

CREATE TRIGGER tr_LogBalanceChanges
ON Accounts FOR UPDATE
AS
	DECLARE @newSum DECIMAL(15, 2) = (SELECT Balance FROM inserted)
	DECLARE @oldSum DECIMAL(15, 2) = (SELECT Balance FROM deleted)
	DECLARE @accountId INT = (SELECT Id FROM inserted)

	INSERT INTO Logs(AccountId, NewSum, OldSum) VALUES (@accountId, @newSum, @oldSum)
GO

SELECT * FROM Logs