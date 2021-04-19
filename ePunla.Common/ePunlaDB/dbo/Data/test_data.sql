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
    [Password]         NVARCHAR (MAX) ,
    [Avatar]           NVARCHAR (MAX) ,
    [AvatarId]         INT,
    [RegistrationDate] DATETIME2 (7),
    [Status]           NVARCHAR (MAX) ,
    [ValidationDate]   DATETIME2 (7) ,
    [Remarks]          NVARCHAR (MAX) ,
    [BarangayAreaId]   INT
);


INSERT INTO @Farmers
SELECT 1,'Juan','Dela Cruz','Sapang Ciduad',1,'09994811893','password',NULL,NULL,'01-01-2021','Pending',NULL,'',1
UNION SELECT 2,'Ricky','Fernandez','B3 L5 PH9 Dugsongan st., Bongang Subd.',1,'09994811894','password',NULL,NULL,'01-01-2021','Pending',NULL,'',2
UNION SELECT 3,'Pedro','Penduko','Unit , Lot 56 Housing Village',1,'09994811895','password',NULL,NULL,'01-01-2021','Confirmed',NULL,'',3


SET IDENTITY_INSERT [dbo].Farmers ON

MERGE Farmers as [TARGET]
USING @Farmers as [SOURCE]
ON ([SOURCE].FarmerId = [TARGET].FarmerId)
WHEN NOT MATCHED 
    THEN INSERT (FarmerId,FirstName,LastName,StreetAddress,BarangayId,MobileNumber,Password,Avatar,AvatarId,RegistrationDate,Status,ValidationDate,Remarks,BarangayAreaId) 
    VALUES ([SOURCE].FarmerId,[SOURCE].FirstName,[SOURCE].LastName,[SOURCE].StreetAddress,
            [SOURCE].BarangayId,[SOURCE].MobileNumber,[SOURCE].Password,[SOURCE].Avatar,
            [SOURCE].AvatarId,[SOURCE].RegistrationDate,[SOURCE].Status,[SOURCE].ValidationDate,
            [SOURCE].Remarks,[SOURCE].BarangayAreaId);

SET IDENTITY_INSERT [dbo].Farmers OFF
