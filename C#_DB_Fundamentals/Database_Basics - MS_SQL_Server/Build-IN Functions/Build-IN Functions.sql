--Write a SQL query to find first and last names
--of all employees whose first name starts with “SA”. 

USE SoftUni

SELECT 
	[FirstName],
	[LastName]
FROM Employees
WHERE FirstName LIKE 'SA%'

--Write a SQL query to find first and last names of all
--employees whose last name contains “ei”. 

SELECT 
	[FirstName],
	[LastName]
FROM Employees
WHERE [LastName] LIKE '%ei%'

--Write a SQL query to find the first names of 
--all employees in the departments with ID 3 or 10 and
--whose hire year is between 1995 and 2005 inclusive.

SELECT 
	[FirstName]
FROM Employees
WHERE DepartmentID IN (3, 10) AND DATEPART(YEAR, HireDate) BETWEEN 1995 AND 2005

--Write a SQL query to find the first and
--last names of all employees whose job titles does not contain “engineer”. 

SELECT 
	[FirstName],
	[LastName]
FROM Employees
WHERE JobTitle NOT LIKE '%engineer%'

--Write a SQL query to find town
--names that are 5 or 6 symbols long and order them alphabetically by town name.

SELECT 
	[Name]
FROM Towns
WHERE LEN(Name) IN (5, 6) 
ORDER BY [Name] ASC

--Write a SQL query to find all towns that start
--with letters M, K, B or E. Order them alphabetically by town name. 

SELECT * 
FROM Towns
WHERE LEFT(Name, 1) IN ('M', 'K', 'B', 'E')
ORDER BY [Name] ASC

--Write a SQL query to find all towns that
--does not start with letters R, B or D. Order them alphabetically by name. 

SELECT * 
FROM Towns
WHERE LEFT(Name, 1) NOT IN ('R', 'B', 'D')
ORDER BY [Name] ASC

--Write a SQL query to create view V_EmployeesHiredAfter2000 
--with first and last name to all employees hired after 2000 year. 

GO

CREATE VIEW V_EmployeesHiredAfter2000 AS 
SELECT 
	[FirstName],
	[LastName]
FROM Employees
WHERE YEAR(HireDate) > 2000

--Write a SQL query to find the names
--of all employees whose last name is exactly 5 characters long.

SELECT
	[FirstName],
	[LastName]
FROM Employees
WHERE LEN(LastName) = 5

--Write a query that ranks all employees using DENSE_RANK.
--In the DENSE_RANK function, employees need to be partitioned by Salary 
--and ordered by EmployeeID. You need to find only the employees whose Salary
-- is between 10000 and 50000 and order them by Salary in descending order.

SELECT e.EmployeeID, e.FirstName, e.LastName, e.Salary
    ,DENSE_RANK() OVER   
    (PARTITION BY e.Salary ORDER BY e.EmployeeID) AS [Rank]
	FROM Employees AS e
	WHERE [Salary] BETWEEN 10000 AND 50000
ORDER BY [Salary] DESC 

SELECT *
FROM (
SELECT EmployeeID,
FirstName,
LastName,
Salary,
DENSE_RANK() OVER(PARTITION BY Salary ORDER BY EmployeeID) AS Rank
FROM Employees AS R 
) Employees 
WHERE Rank = 2 AND Salary BETWEEN 10000 AND 50000 
ORDER BY Salary DESC

----------------------------------------------------------------

USE Geography

--Find all countries that holds the letter 'A' in their name at
-- least 3 times (case insensitively), sorted by ISO code. 
--Display the country name and ISO code. 

SELECT 
	[CountryName],
	[IsoCode]
FROM Countries
WHERE len(CountryName) - len(replace(CountryName,'A','')) >= 3
ORDER BY [IsoCode]

--Combine all peak names with all river names, so that the last letter
--of each peak name is the same as the first letter of its corresponding river name.
--Display the peak names, river names, and the obtained mix (mix should be in lowercase). 
--Sort the results by the obtained mix.

-------------------------------------------------------------------------
USE Diablo

--Find the top 50 games ordered by start date, then by name of the game. 
--Display only games from 2011 and 2012 year. Display start date in the format
-- “yyyy-MM-dd”. 

SELECT TOP(50)
	[Name],
	FORMAT([Start], 'yyyy-MM-dd') AS [Start]
FROM Games
WHERE YEAR(Start) IN (2011, 2012)
ORDER BY [Start], [Name] 

--Find all users along with information about their email providers. 
--Display the username and email provider. Sort the results Plby email provider 
--alphabetically, then by username. 

USE Geography

SELECT 
	PeakName,
	RiverName,
	LOWER(PeakName + SUBSTRING(RiverName, 2, LEN(RiverName))) AS Mix
FROM Peaks, Rivers
WHERE RIGHT(PeakName, 1) = LEFT(RiverName, 1)
ORDER BY Mix

USE Diablo
-----
--15 
SELECT 
	[Username],
	SUBSTRING(Email, CHARINDEX('@', Email) + 1, LEN(Email)) AS [Email Provider]
FROM Users
ORDER BY [Email Provider], [Username]

--Find all users along with their IP addresses sorted by username alphabetically.
-- Display only rows that IP address matches the pattern: “***.1^.^.***”. 
--Legend: * - one symbol, ^ - one or more symbols

SELECT
	[Username],
	[IpAddress]
FROM Users
WHERE [IpAddress] LIKE '___.1_%._%.___'
ORDER BY [Username]

SELECT 
	[Name] as [Game],
	CASE 
	WHEN DATEPART(HOUR, [Start]) >= 0 AND DATEPART(HOUR, [Start]) < 12 THEN 'Morning'
	WHEN DATEPART(HOUR, [Start]) >= 12 AND DATEPART(HOUR, [Start]) < 18 THEN 'Afternoon'
	WHEN DATEPART(HOUR, [Start]) >= 18 AND DATEPART(HOUR, [Start]) < 24 THEN 'Evening'
	END AS [Part Of the Day],
 	CASE 
	WHEN Duration <= 3 THEN 'Extra Short'
	WHEN Duration BETWEEN 4 AND 6 THEN 'Short'
	WHEN Duration >= 6 THEN 'Long'
	WHEN Duration IS NULL THEN 'Extra Long'
	END AS [Duration]
FROM Games 
ORDER BY Name, Duration, [Part of the Day]
---
--18

use Orders

SELECT 
	[ProductName],
	[OrderDate],
	DATEADD(DAY, 3, OrderDate) AS [Pay Due],
	DATEADD(MONTH, 1, OrderDate) AS [Deliver Due]
FROM Orders


SELECT *
FROM (
SELECT EmployeeID,
FirstName,
LastName,
Salary,
DENSE_RANK() OVER(PARTITION BY Salary ORDER BY EmployeeID) AS Rank
FROM Employees AS R 
) Employees 
WHERE Rank = 2 AND Salary BETWEEN 10000 AND 50000 
ORDER BY Salary DESC