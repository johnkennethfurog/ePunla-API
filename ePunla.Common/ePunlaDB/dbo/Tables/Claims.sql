CREATE TABLE [dbo].[Claims] (
    [ClaimId]        INT            IDENTITY (1, 1) NOT NULL,
    [FarmCropId]     INT            NULL,
    [FarmId]         INT            NULL,
    [FilingDate]     DATETIME2 (7)  NOT NULL,
    [DamagedArea]    NVARCHAR (MAX) NULL,
    [Description]    NVARCHAR (MAX) NULL,
    [PhotoUrl]       NVARCHAR (MAX) NULL,
    [PhotoId]        INT            NOT NULL,
    [Status]         NVARCHAR (MAX) NULL,
    [Remarks]        NVARCHAR (MAX) NULL,
    [ValidationDate] DATETIME2 (7)  NOT NULL,
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

