CREATE PROCEDURE [dbo].[sp_validateClaim]
  @claimId INT,
  @isApproved BIT,
  @remarks NVARCHAR(500),
  @Validation INT OUTPUT
AS
BEGIN

-- CHECK IF UPDATING AND CLAIM EXIST
  IF NOT EXISTS (SELECT TOP 1 * FROM Claims WHERE ClaimId = @claimId)
    BEGIN 
      SET @Validation = 7001;
    END

  -- CHECK IF UPDATING AND CLAIM CLAIM STATUS IS PENDING
  ELSE IF (SELECT [Status] FROM Claims WHERE ClaimId = @claimId) <> 'Pending'
    BEGIN
      SET @Validation = 7002;
    END

  ELSE
    BEGIN
      UPDATE Claims SET 
        [Remarks] = @remarks,
        [ValidationDate] = GETDATE(),
        [Status] =  CASE @isApproved 
                      WHEN 1 THEN 'Claimed'
                      WHEN 0 THEN 'Denied'
                    END
      WHERE ClaimId = @claimId
    END
END
