CREATE TABLE [dbo].[FarmCrops] (
    [FarmCropId]           INT            IDENTITY (1, 1) NOT NULL,
    [CropId]               INT            NULL,
    [FarmId]               INT            NULL,
    [CategoryId]           INT            NULL,
    [EstimatedHarvestDate] DATETIME2 (7)  NOT NULL,
    [PlantedDate]          DATETIME2 (7)  NOT NULL,
    [AreaSize]             INT            NOT NULL,
    [Status]               NVARCHAR (20) NULL,
    [HarvestDate]          DATETIME2 (7)  NULL,
    CONSTRAINT [PK_FarmCrops] PRIMARY KEY CLUSTERED ([FarmCropId] ASC),
    CONSTRAINT [FK_FarmCrops_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Categories] ([CategoryId]),
    CONSTRAINT [FK_FarmCrops_Crops_CropId] FOREIGN KEY ([CropId]) REFERENCES [dbo].[Crops] ([CropId]),
    CONSTRAINT [FK_FarmCrops_Farms_FarmId] FOREIGN KEY ([FarmId]) REFERENCES [dbo].[Farms] ([FarmId])
);


GO

CREATE NONCLUSTERED INDEX [IX_FarmCrops_CategoryId]
    ON [dbo].[FarmCrops]([CategoryId] ASC);


GO

CREATE NONCLUSTERED INDEX [IX_FarmCrops_CropId]
    ON [dbo].[FarmCrops]([CropId] ASC);


GO

CREATE NONCLUSTERED INDEX [IX_FarmCrops_FarmId]
    ON [dbo].[FarmCrops]([FarmId] ASC);


GO

