USE Geography

SELECT PeakName FROM Peaks
ORDER BY PeakName ASC

SELECT * FROM Countries

SELECT TOP(30) CountryName, [Population] FROM Countries
WHERE ContinentCode = 'EU'
ORDER BY
[Population] DESC,
CountryName ASC

SELECT * FROM Countries

USE Diablo

SELECT Name FROM Characters
ORDER BY Name ASC


