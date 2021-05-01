CREATE TABLE [dbo].[ClaimCauses] (
    [ClaimId]         INT NOT NULL,
    [DamageTypeId]    INT NOT NULL,
    [DamagedAreaSize] DECIMAL NOT NULL,
    CONSTRAINT [PK_ClaimCauses] PRIMARY KEY CLUSTERED ([DamageTypeId],[ClaimId] ASC),
    CONSTRAINT [FK_ClaimCauses_Claims_ClaimId] FOREIGN KEY ([ClaimId]) REFERENCES [dbo].[Claims] ([ClaimId]),
    CONSTRAINT [FK_ClaimCauses_DamageType_DamageTypeId] FOREIGN KEY ([DamageTypeId]) REFERENCES [dbo].[DamageType] ([DamageTypeId])
);


GO

CREATE NONCLUSTERED INDEX [IX_ClaimCauses_ClaimId]
    ON [dbo].[ClaimCauses]([ClaimId] ASC);


GO

