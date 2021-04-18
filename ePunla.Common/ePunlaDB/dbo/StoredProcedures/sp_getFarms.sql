CREATE PROCEDURE [dbo].[sp_getFarms]
  @farmerId int = 0
AS
  SELECT * FROM Farms where FarmerId = @farmerId and [Status]='Pending'