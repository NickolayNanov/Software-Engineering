CREATE DATABASE Supermarket

CREATE TABLE Categories(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL
)

CREATE TABLE Items(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL,
	[Price] DECIMAL(15, 2) NOT NULL,
	[CategoryId] INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL
)

CREATE TABLE Employees(
	[Id] INT PRIMARY KEY IDENTITY,
	[FirstName] NVARCHAR(50) NOT NULL,
	[LastName] NVARCHAR(50) NOT NULL,
	[Phone] CHAR(12) NOT NULL,
	[Salary] DECIMAL(15, 2) NOT NULL
)

CREATE TABLE Orders(
	[Id] INT PRIMARY KEY IDENTITY,
	[DateTime] DATETIME NOT NULL,
	[EmployeeId] INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL
)

CREATE TABLE OrderItems(
	[OrderId] INT FOREIGN KEY REFERENCES Orders(Id),
	[ItemId] INT FOREIGN KEY REFERENCES Items(Id),
	[Quantity] INT NOT NULL CHECK(Quantity >= 1)

	CONSTRAINT PK_OrdertItemId PRIMARY KEY(OrderId, ItemId)
)

CREATE TABLE Shifts(
	[Id] INT IDENTITY NOT NULL,
	[EmployeeId] INT FOREIGN KEY REFERENCES Employees(Id),
	[CheckIn] DATETIME NOT NULL,
	[CheckOut] DATETIME NOT NULL
	
	CONSTRAINT PK_EmployeeId PRIMARY KEY (Id, EmployeeId)
)

ALTER TABLE Shifts
ADD CONSTRAINT CH_CheckOut CHECK(CheckIn < CheckOut)

---------------------------------------------------------------------------

INSERT INTO Employees(FirstName, LastName, Phone, Salary) VALUES
('Stoyan', 'Petrov', '888-785-8573', 500.25),
('Stamat', 'Nikolov', '789-613-1122', 999995.25),
('Evgeni', 'Petkov', '645-369-9517', 1234.51),
('Krasimir', 'Vidolov', '321-471-9982', 50.25)

INSERT INTO Items ([Name], Price, CategoryId) VALUES 
('Tesla battery', 154.25, 8),
('Chess', 30.25, 8),
('Juice', 5.32, 1),
('Glasses', 10, 8),
('Bottle of water', 1, 1)

----------------------------------------------------------------------------------

UPDATE Items
SET Price += Price * 0.27
WHERE CategoryId IN (1, 2 , 3)

----------------------------------------------------------------------------------

DELETE FROM OrderItems
WHERE OrderId = 48

----------------------------------------------------------------------------------

SELECT 
	[Id],
	[FirstName]
FROM Employees
WHERE [Salary] > 6500
ORDER BY
[FirstName],
[Id]

-----------------------------------------------------------------------------------

SELECT 
	FirstName + ' ' + LastName AS [Full Name],
	Phone
FROM Employees
WHERE Phone LIKE '3%'
ORDER BY FirstName, Phone
 
---------------------------------------------------------------------------------
SELECT
  FirstName,
  LastName,
  COUNT(o.Id) AS [Count]
FROM Employees AS e
  JOIN Orders AS o ON o.EmployeeId = e.Id
GROUP BY FirstName, LastName
ORDER BY [Count] DESC, FirstName


-------------------------------------------------------------------------------

SELECT 
	e.FirstName,
	e.LastName,
	COUNT(o.Id) AS [Count]
FROM Employees AS e
	JOIN Orders AS o ON o.EmployeeId = e.Id
GROUP BY e.FirstName, e.LastName
ORDER BY [Count] DESC, FirstName

----------------------------------------------------------
 
SELECT
	e.FirstName, 
	e.LastName,
	AVG(DATEDIFF(HOUR, sh.CheckIn, sh.CheckOut)) AS [Work hours]
FROM Employees AS e
JOIN Shifts as sh ON sh.EmployeeId = e.Id
GROUP BY e.FirstName, e.LastName, e.Id
HAVING AVG(DATEDIFF(HOUR, sh.CheckIn, sh.CheckOut)) > 7
ORDER BY [Work hours] DESC, e.Id

-----------------------------------------------------------------

SELECT TOP(1)
	o.Id,
	SUM(I.Price * oi.Quantity) AS [TotalPrice]
FROM Orders AS o
JOIN OrderItems AS oi ON oi.OrderId = o.Id
JOIN Items AS i ON i.Id = oi.ItemId
GROUP BY o.Id
ORDER BY [TotalPrice] DESC

------------------------------------------------------------------

