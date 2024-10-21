CREATE TABLE Country (
    CountryId INT PRIMARY KEY,
    CountryName NVARCHAR(100) NOT NULL
);


INSERT INTO dbo.Country
(
    CountryId,
    CountryName
)
VALUES
(   1,  -- CountryId - int
    N'Nepal' -- CountryName - nvarchar(100)
    ),(2,'Sweden'),(3,'UK'),(4,'USA')

CREATE TABLE Cities (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(100) NOT NULL,
    CountryId INT NOT NULL 
	);


INSERT INTO dbo.Cities
(
    Name,    CountryId
)
VALUES
(   'Bhaktapur',     1   ),('Kathmandu',1),('Patan',1),('Pokhara',1)
