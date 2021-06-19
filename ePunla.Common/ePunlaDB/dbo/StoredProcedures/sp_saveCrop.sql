CREATE PROCEDURE [dbo].[sp_saveCrop]
  @cropId INT,
  @categoryId INT,
  @crop NVARCHAR(200),
  @duration INT,
  @Validation INT OUTPUT
AS
BEGIN

  -- FOR UPDATE AND CROP ID DOES NOT EXIST
  IF @cropId IS NOT NULL AND NOT EXISTS ( SELECT TOP 1 * FROM Crops WHERE cropId = @cropId)
    BEGIN
      SET @Validation = 6001
    END

  -- IF CROP NAME ALREADY EXIST
  ELSE IF EXISTS (SELECT TOP 1 * FROM Crops WHERE [Name] = @crop AND CropId <> ISNULL(@cropId,0))
    BEGIN
      SET @Validation = 6002
    END

  -- IF CATEGORY DOES NOT EXIST
  ELSE IF NOT EXISTS ( SELECT TOP 1 * FROM Categories WHERE CategoryId = @categoryId)
    BEGIN
      SET @Validation = 6003
    END

  -- INSERT
 ELSE IF @cropId IS NULL
    BEGIN
      INSERT INTO Crops
        ([CategoryId],[Name],[Duration])
      VALUES
        (@categoryId, @crop, @duration)

      SET @cropId = SCOPE_IDENTITY()
    END

  -- UPDATE
  ELSE
    BEGIN
      UPDATE Crops
      SET
        [CategoryId] = @categoryId,
        [Name] = @crop,
        [Duration] = @duration
      WHERE CropId = @cropId
    END

  
  SELECT ISNULL(@cropId,0);
END