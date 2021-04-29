DECLARE @damageTypes TABLE (
    [DamageTypeId] INT ,
    [DamageType]   NVARCHAR(200)
);


INSERT INTO @damageTypes
SELECT 1,'Pest'
UNION SELECT 2, 'Rain'
UNION SELECT 3, 'Others'

SET IDENTITY_INSERT [dbo].DamageType ON

MERGE DamageType as [TARGET]
USING @damageTypes as [SOURCE]
ON ([SOURCE].DamageTypeId = [TARGET].DamageTypeId)
WHEN NOT MATCHED 
    THEN INSERT (DamageTypeId,DamageType) VALUES ([SOURCE].DamageTypeId, [SOURCE].DamageType);

SET IDENTITY_INSERT [dbo].DamageType OFF
