CREATE PROCEDURE [dbo].[sp_getClaimCauses]
  @claimsId AS ClaimId READONLY
AS
BEGIN
  SELECT
    CC.ClaimCauseId,
    DT.DamageType,
    DT.DamageTypeId,
    CC.DamagedAreaSize,
    CC.ClaimId
  FROM ClaimCauses CC
  LEFT JOIN DamageType DT on DT.DamageTypeId = CC.DamageTypeId
  INNER JOIN  @claimsId CIds ON CIds.ClaimId = CC.[ClaimId]
END
