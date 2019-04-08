USE Softuni

SELECT * FROM Departments

SELECT [Name] as [Name] FROM Departments

SELECT FirstName, LastName, Salary FROM Employees

SELECT FirstName, MiddleName, LastName FROM Employees

SELECT FirstName + '.' + LastName + '@softuni.bg' AS [Full Email Address]
FROM Employees
	
SELECT DISTINCT Salary FROM Employees

SELECT * FROM Employees WHERE JobTitle = 'Sales Representative'

SELECT FirstName, LastName, JobTitle FROM Employees WHERE Salary BETWEEN 20000 AND 30000

SELECT FirstName + ' ' + MiddleName + ' ' +  LastName AS [FullName] FROM Employees
WHERE Salary = 25000 OR Salary = 14000 OR Salary = 12500 OR Salary = 23600

SELECT FirstName, LastName FROM Employees WHERE ManagerID IS NULL

SELECT FirstName, LastName, Salary FROM Employees 
WHERE Salary > 50000
ORDER BY Salary DESC 

SELECT TOP(5) FirstName, LastName FROM Employees 
ORDER BY Salary DESC

SELECT FirstName, LastName FROM Employees
WHERE DepartmentID != 4

SELECT * FROM Employees 
ORDER BY
Salary DESC,
FirstName,
LastName DESC,
MiddleName

GO

CREATE VIEW V_EmployeesSalaries AS
SELECT FirstName, LastName, Salary FROM Employees

GO

CREATE VIEW V_EmployeeNameJobTitle AS 
SELECT FirstName + ' ' + ISNULL(MiddleName, '') + ' ' + LastName AS [Full Name],
JobTitle AS [Job Title]
FROM Employees

GO

SELECT DISTINCT JobTitle FROM Employees

SELECT TOP(10) * FROM Projects
ORDER BY
StartDate ASC,
[Name] ASC

SELECT TOP(7) FirstName, LastName, HireDate FROM Employees
ORDER BY HireDate DESC

SELECT * FROM Departments
WHERE [Name] IN ('Engineering', 'Tool Design', 'Marketing', 'Information Services')

UPDATE Employees
SET Salary *= 1.12
WHERE DepartmentID IN(1, 2, 4, 11)

SELECT Salary FROM Employees