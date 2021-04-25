-- TEST DATA FOR BARAMGAY
DECLARE @barangays TABLE
(
    [BarangayId] INT,
    [Name]       NVARCHAR (MAX),
    [IsActive]   BIT 
);

INSERT INTO @barangays
SELECT 1, 'Barangay Uno',1
UNION SELECT 2, 'Barangay Dos',1
UNION SELECT 3, 'Barangay Tres',1

SET IDENTITY_INSERT [dbo].Barangays ON

MERGE Barangays as [TARGET]
USING @barangays as [SOURCE]
ON ([SOURCE].BarangayId = [TARGET].BarangayId)
WHEN NOT MATCHED 
    THEN INSERT (BarangayId,Name,IsActive) 
    VALUES ([SOURCE].BarangayId,[SOURCE].Name,[SOURCE].IsActive);

SET IDENTITY_INSERT [dbo].Barangays OFF

-- TEST DATA FOR BARANGAY AREA

DECLARE @barangayAreas TABLE
(
    [BarangayAreaId] INT,
    [BarangayId]     INT,
    [Name]           NVARCHAR (MAX),
    [IsActive]       BIT
);

INSERT INTO @barangayAreas
SELECT 1, 1 , 'Purok Uno',1
UNION SELECT 2,1, 'Purok Dos',1
UNION SELECT 3,1, 'Purok Tres',1
UNION SELECT 4,2, 'Purok Uno',1
UNION SELECT 5,2, 'Purok Dos',1
UNION SELECT 6,3, 'Purok Uno',1
UNION SELECT 7,3, 'Purok Dos',1

SET IDENTITY_INSERT [dbo].BarangayAreas ON

MERGE BarangayAreas as [TARGET]
USING @barangayAreas as [SOURCE]
ON ([SOURCE].BarangayAreaId = [TARGET].BarangayAreaId)
WHEN NOT MATCHED 
    THEN INSERT (BarangayAreaId,BarangayId,Name,IsActive) 
    VALUES ([SOURCE].BarangayAreaId,[SOURCE].BarangayId,[SOURCE].Name,[SOURCE].IsActive);

SET IDENTITY_INSERT [dbo].BarangayAreas OFF

-- TEST DATA FOR FARMERS
DECLARE @Farmers TABLE 
(
    [FarmerId]         INT,
    [FirstName]        NVARCHAR (MAX) ,
    [LastName]         NVARCHAR (MAX) ,
    [StreetAddress]    NVARCHAR (MAX) ,
    [BarangayId]       INT            ,
    [MobileNumber]     NVARCHAR (MAX) ,
    [PasswordHash]     VARBINARY(1024) ,
    [PasswordSalt]     VARBINARY(1024) ,
    [Avatar]           NVARCHAR (MAX) ,
    [AvatarId]         INT,
    [RegistrationDate] DATETIME2 (7),
    [Status]           NVARCHAR (MAX) ,
    [ValidationDate]   DATETIME2 (7) ,
    [Remarks]          NVARCHAR (MAX) ,
    [BarangayAreaId]   INT
);

DECLARE @pHash VARBINARY(1024) = 0xCEF09AFF1B8EFC61CD29A48A345E973DE8E8204BC7155E044D28F25C25F8969C5EF4986BCCF6DCC3348C07D986212B926E182C207A70747DF524BEEBB3764057;
DECLARE @pSalt VARBINARY(1024) = 0x2A079BE12FDA78A2A5F2EA7BFEF67503AA4BFB5712B03B271EFEC373D5D3328A6224BF72207574336FF897303104E35BD1F2B80E519301A58D7E831E517405BADC54BDE3B20F23CA11F6063DC5ADF4B98B1A07F1AAB59019B139A44AAE44FC1B877F08A575CD53F3A165FA7248612A5A691A8B20E3A5EA9A0D4CB6474A1A4AE0;



