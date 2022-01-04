CREATE TABLE [dbo].[Users] (
    [UserId]    INT            IDENTITY (1, 1) NOT NULL,
    [Email] NVARCHAR (120) NOT NULL UNIQUE,
    [FirstName] NVARCHAR (MAX) NULL,
    [LastName]  NVARCHAR (MAX) NULL,
    [PasswordHash]  VARBINARY(1024)  NOT NULL,
    [PasswordSalt]  VARBINARY(1024)  NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([UserId] ASC)
);


GO

