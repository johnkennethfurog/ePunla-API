CREATE PROCEDURE [dbo].[sp_getFarmerClaims]
  @farmerId INT,
  @status NVARCHAR (20)
AS
BEGIN
  SELECT 
      [ClaimId],
      [FilingDate],
      [Crop] = CR.[Name],
      CL.[FarmCropId],
      CL.FarmId,
      [Farm] = FA.Name,
      CL.DamagedArea,
      CL.[Status],
      CL.[Description],
      CL.PhotoUrl,
      CL.PhotoId
  FROM Claims CL
    LEFT JOIN FarmCrops FC on FC.FarmCropId = CL.FarmCropId
    LEFT JOIN Crops CR ON CR.CropId = FC.CropId
    LEFT JOIN Farms FA on FA.FarmId = CL.FarmId
  WHERE FA.FarmerId = @farmerId AND (@status IS NULL OR CL.[Status] = @status)
END
