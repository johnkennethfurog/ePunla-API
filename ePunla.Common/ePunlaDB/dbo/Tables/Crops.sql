CREATE TABLE [dbo].[Crops] (
    [CropId]     INT            IDENTITY (1, 1) NOT NULL,
    [CategoryId] INT            NULL,
    [Duration]   INT            NOT NULL,
    [Name]       NVARCHAR (200) NULL,
    CONSTRAINT [PK_Crops] PRIMARY KEY CLUSTERED ([CropId] ASC),
    CONSTRAINT [FK_Crops_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Categories] ([CategoryId])
);


GO

CREATE NONCLUSTERED INDEX [IX_Crops_CategoryId]
    ON [dbo].[Crops]([CategoryId] ASC);


GO

