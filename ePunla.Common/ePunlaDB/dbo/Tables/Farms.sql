CREATE TABLE [dbo].[Farms] (
    [FarmId]         INT            IDENTITY (1, 1) NOT NULL,
    [FarmerId]       INT            NULL,
    [Address]        NVARCHAR (200) NULL,
    [BarangayId]     INT            NULL,
    [BarangayAreaId] INT            NULL,
    [AreaSize]       INT            NOT NULL,
    [Name]           NVARCHAR (200) NULL,
    [Status]         NVARCHAR (20) NULL,
    CONSTRAINT [PK_Farms] PRIMARY KEY CLUSTERED ([FarmId] ASC),
    CONSTRAINT [FK_Farms_BarangayAreas_BarangayAreaId] FOREIGN KEY ([BarangayAreaId]) REFERENCES [dbo].[BarangayAreas] ([BarangayAreaId]),
    CONSTRAINT [FK_Farms_Barangays_BarangayId] FOREIGN KEY ([BarangayId]) REFERENCES [dbo].[Barangays] ([BarangayId]),
    CONSTRAINT [FK_Farms_Farmers_FarmerId] FOREIGN KEY ([FarmerId]) REFERENCES [dbo].[Farmers] ([FarmerId])
);


GO

CREATE NONCLUSTERED INDEX [IX_Farms_FarmerId]
    ON [dbo].[Farms]([FarmerId] ASC);


GO

CREATE NONCLUSTERED INDEX [IX_Farms_BarangayAreaId]
    ON [dbo].[Farms]([BarangayAreaId] ASC);


GO

CREATE NONCLUSTERED INDEX [IX_Farms_BarangayId]
    ON [dbo].[Farms]([BarangayId] ASC);


GO

