SELECT TOP(5)
	E.EmployeeID,
	E.JobTitle,
	A.AddressID,
	A.AddressText
FROM Employees AS E
JOIN Addresses AS a on E.AddressID = a.AddressID
ORDER BY A.AddressID
----------------------------------------------------
SELECT top(50)
	e.FirstName,
	e.LastName, 
	t.Name,
	a.AddressText
FROM Employees AS e
JOIN Addresses AS a ON e.AddressID = a.AddressID
JOIN Towns AS t ON a.TownID = t.TownID
ORDER BY e.FirstName, e.LastName
---------------------------------------------------
SELECT 
	e.EmployeeID,
	e.FirstName,
	e.LastName,
	d.Name
FROM Employees AS e
LEFT JOIN Departments AS d ON e.DepartmentID = d.DepartmentID 
WHERE D.DepartmentID = 3
ORDER BY e.EmployeeID
---------------------------------------------------
SELECT TOP(5)
	e.EmployeeID,
	e.FirstName,
	e.Salary,
	d.Name AS [DepartmentName]
FROM Employees AS e
LEFT JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE e.Salary > 15000
ORDER BY e.DepartmentID
---------------------------------------------------
SELECT TOP(3)
	e.EmployeeID,
	e.FirstName 
FROM Employees AS e
LEFT JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
LEFT JOIN Projects AS p ON ep.ProjectID = p.ProjectID
WHERE ep.ProjectID IS NULL
ORDER BY e.EmployeeID

----------------------------------------------------
SELECT 
	e.FirstName,
	e.LastName,
	e.HireDate,
	d.Name
FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE e.HireDate > '1999-01-01' AND d.Name IN ('Sales', 'Finance')
ORDER BY e.HireDate
------------------------------------------------------
SELECT TOP(5)
	e.EmployeeID,
	e.FirstName,
	p.Name
FROM Employees AS e
JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
LEFT JOIN Projects AS p ON ep.ProjectID = p.ProjectID
WHERE p.StartDate > '2002-08-13' AND p.EndDate IS NULL
ORDER BY e.EmployeeID 

---------------------------------------------------------------
SELECT 
	e.EmployeeID,
	e.FirstName,
	CASE 
	WHEN YEAR(p.StartDate) >= 2005 THEN NULL
	ELSE p.Name 
	END AS [ProjectName]
FROM Employees AS e
JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
LEFT JOIN Projects AS p ON ep.ProjectID = p.ProjectID
WHERE e.EmployeeID = 24
----------------------------------------------------------------
SELECT
	e.EmployeeID,
	e.FirstName,
	m.EmployeeID AS ManagerID,
	m.FirstName	AS ManagerName
FROM Employees AS e
JOIN Employees AS m ON m.EmployeeID = e.ManagerID 
WHERE e.ManagerID IN (3, 7)
ORDER BY e.EmployeeID
---------------------------------------------------------------
SELECT TOP(50)
	e.EmployeeID,
	e.FirstName + ' ' +  e.LastName AS EmployeeName,
	m.FirstName + ' ' +  m.LastName AS ManagerName,
	d.Name AS DepartmentName
FROM Employees AS e
JOIN Employees AS m ON e.ManagerID = m.EmployeeID
LEFT JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
ORDER BY e.EmployeeID
-------------------------------------------------------------
SELECT
MIN(d.AvgSalary) AS MinAverageSalary
FROM (
SELECT 
	d.DepartmentID,
	AVG(e.Salary) AS AvgSalary
FROM Employees AS e
LEFT JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
GROUP BY d.DepartmentID
) AS d
--------------------------------------------------------------
SELECT 
	c.CountryCode,
	m.MountainRange,
	p.PeakName,
	p.Elevation
FROM Peaks AS p
LEFT JOIN Mountains AS m ON p.MountainId = m.Id
LEFT JOIN MountainsCountries AS mc ON m.Id = mc.MountainId
LEFT JOIN Countries AS c ON mc.CountryCode = c.CountryCode
WHERE p.Elevation > 2835 AND c.CountryCode = 'BG'
ORDER BY p.Elevation DESC
---------------------------------------------------------------
SELECT 
	c.CountryCode,
	COUNT(m.MountainRange)
FROM Mountains AS m
LEFT JOIN MountainsCountries AS mc ON m.Id = mc.MountainId
LEFT JOIN Countries AS c ON mc.CountryCode = c.CountryCode 
WHERE c.CountryCode IN ('US', 'RU', 'BG')
GROUP BY c.CountryCode

----------------------------------------------------------
SELECT TOP(5)
	c.CountryName,
	r.RiverName 
FROM Rivers AS r
RIGHT JOIN CountriesRivers AS cr ON r.Id = cr.RiverId
RIGHT JOIN Countries AS c ON cr.CountryCode = c.CountryCode
RIGHT JOIN Continents AS co on c.ContinentCode = co.ContinentCode
WHERE co.ContinentCode = 'AF' 
ORDER BY c.CountryName
---------------------------------------------------------
SELECT 
	MostUsedCurrency.ContinentCode,
	MostUsedCurrency.CurrencyCode,
	MostUsedCurrency.CurrencyUsage
FROM
(
SELECT 
	c.ContinentCode, 
	c.CurrencyCode, 
	COUNT(c.CurrencyCode) AS CurrencyUsage,
	DENSE_RANK() OVER(PARTITION BY ContinentCode ORDER BY COUNT(c.CurrencyCode) DESC) AS [CurrencyRank]
FROM Countries AS c
GROUP BY c.ContinentCode, c.CurrencyCode
HAVING COUNT(c.CurrencyCode) > 1
) AS MostUsedCurrency
WHERE MostUsedCurrency.CurrencyRank = 1
ORDER BY MostUsedCurrency.ContinentCode, MostUsedCurrency.CurrencyUsage
-----------------------------------------------------------------
SELECT	
	COUNT(c.Capital) AS CountryCode
FROM Countries AS c
LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
LEFT JOIN  Mountains AS m ON mc.MountainId = m.Id
WHERE mc.MountainId IS NULL
-------------------------------------------------------------------
SELECT TOP(5)
	c.CountryName,
	MAX(p.Elevation) AS HighestPeakElevation,
	MAX(r.Length) AS LongestRiverLength
FROM Countries AS c
LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
LEFT JOIN Mountains AS m ON mc.MountainId = m.Id
LEFT JOIN Peaks AS p ON mc.MountainId = p.MountainId
LEFT JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
LEFT JOIN Rivers AS r ON cr.RiverId = r.Id
GROUP BY c.CountryName
ORDER BY HighestPeakElevation DESC, LongestRiverLength DESC, c.CountryName
----------------------------------------------------------------------------
SELECT	
	k.CountryName,
	ISNULL(k.PeakName, '(no highest peak)'),
	ISNULL(k.MaxElevation, 0),
	ISNULL(k.MountainRange, '(no mountain)')
	FROM 
	(
	SELECT TOP(5)	
		c.CountryName,
		MAX(p.Elevation) AS MaxElevation,
		p.PeakName,
		m.MountainRange,
		DENSE_RANK() OVER(PARTITION BY c.CountryName ORDER BY MAX(p.Elevation) DESC) AS ElevationRanl 
	FROM Countries AS c
	LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
	LEFT JOIN Mountains AS m ON mc.MountainId = m.Id
	LEFT JOIN Peaks AS p ON m.Id = p.MountainId
GROUP BY c.CountryName, p.PeakName, m.MountainRange
) AS k
WHERE k.ElevationRanl = 1
ORDER BY k.CountryName, k.PeakName
