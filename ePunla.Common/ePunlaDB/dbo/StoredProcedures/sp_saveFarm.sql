CREATE PROCEDURE [dbo].[sp_saveFarm]
  @FarmId INT,
  @Name NVARCHAR (200),
  @AreaSize DECIMAL,
  @StreetAddress NVARCHAR (200),
  @BarangayId INT,
  @BarangayAreaId INT,
  @FarmerId INT,
  @ImageUrl NVARCHAR(MAX),
  @ImageUrlID NVARCHAR(200),
  @Lng DECIMAL(19,16),
  @Lat DECIMAL(19,16),
  @Validation INT OUTPUT
AS
BEGIN
  -- CHECK IF FARM EXIST WHEN UPDATING
  IF @FarmId IS NOT NULL AND  NOT EXISTS ( SELECT TOP 1 * FROM Farms WHERE FarmId = @farmId AND FarmerId = @farmerId)
    BEGIN
      SET @Validation = 5001
    END

  -- CHECK IF FARM STATUS IS PENDING
  ELSE IF @FarmId IS NOT NULL AND ( SELECT [Status] FROM Farms WHERE FarmId = @farmId AND FarmerId = @farmerId) <> 'Pending'
    BEGIN
      SET @Validation = 5002
    END

  -- CHECK IF BARANGAY EXIST
  ELSE IF NOT EXISTS ( SELECT TOP 1 * FROM Barangays WHERE BarangayId = @BarangayId)
    BEGIN
      SET @Validation = 1001
    END 

  -- CHECK IF AREA EXIST
  ELSE IF NOT EXISTS ( SELECT TOP 1 * FROM BarangayAreas WHERE BarangayAreaId = @BarangayAreaId)
    BEGIN
      SET @Validation = 2001
    END
    
  -- INSERT
  ELSE IF @FarmId IS NULL
    BEGIN
      INSERT INTO Farms
        ([FarmerId],[Address],[BarangayId],[BarangayAreaId],[AreaSize],[Name],[Status],[Lng],[Lat],[ImageUrl],[ImageUrlId])
      VALUES
        (@FarmerId, @StreetAddress, @BarangayId, @BarangayAreaId, @AreaSize, @Name, 'Pending',@Lng, @Lat, @ImageUrl, @ImageUrlID)

        SET @FarmId = SCOPE_IDENTITY()
    END

  -- UPDATE
  ELSE
    BEGIN
      UPDATE Farms
      SET
        [Address] = @StreetAddress,
        [BarangayId] = @BarangayId,
        [BarangayAreaId] = @BarangayAreaId,
        [AreaSize] = @AreaSize,
        [Name] = @Name,
        [Lng] = @Lng,
        [Lat] = @Lat,
        [ImageUrl] = @ImageUrl,
        [ImageUrlId] = @ImageUrlID
      WHERE FarmId = @FarmId
    END

  
  SELECT ISNULL(@FarmId,0);
END
