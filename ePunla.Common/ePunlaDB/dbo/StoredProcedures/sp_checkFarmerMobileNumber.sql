CREATE PROCEDURE [dbo].[sp_checkFarmerMobileNumber]
    @MobileNumber     NVARCHAR (20),
    @Validation       INT OUTPUT
AS
BEGIN
  IF EXISTS ( SELECT TOP 1 * FROM Farmers WHERE MobileNumber = @MobileNumber)
      BEGIN
        SET @Validation = 3001
      END
  ELSE
    BEGIN
      SELECT 1
    END
END
