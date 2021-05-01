CREATE PROCEDURE [dbo].[sp_saveClaim]
  @ClaimId INT,
  @FarmCropId INT,
  @Description NVARCHAR (200),
  @PhotoUrl NVARCHAR (100),
  @PhotoId  NVARCHAR(100),
  @DamagedArea NVARCHAR (20),
  @ClaimCauses AS ClaimCause READONLY,
  @Validation INT OUTPUT
AS
BEGIN

  DECLARE @FarmId INT = (SELECT [FarmId] FROM FarmCrops WHERE FarmCropId = @FarmCropId)
  DECLARE @ExistingFarmCropId INT = (SELECT [FarmCropId] FROM Claims WHERE ClaimId = @claimId)

  IF @ClaimId IS NOT NULL AND NOT EXISTS (SELECT TOP 1 * FROM Claims WHERE ClaimId = @claimId)
    BEGIN 
      SET @Validation = 7001;
    END
  ELSE IF @ClaimId IS NOT NULL AND (SELECT [Status] FROM Claims WHERE ClaimId = @claimId) <> 'Pending'
    BEGIN
      SET @Validation = 7002;
    END
  ELSE IF EXISTS (SELECT DamageTypeId, COUNT(*) FROM @ClaimCauses GROUP BY DamageTypeId HAVING COUNT(*) > 1)
    BEGIN
        SET @Validation = 7003;
    END
  ELSE IF NOT EXISTS (SELECT TOP 1 * FROM FarmCrops WHERE FarmCropId = @FarmCropId) OR @FarmId IS NULL
    BEGIN
      SET @Validation = 4002;
    END
  ELSE IF (@ClaimId IS NULL OR @ExistingFarmCropId <> @FarmCropId) AND (SELECT [Status] FROM FarmCrops WHERE FarmCropId = @FarmCropId) <> 'Planted'
    BEGIN
      SET @Validation = 4001;
    END
  ELSE IF @ClaimId IS NULL

    /* INSERT CLAIM */
    BEGIN

      UPDATE FarmCrops SET [Status]='Damaged' WHERE FarmCropId = @FarmCropId

      INSERT INTO Claims ([FarmCropId],[FarmId],[FilingDate],[DamagedArea],[Description],[PhotoUrl], [PhotoId],[Status]) 
      VALUES (@FarmCropId, @FarmId, GETDATE(), @DamagedArea, @Description, @PhotoUrl, @PhotoId, 'Pending')

      SET @ClaimId = SCOPE_IDENTITY()

      INSERT INTO ClaimCauses ([DamageTypeId], [DamagedAreaSize], [ClaimId])
      SELECT DamageTypeId,DamagedAreaSize, @ClaimId FROM @ClaimCauses
      
    END
  ELSE
    /* UPDATE CLAIM */
    BEGIN
      UPDATE Claims
      SET
        [FarmCropId] = @FarmCropId,
        [FarmId] = @FarmId,
        [DamagedArea] = @DamagedArea,
        [Description] = @Description,
        [PhotoUrl] = @PhotoUrl,
        [PhotoId] = @PhotoId
      WHERE
        ClaimId = @ClaimId

      MERGE ClaimCauses as [TARGET]
      USING @ClaimCauses as [SOURCE]
        ON ([SOURCE].DamageTypeId = [TARGET].DamageTypeId AND @ClaimId = [TARGET].ClaimId)
          WHEN NOT MATCHED
              THEN INSERT([ClaimId],[DamageTypeId],[DamagedAreaSize]) 
              VALUES (@claimId,[SOURCE].[DamageTypeId],[SOURCE].[DamagedAreaSize])
          WHEN MATCHED AND [TARGET].DamagedAreaSize <> [SOURCE].DamagedAreaSize
              THEN UPDATE SET [TARGET].DamagedAreaSize = [SOURCE].DamagedAreaSize;
    END

    SELECT ISNULL(@ClaimId,0);
END