INSERT INTO @Farmers
SELECT 1,'Juan','Dela Cruz','Sapang Ciduad',1,'09994811893', @pHash , @pSalt ,NULL,NULL,'01-01-2021','Pending',NULL,'',1
UNION SELECT 2,'Ricky','Fernandez','B3 L5 PH9 Dugsongan st., Bongang Subd.',1,'09994811894',  @pHash , @pSalt,NULL,NULL,'01-01-2021','Pending',NULL,'',2
UNION SELECT 3,'Pedro','Penduko','Unit , Lot 56 Housing Village',1,'09994811895',  @pHash , @pSalt ,NULL,NULL,'01-01-2021','Confirmed',NULL,'',3


SET IDENTITY_INSERT [dbo].Farmers ON

MERGE Farmers as [TARGET]
USING @Farmers as [SOURCE]
ON ([SOURCE].FarmerId = [TARGET].FarmerId)
WHEN NOT MATCHED 
    THEN INSERT (FarmerId,FirstName,LastName,StreetAddress,BarangayId,MobileNumber,PasswordHash,PasswordSalt,Avatar,AvatarId,RegistrationDate,Status,ValidationDate,Remarks,BarangayAreaId) 
    VALUES ([SOURCE].FarmerId,[SOURCE].FirstName,[SOURCE].LastName,[SOURCE].StreetAddress,
            [SOURCE].BarangayId,[SOURCE].MobileNumber,[SOURCE].PasswordHash,[SOURCE].PasswordSalt,[SOURCE].Avatar,
            [SOURCE].AvatarId,[SOURCE].RegistrationDate,[SOURCE].Status,[SOURCE].ValidationDate,
            [SOURCE].Remarks,[SOURCE].BarangayAreaId);

SET IDENTITY_INSERT [dbo].Farmers OFF

-- TEST DATA FOR CROPS
DECLARE @crops TABLE
(
    [CropId]     INT,
    [CategoryId] INT,
    [Duration]   INT,
    [Name]       NVARCHAR (200)
);

INSERT INTO @crops
SELECT 1, 1, 50, 'Kalabasa'
UNION SELECT 2, 1, 25, 'Upo'
UNION SELECT 3, 1, 30, 'Ampalaya'
UNION SELECT 4, 1, 40, 'Patola'
UNION SELECT 5, 1, 15, 'Okra'
UNION SELECT 6, 1, 60, 'Labanos'
UNION SELECT 7, 1, 60, 'Patatas'
UNION SELECT 8, 1, 60, 'Sigarilyas'
UNION SELECT 9, 1, 60, 'Kangkong'
UNION SELECT 10, 1, 60, 'Sitaw'

UNION SELECT 11, 2, 25, 'Mansanas'
UNION SELECT 12, 2, 30, 'Buko'
UNION SELECT 13, 2, 40, 'Peras'
UNION SELECT 14, 2, 15, 'Orange'
UNION SELECT 15, 2, 60, 'Ubas'
UNION SELECT 16, 2, 60, 'Papaya'
UNION SELECT 17, 2, 60, 'Ponkan'
UNION SELECT 18, 2, 60, 'Dalandan'
UNION SELECT 19, 2, 60, 'Mangga'

SET IDENTITY_INSERT [dbo].Crops ON

MERGE Crops as [TARGET]
USING @crops as [SOURCE]
ON ([SOURCE].CropId = [TARGET].CropId)
WHEN NOT MATCHED 
    THEN INSERT (CropId,CategoryId,Duration,Name) 
    VALUES ([SOURCE].CropId,[SOURCE].CategoryId,[SOURCE].Duration,[SOURCE].Name);

SET IDENTITY_INSERT [dbo].Crops OFF

-- TEST DATA FOR FARMS
DECLARE @farms TABLE
(
    [FarmId]         INT,
    [FarmerId]       INT,
    [Address]        NVARCHAR (200),
    [BarangayId]     INT,
    [BarangayAreaId] INT,
    [AreaSize]       DECIMAL,
    [Name]           NVARCHAR (200),
    [Status]         NVARCHAR (20)
);

