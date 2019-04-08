CREATE DATABASE Minions

USE Minions

CREATE TABLE Towns(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Minions(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL,
	[Age] INT NOT NULL
)

ALTER TABLE Minions
ADD [TownId] INT

ALTER TABLE Minions 
ADD CONSTRAINT FK_Minions
FOREIGN KEY (TownId) REFERENCES Towns(Id)

INSERT INTO Towns VALUES(1, 'Sofia');
INSERT INTO Towns VALUES(2, 'Plovdiv');
INSERT INTO Towns VALUES(3, 'Varna');
INSERT INTO Minions VALUES(1, 'Kevin', 22, 1);
INSERT INTO Minions VALUES(2, 'Bob', 15, 3);
INSERT INTO Minions VALUES(3, 'Steward', NULL, 2);

TRUNCATE TABLE Minions

USE master

DROP TABLE Minions, Towns

CREATE TABLE People(

	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(200) NOT NULL,
	[Picture] VARBINARY(MAX) CHECK(LEN(Picture) > 2),
	[Height] FLOAT(2),
	[Weight] FLOAT(2),
	[Gender] CHAR CHECK(Gender = 'm' OR Gender = 'f') NOT NULL,
	[Birthdate] DATETIME NOT NULL,
	[Biography] VARCHAR(MAX)

)

INSERT INTO People(Name, Picture, Height, Weight, Gender, Birthdate, Biography) VALUES
('Niki', NULL, 175, 75, 'm', '2000-01-07', NULL),
('Nikii', NULL, 175, 75, 'm', '2000-01-07', NULL),
('Nikiii', NULL, 175, 75, 'm', '2000-01-07', NULL),
('Nikiiii', NULL, 175, 75, 'm', '2000-01-07', NULL),
('Nikiiiii', NULL, 175, 75, 'm', '2000-01-07', NULL)

CREATE TABLE Users(
	[Id] BIGINT PRIMARY KEY IDENTITY,
	[Username] VARCHAR(30) NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	[ProfilePicture] VARBINARY(MAX) CHECK(LEN(ProfilePicture) > 0.9),
	[LastLoginTime] DATETIME,
	[IsDeleted] BIT NOT NULL,
)

INSERT INTO Users(Username, Password, ProfilePicture, LastLoginTime, IsDeleted) VALUES
('Niki', '123', NULL, NULL, 0),
('Nikii', '123', NULL, NULL, 0),
('Nikiii', '123', NULL, NULL, 0),
('Nikiiii', '123', NULL, NULL, 0),
('Nikiiiii', '123', NULL, NULL, 0)

ALTER TABLE Users
DROP CONSTRAINT [PK__Users__3214EC070F5DD236]

ALTER TABLE Users
ADD CONSTRAINT PK_UsersPrimaryKey PRIMARY KEY(Id, Username)

ALTER TABLE Users
ADD CONSTRAINT CH_PasswordLength CHECK(LEN([Password]) > 5)

ALTER TABLE Users
ADD CONSTRAINT DF_LastLoginTime
DEFAULT(GETDATE()) FOR LastLoginTime

ALTER TABLE Users
DROP CONSTRAINT [PK_UsersPrimaryKey]

ALTER TABLE Users
ADD CONSTRAINT PK_Id 
PRIMARY KEY(Id)

ALTER TABLE Users 
ADD CONSTRAINT UQ_Username
UNIQUE (Username),
CHECK(LEN(Username) > 3) 

GO

CREATE DATABASE Movies

USE Movies

CREATE TABLE Directors(
	[Id] INT PRIMARY KEY IDENTITY,
	[DirectorName] NVARCHAR(50) NOT NULL,
	[Notes] NVARCHAR(MAX)
)

CREATE TABLE Genres(
	[Id] INT PRIMARY KEY IDENTITY,
	[GenreName] NVARCHAR(30) NOT NULL,
	[Notes] NVARCHAR(MAX)
)

CREATE TABLE Categories(
	[Id] INT PRIMARY KEY IDENTITY,
	[CategoryName] NVARCHAR(30) NOT NULL,
	[Notes] NVARCHAR(MAX)
)

CREATE TABLE Movies(
	[Id] INT PRIMARY KEY IDENTITY,
	[Title] NVARCHAR(30) NOT NULL,
	[DirectorId] INT FOREIGN KEY REFERENCES Directors(Id),
	[CopyrightYear] INT NOT NULL,
	[Length] FLOAT(2) NOT NULL,
	[GenreId] INT FOREIGN KEY REFERENCES Genres(Id),
	[CategoryId] INT FOREIGN KEY REFERENCES Categories(Id),
	[Rating] INT,
	[Notes] NVARCHAR(MAX)
)

INSERT INTO Directors(DirectorName, Notes) VALUES
('Niki', NULL),
('Nikii', NULL),
('Nikiii', NULL),
('Nikiiii', NULL),
('Nikiiiii', NULL)

INSERT INTO Genres(GenreName, Notes) VALUES
('Ujas', NULL),
('Ujass', NULL),
('Ujasss', NULL),
('Ujassss', NULL),
('Ujasssss', NULL)

INSERT INTO Categories(CategoryName, Notes) VALUES
('Hubava', NULL),
('Hubavaa', NULL),
('Hubavaaa', NULL),
('Hubavaaaa', NULL),
('Hubavaaaaa', NULL)

INSERT INTO Movies(Title, DirectorId, CopyrightYear, Length, GenreId, CategoryId, Rating, Notes) VALUES 
('asd', 3, 2001, 13.31, 5, 2, 1, NULL),
('asdd', 3, 2001, 13.31, 5, 2, 1, NULL),
('asddd', 3, 2001, 13.31, 5, 2, 1, NULL),
('asdddd', 3, 2001, 13.31, 5, 2, 1, NULL),
('asddddd', 3, 2001, 13.31, 5, 2, 1, NULL)

CREATE DATABASE CarRental
 
 USE CarRental

CREATE TABLE Categories(
	[Id] INT PRIMARY KEY IDENTITY,
	[CategoryName] NVARCHAR(30) NOT NULL,
	[DailyRate] INT,
	[WeeklyRate] INT,
	[MonthlyRate] INT,
	[WeekendRate] INT
)

CREATE TABLE Cars(
	[Id] INT PRIMARY KEY IDENTITY,
	[PlateNumber] VARCHAR(4) NOT NULL,
	[Manufacturer] NVARCHAR(30) NOT NULL,
	[Model] NVARCHAR(50) NOT NULL,
	[CarYear] INT NOT NULL,
	[CategoryId] INT FOREIGN KEY REFERENCES Categories(Id),
	[Doors] INT NOT NULL,
	[Picture] VARBINARY(MAX),
	[Condition] VARCHAR(30) NOT NULL,
	[Available] BIT NOT NULL
)

CREATE TABLE Employees(
	[Id] INT PRIMARY KEY IDENTITY,
	[FirstName] VARCHAR(30) NOT NULL,
	[LastName] VARCHAR(30) NOT NULL,
	[Title] VARCHAR(50) NOT NULL,
	[Notes] VARCHAR(MAX)
)

CREATE TABLE Customers(
	[Id] INT PRIMARY KEY IDENTITY,
	[DriverLicenceNumber] INT NOT NULL,
	[FullName] NVARCHAR(60) NOT NULL,
	[Address] NVARCHAR(MAX),
	[City] NVARCHAR(30) NOT NULL,
	[ZIPCode] NVARCHAR(MAX),
	[Notes] NVARCHAR(MAX)
)

CREATE TABLE RentalOrders(
	[Id] INT PRIMARY KEY IDENTITY,
	[EmployeeId] INT FOREIGN KEY REFERENCES Employees(Id),
	[CustomerId] INT FOREIGN KEY REFERENCES Customers(Id),
	[CarId] INT FOREIGN KEY REFERENCES Cars(Id),
	[TankLevel] INT,
	[KilometrageStart] BIGINT,
	[KilometrageEnd] BIGINT,
	[TotalKilometrage] BIGINT,
	[StartDate] DATE NOT NULL,
	[EndDate] DATE NOT NULL,
	[TotalDays] BIGINT,
	[RateApplied] INT,
	[TaxRate] FLOAT(2),
	[OrderStatus] VARCHAR(10),
	[Notes] NVARCHAR(MAX)
)

INSERT INTO Categories([CategoryName], DailyRate, WeeklyRate, MonthlyRate, WeekendRate) VALUES
('Niki', NULL, NULL, NULL, NULL),
('Nikii', NULL, NULL, NULL, NULL),
('Nikiii', NULL, NULL, NULL, NULL)

INSERT INTO Cars(PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Picture, Condition, Available) VALUES
('132', 'audi', 'a4', 2014, 1, 4, NULL, 'good', 1),
('132', 'audi', 'a4', 2014, 1, 4, NULL, 'good', 1),
('1323', 'audi', 'a4', 2014, 1, 4, NULL, 'good', 1)

INSERT INTO Employees(FirstName, LastName,Title, Notes) VALUES
('Niki', 'Nanov', 'velikiq', NULL),
('Niki', 'Nanov', 'velikiqqq', NULL),
('Niki', 'Nanov', 'velikiqq', NULL)

INSERT INTO Customers(DriverLicenceNumber, FullName, Address, City, ZIPCode, Notes) VALUES
('1', 'asd', NULL, 'asd', NULL, NULL),
('12', 'asd', NULL, 'asd', NULL, NULL),
('123', 'asd', NULL, 'asd', NULL, NULL)

INSERT INTO RentalOrders(EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, TotalKilometrage, StartDate, EndDate, TotalDays, RateApplied, TaxRate, OrderStatus, Notes) VALUES
(1, 2, 3, NULL, NULL, NULL, NULL, '2000-03-01', '2006-03-01', NULL, NULL, NULL, NULL, NULL),
(1, 2, 3, NULL, NULL, NULL, NULL, '2000-03-02', '2006-03-01', NULL, NULL, NULL, NULL, NULL),
(1, 2, 3, NULL, NULL, NULL, NULL, '2000-03-03', '2006-03-01', NULL, NULL, NULL, NULL, NULL)

CREATE DATABASE Hotel

USE Hotel

CREATE TABLE Employees(
	[Id] INT PRIMARY KEY IDENTITY,
	[FirstName] NVARCHAR(30) NOT NULL,
	[LastName] NVARCHAR(30) NOT NULL,
	[Title] NVARCHAR(30) NOT NULL,
	[Notes] NVARCHAR(MAX)
) 

CREATE TABLE Customers(
	[AccountNumber] INT PRIMARY KEY NOT NULL,
	[FirstName] NVARCHAR(30) NOT NULL,
	[LastName] NVARCHAR(30) NOT NULL,
	[PhoneNumber] NVARCHAR(10),
	[EmergencyName]	NVARCHAR(30),
	[EmergencyNumber] NVARCHAR(10),
	[Notes] NVARCHAR(MAX)
)

CREATE TABLE RoomStatus(
	[RoomStatus] NVARCHAR(30) PRIMARY KEY NOT NULL,
	[Notes] NVARCHAR(MAX)
) 

CREATE TABLE RoomTypes(
	[RoomType] VARCHAR(50) PRIMARY KEY NOT NULL,
	[Notes] NVARCHAR(MAX)
) 

CREATE TABLE BedTypes(
	[BedType] NVARCHAR(30) PRIMARY KEY NOT NULL,
	[Notes] NVARCHAR(MAX)	
)

CREATE TABLE Rooms(
	[RoomNumber] INT PRIMARY KEY NOT NULL,
	[RoomType] VARCHAR(50) FOREIGN KEY REFERENCES RoomTypes (RoomType),
	[BedType] NVARCHAR(30) FOREIGN KEY REFERENCES BedTypes (BedType),
	[Rate] INT,
	[RoomStatus] NVARCHAR(30) FOREIGN KEY REFERENCES RoomStatus([RoomStatus]),
	[Notes] NVARCHAR(MAX),
)

CREATE TABLE Payments(
	[Id] INT PRIMARY KEY IDENTITY,
	[EmoloyeeId] INT FOREIGN KEY REFERENCES Employees(Id),
	[PaymentDate] DATE,
	[AccountNumber] INT	FOREIGN KEY REFERENCES Customers(AccountNumber),
	[FirstDateOccupied] DATE,
	[LastDateOccupied] DATE,
	[TotalDays] INT NOT NULL,
	[AmountCharged] DECIMAL(15,2) NOT NULL,
	[TaxRate] FLOAT(2),
	[TaxAmount] FLOAT(2),
	[PaymentTotal] DECIMAL(15,2) NOT NULL,
	[Notes] NVARCHAR(MAX) NOT NULL
)

CREATE TABLE Occupancies(
	[Id] INT PRIMARY KEY IDENTITY,
	[EmployeeId] INT FOREIGN KEY REFERENCES Employees(Id),
	[DateOccupied] DATE,
	[AccountNumber] INT	FOREIGN KEY REFERENCES Customers(AccountNumber),
	[RoomNumber] INT FOREIGN KEY REFERENCES Rooms([RoomNumber]),
	[RateApplied] INT,
	[PhoneCharge] DECIMAL(15,2),
	[Notes] NVARCHAR(MAX)
)

INSERT INTO Employees(FirstName, LastName, Title, Notes) VALUES
('Niki', 'Nanov', 'asd', NULL),
('Nikii', 'Nanov', 'asd', NULL),
('Nikiii', 'Nanov', 'asd', NULL)

INSERT INTO Customers(AccountNumber, FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber, Notes) VALUES
(12, 'Niki', 'Nikov', '08831', NULL, NULL, NULL),
(13, 'Niki', 'Nikov', '08831', NULL, NULL, NULL),
(14, 'Niki', 'Nikov', '08831', NULL, NULL, NULL)

INSERT INTO RoomStatus(RoomStatus, Notes) VALUES
('staq', NULL),
('staQq', NULL),
('staqqq', NULL)

INSERT INTO RoomTypes(RoomType, Notes) VALUES
('asd', NULL),
('asdD', NULL),
('asdddd', NULL)

INSERT INTO BedTypes(BedType, Notes) VALUES
('asd', NULL),
('DDD', NULL),
('asdd', NULL)

INSERT INTO Rooms(RoomNumber, RoomType, BedType, Rate, RoomStatus, Notes) VALUES
(3, 'asdddd', 'DDD', 4, 'staqqq', NULL),
(1, 'asd', 'asd', 3, 'staq', NULL),
(2, 'asdD', 'DDD', 2, 'staQq', NULL)

INSERT INTO Payments(EmoloyeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, TotalDays, AmountCharged, TaxRate, TaxAmount, PaymentTotal, Notes)
VALUES
(1, '2000-03-05', 12, '2000-03-06', '2000-03-07', 30, 31.13, 3.12, 4.12, 4.33, 'asd'),
(2, '2000-03-05',13, '2000-03-06', '2000-03-07', 30, 31.13, 3.12, 4.12, 4.33, 'asd'),
(3, '2000-03-05',14, '2000-03-06', '2000-03-07', 30, 31.13, 3.12, 4.12, 4.33, 'asd')

INSERT INTO Occupancies(EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge, Notes) VALUES
(1, '2000-03-05', 12, 3, NULL, NULL, NULL),
(2, '2000-03-05', 13, 2, NULL, NULL, NULL),
(3, '2000-03-05', 14, 1, NULL, NULL, NULL)

CREATE DATABASE SoftUni

USE SoftUni

CREATE TABLE Towns(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Addresses(
	[Id] INT PRIMARY KEY IDENTITY,
	[AddressText] NVARCHAR(MAX) NOT NULL,
	[TownId] INT FOREIGN KEY REFERENCES Towns(Id)
)

CREATE TABLE Departments(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) NOT NULL,
)

CREATE TABLE Employees(
	[Id] INT PRIMARY KEY IDENTITY,
	[FirstName] VARCHAR(30) NOT NULL,
	[MiddleName] VARCHAR(30),
	[LastName] VARCHAR(30) NOT NULL,
	[JobTitle] VARCHAR(50),
	[DepartmentId] INT FOREIGN KEY REFERENCES Departments(Id),
	[HireDate] DATE,
	[Salary] DECIMAL(15,2) NOT NULL,
	[AddressId] INT FOREIGN KEY REFERENCES Addresses(Id)
)

// Copyright © Microsoft Corporation.  All Rights Reserved.
// This code released under the terms of the 
// Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.)
USE [master]  
GO  
/****** Object:  StoredProcedure [dbo].[sp_BackupDatabases] ******/  
SET ANSI_NULLS ON  
GO  
SET QUOTED_IDENTIFIER ON  
GO  
 
-- =============================================  
-- Author: Microsoft  
-- Create date: 2010-02-06
-- Description: Backup Databases for SQLExpress 
-- Parameter1: databaseName  
-- Parameter2: backupType F=full, D=differential, L=log
-- Parameter3: backup file location
-- ============================================= 
 
CREATE PROCEDURE [dbo].[sp_BackupDatabases]   
            @databaseName sysname = null, 
            @backupType CHAR(1), 
            @backupLocation nvarchar(200)  
AS  
 
       SET NOCOUNT ON;  
            
            DECLARE @DBs TABLE
            (
                  ID int IDENTITY PRIMARY KEY,
                  DBNAME nvarchar(500)
            )
            
             -- Pick out only databases which are online in case ALL databases are chosen to be backed up
             -- If specific database is chosen to be backed up only pick that out from @DBs
            INSERT INTO @DBs (DBNAME) 
            SELECT Name FROM master.sys.databases 
            where state=0
            AND name=@DatabaseName 
            OR @DatabaseName IS NULL 
            ORDER BY Name
            
            -- Filter out databases which do not need to backed up
            IF @backupType='F'
                  BEGIN
                  DELETE @DBs where DBNAME IN ('tempdb','Northwind','pubs','AdventureWorks')
                  END
            ELSE IF @backupType='D'
                  BEGIN
                  DELETE @DBs where DBNAME IN ('tempdb','Northwind','pubs','master','AdventureWorks')
                  END
            ELSE IF @backupType='L'
                  BEGIN
                  DELETE @DBs where DBNAME IN ('tempdb','Northwind','pubs','master','AdventureWorks')
                  END
            ELSE
                  BEGIN
                  RETURN
                  END
            
            -- Declare variables
            DECLARE @BackupName varchar(100)
            DECLARE @BackupFile varchar(100)
            DECLARE @DBNAME varchar(300)
            DECLARE @sqlCommand NVARCHAR(1000)  
        DECLARE @dateTime NVARCHAR(20)
            DECLARE @Loop int                   
                        
            -- Loop through the databases one by one
            SELECT @Loop = min(ID) FROM @DBs
 
      WHILE @Loop IS NOT NULL
      BEGIN
 
-- Database Names have to be in [dbname] format since some have - or _ in their name
      SET @DBNAME = '['+(SELECT DBNAME FROM @DBs WHERE ID = @Loop)+']'
 
-- Set the current date and time n yyyyhhmmss format
      SET @dateTime = REPLACE(CONVERT(VARCHAR, GETDATE(),101),'/','') + '_' +  REPLACE(CONVERT(VARCHAR, GETDATE(),108),':','')   
 
-- Create backup filename in path\filename.extension format for full,diff and log backups
      IF @backupType = 'F' 
            SET @BackupFile = @backupLocation+REPLACE(REPLACE(@DBNAME, '[',''),']','')+ '_FULL_'+ @dateTime+ '.BAK'
      ELSE IF @backupType = 'D' 
            SET @BackupFile = @backupLocation+REPLACE(REPLACE(@DBNAME, '[',''),']','')+ '_DIFF_'+ @dateTime+ '.BAK'
      ELSE IF @backupType = 'L'
            SET @BackupFile = @backupLocation+REPLACE(REPLACE(@DBNAME, '[',''),']','')+ '_LOG_'+ @dateTime+ '.TRN'
 
-- Provide the backup a name for storing in the media
      IF @backupType = 'F'
            SET @BackupName = REPLACE(REPLACE(@DBNAME,'[',''),']','') +' full backup for '+ @dateTime
      IF @backupType = 'D'
            SET @BackupName = REPLACE(REPLACE(@DBNAME,'[',''),']','') +' differential backup for '+ @dateTime
      IF @backupType = 'L'
            SET @BackupName = REPLACE(REPLACE(@DBNAME,'[',''),']','') +' log backup for '+ @dateTime
 
-- Generate the dynamic SQL command to be executed
 
       IF @backupType = 'F'  
                  BEGIN
               SET @sqlCommand = 'BACKUP DATABASE ' +@DBNAME+  ' TO DISK = '''+@BackupFile+ ''' WITH INIT, NAME= ''' +@BackupName+''', NOSKIP, NOFORMAT'
                  END
       IF @backupType = 'D' 
                  BEGIN 
               SET @sqlCommand = 'BACKUP DATABASE ' +@DBNAME+  ' TO DISK = '''+@BackupFile+ ''' WITH DIFFERENTIAL, INIT, NAME= ''' +@BackupName+''', NOSKIP, NOFORMAT'         
                  END
       IF @backupType = 'L'  
                  BEGIN
               SET @sqlCommand = 'BACKUP LOG ' +@DBNAME+  ' TO DISK = '''+@BackupFile+ ''' WITH INIT, NAME= ''' +@BackupName+''', NOSKIP, NOFORMAT'         
                  END
 
-- Execute the generated SQL command
       EXEC(@sqlCommand)
 
-- Goto the next database
SELECT @Loop = min(ID) FROM @DBs where ID>@Loop
 
END

INSERT INTO Towns(Name) VALUES
('Sofia'),
('Plovdiv'),
('Varna'),
('Burgas')

INSERT INTO Departments(Name) VALUES
('Engineering'),
('Sales'),
('Marketing'),
('Software Development'),
('Quality Assurance')

INSERT INTO Addresses(AddressText, TownId) VALUES
('asd', 1),
('tuk', 2),
('tam', 3),
('ei tam', 4)
 
INSERT INTO Employees(FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary, AddressId) VALUES
('Ivan', 'Ivanov', 'Ivanov', 'Senior Engineer', 4, '2013-02-01', 3500.00, 1),
('Petar', 'Petrov', 'Petrov', '.NET Developer', 1, '2004-03-02', 4000.00, 2),
('Maria', 'Petrova', 'Ivanova', 'Intern', 5, '2016-08-28', 525.25, 3),
('Georgi', 'Teziev', 'Ivanov', 'CEO', 2, '2007-12-09', 3000.00, 4),
('Peter', 'Pan', 'Pan', 'Intern', 3, '2016-08-28', 599.88, 3)

SELECT * FROM Towns
SELECT * FROM Departments
SELECT * FROM Employees 

SELECT * FROM Towns ORDER BY [Name] ASC
SELECT * FROM Departments ORDER BY [Name] ASC
SELECT * FROM Employees ORDER BY [Salary] DESC

SELECT [Name] FROM Towns
ORDER BY [Name] ASC

SELECT [Name] FROM Departments
ORDER BY [Name] ASC

SELECT FirstName, LastName, JobTitle, Salary
FROM Employees
ORDER BY [Salary] DESC

UPDATE Employees
SET [Salary] = [Salary] * 1.10

SELECT Salary
FROM Employees



UPDATE Payments
SET [TaxRate] = [TaxRate] - ([TaxRate] * 0.03)

SELECT [TaxRate] FROM Payments

TRUNCATE TABLE Occupancies