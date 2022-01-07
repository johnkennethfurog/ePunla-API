CREATE TABLE [dbo].[Claims] (
    [ClaimId]        INT            IDENTITY (1, 1) NOT NULL,
    [FarmCropId]     INT            NOT NULL,
    [FarmId]         INT            NOT NULL,
    [FilingDate]     DATETIME2 (7)  NOT NULL,
    [DamagedArea]    NVARCHAR (20)  NOT NULL,
    [Description]    NVARCHAR (200) NULL,
    [PhotoUrl]       NVARCHAR (100) NULL,
    [PhotoId]        NVARCHAR(100)  NULL,
    [Status]         NVARCHAR (20)  NOT NULL,
    [ReferenceNumber]         NVARCHAR (20)  NULL,
    [Remarks]        NVARCHAR (500) NULL,
    [ValidationDate] DATETIME2 (7)  NULL,
    CONSTRAINT [PK_Claims] PRIMARY KEY CLUSTERED ([ClaimId] ASC),
    CONSTRAINT [FK_Claims_FarmCrops_FarmCropId] FOREIGN KEY ([FarmCropId]) REFERENCES [dbo].[FarmCrops] ([FarmCropId]),
    CONSTRAINT [FK_Claims_Farms_FarmId] FOREIGN KEY ([FarmId]) REFERENCES [dbo].[Farms] ([FarmId])
);


GO

CREATE NONCLUSTERED INDEX [IX_Claims_FarmCropId]
    ON [dbo].[Claims]([FarmCropId] ASC);


GO

CREATE NONCLUSTERED INDEX [IX_Claims_FarmId]
    ON [dbo].[Claims]([FarmId] ASC);


GO

