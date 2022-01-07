CREATE PROCEDURE [dbo].[sp_validateClaim]
  @claimId INT,
  @isApproved BIT,
  @remarks NVARCHAR(500),
  @referenceNumber NVARCHAR(23),
  @Validation INT OUTPUT
AS
BEGIN

  DECLARE @ClaimedLiteral NVARCHAR(30) = 'Claimed';
  DECLARE @DeniedLiteral NVARCHAR(30) = 'Denied';
  DECLARE @PendingLiteral NVARCHAR(30) = 'Pending';
  DECLARE @ApprovedLiteral NVARCHAR(30) = 'Approved';

  DECLARE @claimStatus NVARCHAR(30);
  SELECT @claimStatus = [Status] FROM Claims WHERE ClaimId = @claimId

-- CHECK IF CLAIM EXIST
  IF NOT EXISTS (SELECT TOP 1 * FROM Claims WHERE ClaimId = @claimId)
    BEGIN 
      SET @Validation = 7001;
    END

  -- CHECK IF CLAIM STATUS IS ALREADY CLAIMED
  ELSE IF @claimStatus = @ClaimedLiteral
    BEGIN
      SET @Validation = 7005;
    END

  -- CHECK IF CLAIM STATUS IS ALREADY DENIED
  ELSE IF @claimStatus = @DeniedLiteral
    BEGIN
      SET @Validation = 7006;
    END

  -- CHECK IF CLAIM STATUS IS STILL PENDING
  ELSE IF @claimStatus = @PendingLiteral AND @isApproved = 1
    BEGIN 
      SET @Validation = 7007;
    END

  -- CHECK IF CLAIM STATUS IS ALREADY APPROVED
  ELSE IF @claimStatus = @ApprovedLiteral
    BEGIN
      SET @Validation = 7008;
    END

  ELSE
    BEGIN
      UPDATE Claims SET 
        [Remarks] = @remarks,
        [ValidationDate] = GETDATE(),
        [ReferenceNumber] = @referenceNumber,
        [Status] =  CASE @isApproved 
                      WHEN 1 THEN @ApprovedLiteral
                      WHEN 0 THEN @DeniedLiteral
                    END
      WHERE ClaimId = @claimId
    END
END
