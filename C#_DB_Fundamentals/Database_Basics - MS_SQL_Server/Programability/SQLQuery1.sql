CREATE PROC usp_GetEmployeesSalaryAbove35000 
AS 
	SELECT 
		e.FirstName, 
		e.LastName
	FROM Employees AS e 
	WHERE e.Salary > 35000

GO
----------------------------------------------
CREATE PROC usp_GetEmployeesSalaryAboveNumber 
@Salary DECIMAL(18, 4)
AS 
	SELECT 
		e.FirstName,
		e.LastName
	FROM Employees AS e
	WHERE e.Salary >= @Salary

GO

--------------------------------------------
CREATE PROC usp_GetTownsStartingWith
@condition VARCHAR(10)
AS 
	SELECT
		t.Name
	FROM Towns AS t
	WHERE t.Name LIKE CONCAT(@condition, '%')

GO
---------------------------------------
CREATE FUNCTION ufn_GetSalaryLevel (@Salary DECIMAL(18, 4)) 
RETURNS VARCHAR(10)
AS 
BEGIN

	DECLARE @type VARCHAR(10);
	
	IF(@Salary < 30000)
		BEGIN
			SET @type = 'Low';
		END
	ELSE IF(@Salary <= 50000)
		BEGIN
			SET @type = 'Average'; 
		END 
	ELSE IF(@Salary > 50000)
		BEGIN
			SET @type = 'High'
		END 

	RETURN @type;
END

GO
---------------------------------------------
CREATE PROC usp_EmployeesBySalaryLevel 
@TypeOfSalary VARCHAR(10)
AS 

	SELECT 
		e.FirstName,
		e.LastName
	FROM Employees AS e
	WHERE (SELECT dbo.ufn_GetSalaryLevel(e.Salary)) = @TypeOfSalary

GO
--------------------------------------------

