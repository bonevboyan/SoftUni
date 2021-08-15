CREATE PROCEDURE usp_TransferMoney
(@SenderId INT, @ReceiverId INT, @Amount MONEY)
AS
	BEGIN TRANSACTION
		EXEC dbo.usp_WithdrawMoney @SenderId, @Amount
		EXEC dbo.usp_DepositMoney @ReceiverId, @Amount
		IF ((SELECT Balance FROM Accounts WHERE Accounts.Id = @SenderId) < 0)
			ROLLBACK
	COMMIT