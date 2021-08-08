USE Gringotts

SELECT 
	SUM(Diff) AS SumDifference 
FROM (
SELECT 
	DepositAmount - LEAD(DepositAmount) OVER (ORDER BY Id) AS Diff 
FROM WizzardDeposits) AS WizzDeposit