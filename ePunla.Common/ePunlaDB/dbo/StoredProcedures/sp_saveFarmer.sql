CREATE PROCEDURE [dbo].[sp_saveFarmer]
    @FirstName        NVARCHAR (100),
    @LastName         NVARCHAR (100),
    @MiddleName         NVARCHAR (100),
    @StreetAddress    NVARCHAR (200),
    @BarangayId       INT,
    @MobileNumber     NVARCHAR (20),
    @PasswordHash     VARBINARY(1024),
    @PasswordSalt     VARBINARY(1024),
    @Avatar           NVARCHAR (MAX),
    @AvatarId         INT,
    @BarangayAreaId   INT,
    @Validation       INT OUTPUT
AS
  BEGIN
    IF NOT EXISTS ( SELECT TOP 1 * FROM Barangays WHERE BarangayId = @BarangayId)
      BEGIN
        SET @Validation = 1001
      END 
    ELSE IF NOT EXISTS ( SELECT TOP 1 * FROM BarangayAreas WHERE BarangayAreaId = @BarangayAreaId)
      BEGIN
        SET @Validation = 2001
      END
    ELSE IF EXISTS ( SELECT TOP 1 * FROM Farmers WHERE MobileNumber = @MobileNumber)
      BEGIN
        SET @Validation = 3001
      END
    ELSE
      BEGIN
        INSERT INTO Farmers
          ([FirstName],[LastName],[StreetAddress],[BarangayId],[MobileNumber],[MiddleName],
          [PasswordHash],[PasswordSalt],[Avatar],[AvatarId],[RegistrationDate],[Status],[BarangayAreaId])
        VALUES
          (@FirstName,@LastName,@StreetAddress,@BarangayId,@MobileNumber,@MiddleName,
          @PasswordHash, @PasswordSalt,@Avatar,@AvatarId,GETDATE(),'Pending',@BarangayAreaId)
      END
    
    SELECT ISNULL(SCOPE_IDENTITY(),0);
  END
