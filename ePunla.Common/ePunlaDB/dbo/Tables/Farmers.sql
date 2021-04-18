CREATE TABLE [dbo].[Farmers] (
    [FarmerId]         INT            IDENTITY (1, 1) NOT NULL,
    [FirstName]        NVARCHAR (MAX) NULL,
    [LastName]         NVARCHAR (MAX) NULL,
    [StreetAddress]    NVARCHAR (MAX) NULL,
    [BarangayId]       INT            NULL,
    [MobileNumber]     NVARCHAR (MAX) NULL,
    [Password]         NVARCHAR (MAX) NULL,
    [Avatar]           NVARCHAR (MAX) NULL,
    [AvatarId]         INT            NOT NULL,
    [RegistrationDate] DATETIME2 (7)  NOT NULL,
    [Status]           NVARCHAR (MAX) NULL,
    [ValidationDate]   DATETIME2 (7)  NOT NULL,
    [Remarks]          NVARCHAR (MAX) NULL,
    [BarangayAreaId]   INT            NULL,
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

