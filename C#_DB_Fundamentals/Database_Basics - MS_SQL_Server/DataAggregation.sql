SELECT COUNT(*) FROM WizzardDeposits

SELECT MAX(MagicWandSize) AS [LongestMagicWand] FROM WizzardDeposits

SELECT DepositGroup, MAX(MagicWandSize) FROM WizzardDeposits
GROUP BY DepositGroup

SELECT TOP(2) DepositGroup FROM WizzardDeposits
GROUP BY DepositGroup
ORDER BY AVG(MagicWandSize) ASC