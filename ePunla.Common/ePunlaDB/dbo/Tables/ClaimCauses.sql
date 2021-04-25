CREATE TABLE [dbo].[ClaimCauses] (
    [ClaimCauseId]    INT            IDENTITY (1, 1) NOT NULL,
    [ClaimId]         INT            NULL,
    [DamageType]      NVARCHAR (MAX) NULL,
    [DamagedAreaSize] DECIMAL        NOT NULL,
    CONSTRAINT [PK_ClaimCauses] PRIMARY KEY CLUSTERED ([ClaimCauseId] ASC),
    CONSTRAINT [FK_ClaimCauses_Claims_ClaimId] FOREIGN KEY ([ClaimId]) REFERENCES [dbo].[Claims] ([ClaimId])
);


GO

CREATE NONCLUSTERED INDEX [IX_ClaimCauses_ClaimId]
    ON [dbo].[ClaimCauses]([ClaimId] ASC);


GO

