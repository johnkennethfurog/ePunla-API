CREATE PROCEDURE [dbo].[sp_getFarmerProfile]
  @farmerId int,
  @Validation INT OUTPUT
AS
BEGIN
  IF NOT EXISTS ( SELECT TOP 1 * FROM Farmers WHERE FarmerId = @farmerId)
    BEGIN
      SET @Validation = 3002
    END
  ELSE 
    BEGIN
      SELECT
        FarmerId,
        FirstName,
        LastName,
        MiddleName,
        StreetAddress,
        BarangayAreaId,
        BarangayId,
        MobileNumber,
        Avatar,
        AvatarId,
        [Status]
      FROM Farmers WHERE FarmerId = @farmerId
    END
END
