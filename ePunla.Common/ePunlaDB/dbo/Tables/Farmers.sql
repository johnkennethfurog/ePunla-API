CREATE TABLE [dbo].[Farmers] (
    [FarmerId]         INT            IDENTITY (1, 1) NOT NULL,
    [FirstName]        NVARCHAR (100) NOT NULL,
    [LastName]         NVARCHAR (100) NOT NULL,
    [MiddleName]       NVARCHAR (100) NULL,
    [StreetAddress]    NVARCHAR (200) NOT NULL,
    [BarangayId]       INT            NOT NULL,
    [MobileNumber]     NVARCHAR(11)  NOT NULL,
    [PasswordHash]         VARBINARY(1024)  NOT NULL,
    [PasswordSalt]         VARBINARY(1024)  NOT NULL,
    [Avatar]           NVARCHAR (MAX) NULL,
    [AvatarId]         NVARCHAR(100)  NULL,
    [RegistrationDate] DATETIME2 (7)  NOT NULL,
    [Status]           NVARCHAR (20)  NOT NULL,
    [ValidationDate]   DATETIME2 (7)  NULL,
    [BarangayAreaId]   INT            NOT NULL,
    [IdentityDocumentUrl]  NVARCHAR (MAX) NULL,
    [IdentityDocumentId] NVARCHAR(100)  NULL,
    CONSTRAINT [PK_Farmers] PRIMARY KEY CLUSTERED ([FarmerId] ASC),
    CONSTRAINT [FK_Farmers_BarangayAreas_BarangayAreaId] FOREIGN KEY ([BarangayAreaId]) REFERENCES [dbo].[BarangayAreas] ([BarangayAreaId]),
    CONSTRAINT [FK_Farmers_Barangays_BarangayId] FOREIGN KEY ([BarangayId]) REFERENCES [dbo].[Barangays] ([BarangayId])
);


GO

CREATE NONCLUSTERED INDEX [IX_Farmers_BarangayAreaId]
    ON [dbo].[Farmers]([BarangayAreaId] ASC);


GO

CREATE NONCLUSTERED INDEX [IX_Farmers_BarangayId]
    ON [dbo].[Farmers]([BarangayId] ASC);


GO

