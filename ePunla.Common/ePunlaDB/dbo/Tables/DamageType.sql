CREATE TABLE [dbo].[DamageType]
(
  [DamageTypeId] INT IDENTITY (1, 1) NOT NULL,
  [DamageType] NVARCHAR(200),

  CONSTRAINT [PK_DamageType] PRIMARY KEY CLUSTERED ([DamageTypeId] ASC)
)
