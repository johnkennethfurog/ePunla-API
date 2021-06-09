CREATE PROCEDURE [dbo].[sp_authenticateFarmer]
  @mobileNUmber NVARCHAR(11),
  @Validation INT OUTPUT
AS
BEGIN
  IF NOT EXISTS (SELECT TOP 1 FirstName FROM Farmers WHERE MobileNumber = @mobileNUmber)
    BEGIN
      SET @Validation = 1001
    END
  ELSE
    BEGIN
      SELECT [FarmerId],[FirstName],[lastName],[avatar],[status],[PasswordHash],[PasswordSalt],[Status] FROM Farmers WHERE MobileNumber = @mobileNUmber
    END
END
