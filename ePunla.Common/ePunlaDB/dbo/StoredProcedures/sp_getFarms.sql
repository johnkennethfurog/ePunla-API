CREATE PROCEDURE [dbo].[sp_getFarms]
  @farmerId int = 0,
  @status NVARCHAR(50) NULL
AS
  SELECT * FROM Farms where FarmerId = @farmerId and (@status IS NULL OR [status]=@status)