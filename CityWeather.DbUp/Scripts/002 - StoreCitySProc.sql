CREATE OR ALTER PROCEDURE dbo.StoreCity
	@name nvarchar(50),
	@state nvarchar(50),
	@countryName nvarchar(50),
	@rating int,
	@established datetime,
	@estimatedPopulation int	
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO Cities (Name, State, CountryName, Rating, Established, EstimatedPopulation) Values(@name, @state, @countryName, @rating, @established, @estimatedPopulation);
END
GO	