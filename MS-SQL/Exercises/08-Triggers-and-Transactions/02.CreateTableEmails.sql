CREATE TABLE NotificationEmails
(
	Id INT IDENTITY PRIMARY KEY,
	Recipient INT, 
	Subject VARCHAR(100), 
	Body VARCHAR(300)
)

CREATE TRIGGER tr_CreateTableEmails
ON Logs AFTER INSERT
AS
	DECLARE @recipient INT = (SELECT AccountId FROM inserted)
	DECLARE @subject  VARCHAR(100) = (CONCAT('Balance change for account: ', (SELECT AccountId FROM inserted)))
	DECLARE @body VARCHAR(300) = (CONCAT('On ', (SELECT GETDATE() FROM inserted), 'your balance was changed from ', (SELECT OldSum FROM inserted), 'to ', (SELECT NewSum FROM inserted), '.'))

    INSERT INTO NotificationEmails
    VALUES (@recipient, @subject, @body)
GO