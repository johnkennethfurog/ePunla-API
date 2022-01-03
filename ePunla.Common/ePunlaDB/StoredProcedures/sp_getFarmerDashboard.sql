CREATE PROCEDURE [dbo].[sp_getFarmerDashboard]
AS
BEGIN 
  SELECT C.Name, FC.CropId, COUNT(FC.CropId) as Count, SUM(FC.AreaSize) as AreaSize, FC.[Status] as Status FROM FarmCrops FC
  LEFT JOIN Crops C ON C.CropId = FC.CropId
  GROUP BY FC.CropId, C.Name, FC.[Status]
  ORDER BY FC.[Status] DESC
END