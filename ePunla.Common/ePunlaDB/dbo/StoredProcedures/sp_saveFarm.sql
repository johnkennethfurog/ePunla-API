CREATE PROCEDURE [dbo].[sp_saveFarm]
  @FarmId INT,
  @Name NVARCHAR (200),
  @AreaSize DECIMAL,
  @StreetAddress NVARCHAR (200),
  @BarangayId INT,
  @BarangayAreaId INT,
  @FarmerId INT,
  @Validation INT OUTPUT
AS
BEGIN
  IF @FarmId IS NOT NULL AND  NOT EXISTS ( SELECT TOP 1 * FROM Farms WHERE FarmId = @farmId AND FarmerId = @farmerId)
    BEGIN
      SET @Validation = 5001
    END
  IF @FarmId IS NOT NULL AND ( SELECT [Status] FROM Farms WHERE FarmId = @farmId AND FarmerId = @farmerId) <> 'Pending'
    BEGIN
      SET @Validation = 5002
    END
  ELSE IF NOT EXISTS ( SELECT TOP 1 * FROM Barangays WHERE BarangayId = @BarangayId)
    BEGIN
      SET @Validation = 1001
    END 
  ELSE IF NOT EXISTS ( SELECT TOP 1 * FROM BarangayAreas WHERE BarangayAreaId = @BarangayAreaId)
    BEGIN
      SET @Validation = 2001
    END
  ELSE IF @FarmId IS NULL
    BEGIN
      INSERT INTO Farms
        ([FarmerId],[Address],[BarangayId],[BarangayAreaId],[AreaSize],[Name],[Status])
      VALUES
        (@FarmerId, @StreetAddress, @BarangayId, @BarangayAreaId, @AreaSize, @Name, 'Pending')
    END
  ELSE
    BEGIN
      UPDATE Farms
      SET
        [Address] = @StreetAddress,
        [BarangayId] = @BarangayId,
        [BarangayAreaId] = @BarangayAreaId,
        [AreaSize] = @AreaSize,
        [Name] = @Name
      WHERE FarmId = @FarmId
    END

  
  SELECT ISNULL(ISNULL(SCOPE_IDENTITY(),0),@FarmId);
END
