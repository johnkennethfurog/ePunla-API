CREATE TABLE [dbo].[BarangayAreas] (
    [BarangayAreaId] INT            IDENTITY (1, 1) NOT NULL,
    [BarangayId]     INT            NULL,
    [Name]           NVARCHAR (MAX) NULL,
    [IsActive]       BIT            NOT NULL,
    CONSTRAINT [PK_BarangayAreas] PRIMARY KEY CLUSTERED ([BarangayAreaId] ASC),
    CONSTRAINT [FK_BarangayAreas_Barangays_BarangayId] FOREIGN KEY ([BarangayId]) REFERENCES [dbo].[Barangays] ([BarangayId])
);


GO

CREATE NONCLUSTERED INDEX [IX_BarangayAreas_BarangayId]
    ON [dbo].[BarangayAreas]([BarangayId] ASC);


GO

