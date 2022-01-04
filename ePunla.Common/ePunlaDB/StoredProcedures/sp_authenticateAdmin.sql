CREATE PROCEDURE [dbo].[sp_authenticateAdmin]
  @email NVARCHAR(100),
  @Validation INT OUTPUT
AS
BEGIN
  IF NOT EXISTS (SELECT TOP 1 FirstName FROM Users WHERE Email = @email)
    BEGIN
      SET @Validation = 1001
    END
  ELSE
    BEGIN
      SELECT [UserId],[PasswordHash],[PasswordSalt] FROM Users WHERE Email = @email
    END
END
