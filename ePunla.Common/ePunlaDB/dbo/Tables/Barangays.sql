CREATE TABLE [dbo].[Barangays] (
    [BarangayId] INT            IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (MAX) NULL,
    [IsActive]   BIT            NOT NULL DEFAULT 1,
    CONSTRAINT [PK_Barangays] PRIMARY KEY CLUSTERED ([BarangayId] ASC)
);


GO

