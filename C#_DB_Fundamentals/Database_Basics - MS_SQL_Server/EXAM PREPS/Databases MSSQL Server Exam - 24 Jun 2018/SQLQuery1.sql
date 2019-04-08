SELECT 
	TripsRank.AccountId,	
	TripsRank.Email,
	TripsRank.CountryCode,
	TripsRank.Trips
FROM 
(
SELECT
	a.Id AS AccountId,
	a.Email AS Email,
	c.CountryCode,
	COUNT(*) AS Trips,
	DENSE_RANK() OVER(PARTITION BY c.CountryCode ORDER BY COUNT(*) DESC, a.ID ) AS Rank
FROM Accounts AS a
JOIN AccountsTrips AS at ON a.Id = at.AccountId
JOIN Trips AS t ON at.TripId = t.Id
JOIN Rooms AS r ON t.RoomId = r.Id
JOIN Hotels AS h ON h.Id = r.HotelId
JOIN Cities AS c ON h.CityId = c.Id
GROUP BY a.Id, a.Email, c.CountryCode
) AS TripsRank
WHERE TripsRank.Rank = 1
ORDER BY TripsRank.Trips DESC, TripsRank.AccountId