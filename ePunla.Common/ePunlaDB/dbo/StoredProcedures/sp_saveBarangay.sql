CREATE PROCEDURE [dbo].[sp_saveBarangay]
  @barangayId INT,
  @barangayName NVARCHAR(200),
  @areas AS BarangayArea READONLY,
  @Validation INT OUTPUT
AS
BEGIN
    -- IF UPDATING CHECK IF BARANGAY EXIST
  IF @barangayId IS NOT NULL AND NOT EXISTS ( SELECT TOP 1 * FROM Barangays WHERE BarangayId = @barangayId)
    BEGIN
      SET @Validation = 1001
    END 

  -- CHECK IF BARANGAY EXIST
  ELSE IF EXISTS ( SELECT TOP 1 * FROM Barangays WHERE [Name]=@barangayName AND BarangayId <> ISNULL(@barangayId,0))
    BEGIN
      SET @Validation = 1002
    END
  
  ELSE
    BEGIN
      -- INSERT
      IF @barangayId IS NULL
        BEGIN
          INSERT INTO Barangays ([Name]) VALUES (@barangayName)

          SET @barangayId = SCOPE_IDENTITY()
        END
      -- UPDATE
      ELSE
        BEGIN
          UPDATE Barangays SET [Name] = @barangayName WHERE BarangayId = @barangayId
        END

      -- INSERT/UPDATE AREA
      MERGE BarangayAreas T
      USING @areas S
      ON S.BarangayAreaId = T.BarangayAreaId AND T.BarangayId = @barangayId
      WHEN MATCHED THEN
        UPDATE SET T.[Name] = S.[Area], T.[IsActive] = S.[AreaIsActive]
      WHEN NOT MATCHED BY TARGET THEN
        INSERT ([Name],[BarangayId]) VALUES (S.[Area],@barangayId)
      WHEN NOT MATCHED BY SOURCE THEN
         UPDATE SET T.[IsActive] = 0;

      SELECT ISNULL(@barangayId,0);
    END
END