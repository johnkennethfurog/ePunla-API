CREATE TABLE [dbo].[Barangays] (
    [BarangayId] INT            IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (MAX) NULL,
    [IsActive]   BIT            NOT NULL DEFAULT 1,
    [Lng]           DECIMAL(19,16),
    [Lat]           DECIMAL(19,16)
    CONSTRAINT [PK_Barangays] PRIMARY KEY CLUSTERED ([BarangayId] ASC)
);


GO

