CREATE PROCEDURE [dbo].[sp_getAdminProfile]
  @userId int,
  @Validation INT OUTPUT
AS
BEGIN
  IF NOT EXISTS ( SELECT TOP 1 * FROM Users WHERE UserId = @userId)
    BEGIN
      SET @Validation = 3002
    END
  ELSE 
    BEGIN
      SELECT
        FirstName,
        LastName,
        Email
      FROM Users WHERE UserId = @userId
    END
END
