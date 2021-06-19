CREATE PROCEDURE [dbo].[sp_validateFarm]
  @farmId INT,
  @isApproved BIT,
  @remarks NVARCHAR(500),
  @Validation INT OUTPUT
AS
BEGIN

  -- CHECK IF FARM EXIST WHEN UPDATING
  IF NOT EXISTS ( SELECT TOP 1 * FROM Farms WHERE FarmId = @farmId)
    BEGIN
      SET @Validation = 5001
    END

  -- CHECK IF FARM STATUS IS PENDING
  ELSE IF (SELECT [Status] FROM Farms WHERE FarmId = @farmId ) <> 'Pending'
    BEGIN
      SET @Validation = 5002
    END

  ELSE
    BEGIN

      DECLARE @farmerId INT
      DECLARE @status NVARCHAR(50)

      SELECT @farmerId = FarmerId FROM Farms WHERE FarmId = @farmId
      SELECT @status = [Status] FROM Farmers where FarmerId = @farmerId

      UPDATE Farms SET 
        [Remarks] = @remarks,
        [ValidationDate] = GETDATE(),
        [Status] = CASE @isApproved 
                      WHEN 1 THEN 'Approved'
                      WHEN 0 THEN 'Rejected'
                    END
      WHERE FarmId = @farmId

      IF @isApproved = 1 AND @status = 'Pending'
        BEGIN
          UPDATE Farmers 
          SET 
            [Status] = 'Confirmed',
            [ValidationDate] = GETDATE()
          WHERE FarmerId  = @farmerId
        END
      
    END
END
