CREATE OR ALTER PROCEDURE dbo.UpdateCity
	@id int,
	@rating int,
	@established datetime,
	@estimatedPopulation int	
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE Cities SET Rating = @rating, Established = @established, EstimatedPopulation = @estimatedPopulation WHERE Id = @id
END
GO	