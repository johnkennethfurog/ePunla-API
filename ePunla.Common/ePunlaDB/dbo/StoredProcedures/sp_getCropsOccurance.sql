CREATE PROCEDURE [dbo].[sp_getCropsOccurance]
  @PlantedFrom DATETIME,
  @PlantedTo DATETIME
AS
BEGIN
  SELECT C.Name as 'Crop',FC.PlantedDate, FC.AreaSize, F.Name as 'Farm', FR.FirstName + ' ' + FR.LastName AS 'Farmer' FROM FarmCrops FC
  LEFT JOIN Crops C ON C.CropId = FC.CropId
  LEFT JOIN Farms F ON F.FarmId = FC.FarmId
  LEFT JOIN Farmers FR ON FR.FarmerId = F.FarmerId
  WHERE @PlantedFrom IS NULL OR @PlantedTo IS NULL OR FC.PlantedDate BETWEEN @PlantedFrom AND @PlantedTo
END
