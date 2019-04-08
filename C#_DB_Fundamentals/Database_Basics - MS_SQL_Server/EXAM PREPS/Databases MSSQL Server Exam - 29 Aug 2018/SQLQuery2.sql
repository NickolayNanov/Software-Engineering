INSERT INTO Employees VALUES
('Stoyan', 'Petrov', '888-785-8573', 500.25),
('Stamat', 'Nikolov', '789-613-1122', 999995.25),
('Evgeni', 'Petkov', '645-369-9517', 1234.51),
('Krasimir', 'Vidolov', '321-471-9982', 50.25)

INSERT INTO Items VALUES
('Tesla battery', 154.25, 8),
('Chess', 30.25, 8),
('Juice', 5.32, 1),
('Glasses', 10, 8),
('Bottle of water', 1, 1)
-----------------------------------------------------
UPDATE Items
SET Price = Price * 1.27
WHERE CategoryId IN (1, 2, 3)
------------------------------------------------------
DELETE FROM OrderItems
WHERE OrderId = 48
----------------------------------------------------
SELECT 
	e.Id,
	e.FirstName
FROM Employees AS e
WHERE Salary > 6500
ORDER BY e.FirstName, e.Salary
-------------------------------------------------
SELECT 
	CONCAT(e.FirstName,' ', e.LastName) AS [Full Name],
	e.Phone AS [Phone Number]
FROM Employees AS e
WHERE e.Phone LIKE '3%'
ORDER BY e.FirstName, e.Phone
----------------------------------------------
	SELECT
		e.FirstName,
		e.LastName,
		COUNT(o.EmployeeId) AS [Count]
	FROM Employees AS e
	JOIN Orders AS o ON e.Id = o.EmployeeId
	GROUP BY e.FirstName, e.LastName
	ORDER BY [Count] DESC, e.FirstName
	-------------------------------------------------
SELECT 
	e.FirstName,
	e.LastName,
	AVG(DATEDIFF(HOUR, sh.CheckIn, sh.CheckOut)) AS [Work hours]
FROM Employees AS e
JOIN Shifts AS sh ON e.Id = sh.EmployeeId
GROUP BY e.Id, FirstName, e.LastName
HAVING AVG(DATEDIFF(HOUR, sh.CheckIn, sh.CheckOut)) > 7
ORDER BY [Work hours] DESC, e.Id
-------------------------------------------------------
SELECT TOP(1)
	o.Id, 
	SUM(oi.Quantity * i.Price) AS TotalPrice
FROM Orders AS o
JOIN OrderItems AS oi ON oi.OrderId = o.Id
JOIN Items AS i ON i.Id = oi.ItemId
GROUP BY o.Id
ORDER BY TotalPrice DESC
--------------------------------------------------------
SELECT TOP(10)
	o.Id,
	MAX(i.Price) AS [ExpensivePrice],
	MIN(i.Price) AS [CheapPrice]
FROM Items AS i
JOIN OrderItems AS oi on oi.ItemId = i.Id
JOIN Orders AS o ON o.Id = oi.OrderId
GROUP BY o.Id
ORDER BY ExpensivePrice DESC, o.Id
-------------------------------------------------------
SELECT DISTINCT
	e.Id,
	e.FirstName,
	e.LastName
FROM Employees AS e
JOIN Orders AS o ON e.Id = o.EmployeeId
WHERE o.EmployeeId IS NOT NULL
ORDER BY e.Id
------------------------------------------------------
SELECT DISTINCT
	e.Id,
	CONCAT(e.FirstName,  ' ', e.LastName) AS [Full Name]
FROM Employees AS e
JOIN Shifts AS sh ON e.Id = sh.EmployeeId
WHERE DATEDIFF(HOUR, sh.CheckIn, sh.CheckOut) < 4
ORDER BY e.Id
-----------------------------------------------------
SELECT TOP (10)
	CONCAT(e.FirstName, ' ', e.LastName) AS [Full Name],
	SUM(i.Price * OI.Quantity) AS [Total Price],
	SUM(oi.Quantity) AS Items
