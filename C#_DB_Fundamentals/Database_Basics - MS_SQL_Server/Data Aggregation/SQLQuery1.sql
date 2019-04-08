SELECT COUNT(*) FROM WizzardDeposits

-------------------------------
SELECT
	MAX(MagicWandSize) AS [LongestMagicWand]
FROM WizzardDeposits
--------------------------------------
SELECT 
	DepositGroup,
	MAX(MagicWandSize)
FROM WizzardDeposits
GROUP BY DepositGroup
----------------------------------------
SELECT TOP(2)
	DepositGroup
FROM WizzardDeposits
GROUP BY DepositGroup
ORDER BY AVG(MagicWandSize)
-----------------------------------------------
SELECT 
	w.DepositGroup,
	SUM(w.DepositAmount)
FROM WizzardDeposits as w
GROUP BY w.DepositGroup
------------------------------------------------
SELECT 
	w.DepositGroup,
	SUM(w.DepositAmount)
FROM WizzardDeposits AS w
WHERE w.MagicWandCreator = 'Ollivander family'
GROUP BY w.DepositGroup

------------------------------------------------
SELECT 
	w.DepositGroup,
	SUM(w.DepositAmount) AS [TotalSum]
FROM WizzardDeposits AS w
WHERE w.MagicWandCreator = 'Ollivander family'
GROUP BY w.DepositGroup
HAVING SUM(w.DepositAmount) < 150000
ORDER BY TotalSum DESC
----------------------------------------------
SELECT 
	DepositGroup,
	MagicWandCreator,
	MIN(DepositCharge)
FROM WizzardDeposits
GROUP BY DepositGroup, MagicWandCreator
ORDER BY MagicWandCreator ASC, DepositGroup ASC
-------------------------------------------------
SELECT
	CASE 
	WHEN w.Age >= 0 AND w.Age <= 10 THEN '[0-10]'
	WHEN w.Age >= 11 AND w.Age <= 20 THEN '[11-20]'
	WHEN w.Age >= 21 AND w.Age <= 30 THEN '[21-30]'
	WHEN w.Age >= 31 AND w.Age <= 40 THEN '[31-40]'
	WHEN w.Age >= 41 AND w.Age <= 50 THEN '[41-50]'
	WHEN w.Age >= 51 AND w.Age <= 60 THEN '[51-60]'
	WHEN w.Age >= 61 THEN '[61+]'
	END AS [AgeGroup],
	COUNT(w.Id)
FROM WizzardDeposits AS w
GROUP BY CASE 
	WHEN w.Age >= 0 AND w.Age <= 10 THEN '[0-10]'
	WHEN w.Age >= 11 AND w.Age <= 20 THEN '[11-20]'
	WHEN w.Age >= 21 AND w.Age <= 30 THEN '[21-30]'
	WHEN w.Age >= 31 AND w.Age <= 40 THEN '[31-40]'
	WHEN w.Age >= 41 AND w.Age <= 50 THEN '[41-50]'
	WHEN w.Age >= 51 AND w.Age <= 60 THEN '[51-60]'
	WHEN w.Age >= 61 THEN '[61+]'
	END
------------------------------------------------------
SELECT DISTINCT
	LEFT(w.FirstName, 1) AS [FirstLetter]
FROM WizzardDeposits AS w
WHERE w.DepositGroup = 'Troll Chest'
GROUP BY LEFT(w.FirstName, 1)
ORDER BY FirstLetter ASC
-------------------------------------------------------
SELECT
	w.DepositGroup,
	w.IsDepositExpired,
	AVG(w.DepositInterest)
FROM WizzardDeposits AS w
WHERE w.DepositStartDate > '1985-01-01'
GROUP BY w.DepositGroup, w.IsDepositExpired
ORDER BY w.DepositGroup DESC, w.IsDepositExpired ASC 
-----------------------------------------------------
SELECT
	e.DepartmentID,
	SUM(e.Salary) AS [TotalSalary]
FROM Employees AS e
GROUP BY e.DepartmentID
ORDER BY e.DepartmentID
---------------------------------------------------------
SELECT 
	e.DepartmentID,
	MIN(e.Salary)
FROM Employees AS e
WHERE e.DepartmentID IN (2, 5, 7) AND
e.HireDate > '2000-01-01'
GROUP BY e.DepartmentID
-----------------------------------------------------------
Select * into AvgSalaries FROM  Employees
WHERE Salary > 30000 

DELETE FROM AvgSalaries
WHERE ManagerID = 42

UPDATE AvgSalaries 
SET Salary += 5000
WHERE DepartmentID = 1

SELECT 
	a.DepartmentID,
	AVG(a.Salary)
FROM AvgSalaries AS a
GROUP BY a.DepartmentID
-------------------------------------------------------------
SELECT 
	e.DepartmentID,
	MAX(e.Salary) AS [MaxSalary]
FROM Employees AS e
GROUP BY e.DepartmentID
HAVING NOT MAX(e.Salary) BETWEEN 30000 AND 70000
------------------------------------------------------------
SELECT COUNT(EmployeeID) AS [Count] FROM Employees WHERE ManagerID IS NULL
--------------------------------------------------------------
SELECT k.DepartmentID, k.Salary 
FROM(
SELECT 
	DepartmentID, 
	Salary,
	DENSE_RANK() OVER (PARTITION BY DepartmentID ORDER BY Salary DESC) AS SalaryRank
FROM Employees) AS k
WHERE k.SalaryRank = 3 
GROUP BY k.DepartmentID, k.Salary
-----------------------------------------------------------
 SELECT TOP(10)
	e.FirstName, 
	e.LastName,
	e.DepartmentID
FROM Employees AS e
WHERE e.Salary > (SELECT AVG(Salary) FROM Employees AS em
WHERE em.DepartmentID = e.DepartmentID) 