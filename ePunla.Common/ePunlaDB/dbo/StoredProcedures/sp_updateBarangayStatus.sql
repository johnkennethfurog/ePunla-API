CREATE PROCEDURE [dbo].[sp_updateBarangayStatus]
  @barangayId INT,
  @isActive BIT,
  @Validation INT OUTPUT
AS
BEGIN
    -- CHECK IF BARANGAY EXIST
  IF NOT EXISTS ( SELECT TOP 1 * FROM Barangays WHERE BarangayId = @barangayId)
    BEGIN
      SET @Validation = 1001
    END
  ELSE 
    BEGIN
      UPDATE Barangays Set [IsActive] = @isActive WHERE barangayId = @barangayId
    END
END