FROM Employees AS e
JOIN Orders AS o ON o.EmployeeId = e.Id
JOIN OrderItems AS oi ON oi.OrderId = o.Id
JOIN Items AS i ON oi.ItemId = i.Id
WHERE o.DateTime < '2018-06-15'
GROUP BY CONCAT(e.FirstName, ' ', e.LastName)
ORDER BY [Total Price] desc, Items
---------------------------------------------------
SELECT 
	DATEPART(DAY, o.DateTime) AS [Day],
	CAST(AVG(oi.Quantity * i.Price) AS DECIMAL(15, 2)) AS [Total profit]
FROM Orders AS o
JOIN OrderItems AS oi ON oi.OrderId = o.Id
JOIN Items AS i ON i.Id = oi.ItemId
GROUP BY DATEPART(DAY, o.DateTime)
ORDER BY DAY ASC
--------------------------------------------------
SELECT 
	i.Name,
	cat.Name,
	SUM(oi.Quantity) AS [Count],
	SUM(oi.Quantity * i.Price) AS [TotalPrice]
FROM Orders AS o
JOIN OrderItems AS oi ON oi.OrderId = o.Id
RIGHT JOIN Items AS i ON oi.ItemId = i.Id
JOIN Categories AS cat ON i.CategoryId = cat.Id
GROUP BY i.Name, cat.Name
ORDER BY TotalPrice DESC, [Count] DESC
----------------------------------------------------
CREATE FUNCTION udf_GetPromotedProducts(@CurrentDate DATETIME, @StartDate DATETIME, @EndDate DATETIME, @Discount INT, @FirstItemId INT, @SecondItemId INT, @ThirdItemId INT)
RETURNS NVARCHAR(MAX)
AS 
BEGIN 
		DECLARE @FirstItemPrice DECIMAL(15,2) = (SELECT Price FROM Items WHERE Id = @FirstItemId)
		DECLARE @SecondItemPrice DECIMAL(15, 2) = (SELECT Price FROM Items WHERE Id = @SecondItemId)
		DECLARE @ThridItemPrice DECIMAL(15, 2) = (SELECT Price FROM Items WHERE Id = @ThirdItemId)

		IF(@FirstItemPrice IS NULL OR @SecondItemPrice IS NULL OR @ThridItemPrice IS NULL)
			BEGIN
				RETURN 'One of the items does not exists!';
			END

		IF (@CurrentDate <= @StartDate OR @CurrentDate >= @EndDate)
			BEGIN
				RETURN 'The current date is not within the promotion dates!';
			END

		DECLARE @NewFirstItemPrie DECIMAL(15, 2) = @FirstItemPrice - (@FirstItemPrice * @Discount / 100)
		DECLARE @NewSecondItemPrie DECIMAL(15, 2) = @SecondItemPrice - (@SecondItemPrice * @Discount / 100)
		DECLARE @NewThirdItemPrie DECIMAL(15, 2) = @ThridItemPrice - (@ThridItemPrice * @Discount / 100)

		DECLARE @FirstItemName NVARCHAR(50) = (SELECT [Name] FROM Items WHERE Id = @FirstItemId)
		DECLARE @SecondItemName NVARCHAR(50) = (SELECT [Name] FROM Items WHERE Id = @SecondItemId)
		DECLARE @ThirdItemName NVARCHAR(50) = (SELECT [Name] FROM Items WHERE Id = @ThirdItemId)

		RETURN	@FirstItemName +  ' price: ' + CAST(ROUND(@NewFirstItemPrie, 2) AS VARCHAR) + ' <-> ' +
				@SecondItemName +  ' price: ' + CAST(ROUND(@NewSecondItemPrie, 2) AS VARCHAR) + ' <-> ' +
				@ThirdItemName +  ' price: ' + CAST(ROUND(@NewThirdItemPrie, 2) AS VARCHAR)
END