INSERT INTO @farms
SELECT 1, 1, 'Dimagiba street santo cristobal', 1, 1, 1050, 'The Farm', 'Approved'
UNION SELECT 2, 1, 'Phase 2 Resbakan street', 1, 1, 5000, 'The Farm Extension', 'Pending'
UNION SELECT 3, 2, 'Sityo Masantok, Manulas na lupa', 1, 2, 15000, 'The Big Farm', 'Approved'
UNION SELECT 4, 3, 'Unit , Lot 56 Housing Village', 1, 3, 500, 'The Penduko Farm', 'Approved'

SET IDENTITY_INSERT [dbo].Farms ON

MERGE Farms as [TARGET]
USING @farms as [SOURCE]
ON ([SOURCE].FarmId = [TARGET].FarmId)
WHEN NOT MATCHED 
    THEN INSERT([FarmId],[FarmerId],[Address],[BarangayId],[BarangayAreaId],[AreaSize],[Name],[Status]) 
    VALUES ([SOURCE].[FarmId],[SOURCE].[FarmerId],[SOURCE].[Address],[SOURCE].[BarangayId],[SOURCE].[BarangayAreaId],[SOURCE].[AreaSize],[SOURCE].[Name],[SOURCE].[Status]);

SET IDENTITY_INSERT [dbo].Farms OFF

-- TEST DATA FOR FARM CROPS
DECLARE @farmCrops TABLE
(
   [FarmCropId]            INT,
    [CropId]               INT,
    [FarmId]               INT,
    [CategoryId]           INT,
    [EstimatedHarvestDate] DATETIME2 (7),
    [PlantedDate]          DATETIME2 (7),
    [AreaSize]             DECIMAL,
    [Status]               NVARCHAR(20),
    [HarvestDate]          DATETIME2 (7) NULL
);

INSERT INTO @farmCrops
SELECT 1, 1, 1, 1, '12-01-2021', '01-01-2021', 500, 'Planted', NULL
UNION  SELECT 2, 2, 1, 1, '12-01-2021', '01-01-2021', 700, 'Harvested', '12-01-2021'
UNION SELECT 3, 3, 1, 1, '12-01-2021', '01-01-2021', 500, 'Planted', NULL
UNION SELECT 4, 4, 1, 1, '12-01-2021', '01-01-2021', 500, 'Planted', NULL

UNION  SELECT 5, 5, 2, 1, '12-01-2021', '01-01-2021', 700, 'Harvested', '12-01-2021'
UNION SELECT 6, 6, 2, 1, '12-01-2021', '01-01-2021', 500, 'Planted', NULL
UNION SELECT 7, 7, 2, 1, '12-01-2021', '01-01-2021', 500, 'Planted', NULL

UNION  SELECT 8, 8, 3, 1, '12-01-2021', '01-01-2021', 700, 'Harvested', '12-01-2021'
UNION SELECT 9, 9, 3, 1, '12-01-2021', '01-01-2021', 500, 'Planted', NULL
UNION SELECT 10, 10, 3, 1, '12-01-2021', '01-01-2021', 500, 'Planted', NULL

UNION  SELECT 11, 11, 4, 2, '12-01-2021', '01-01-2021', 700, 'Harvested', '12-01-2021'
UNION SELECT 12, 12, 4, 2, '12-01-2021', '01-01-2021', 500, 'Planted', NULL
UNION SELECT 13, 13, 4, 2, '12-01-2021', '01-01-2021', 500, 'Planted', NULL

SET IDENTITY_INSERT [dbo].FarmCrops ON

MERGE FarmCrops as [TARGET]
USING @farmCrops as [SOURCE]
ON ([SOURCE].FarmCropId = [TARGET].FarmCropId)
WHEN NOT MATCHED 
    THEN INSERT([FarmCropId],[CropId],[FarmId],[CategoryId],[EstimatedHarvestDate],[PlantedDate],[AreaSize],[Status],[HarvestDate]) 
    VALUES ([SOURCE].[FarmCropId],[SOURCE].[CropId],[SOURCE].[FarmId],[SOURCE].[CategoryId],[SOURCE].[EstimatedHarvestDate],[SOURCE].[PlantedDate],[SOURCE].[AreaSize],[SOURCE].[Status],[SOURCE].[HarvestDate]);

SET IDENTITY_INSERT [dbo].FarmCrops OFF