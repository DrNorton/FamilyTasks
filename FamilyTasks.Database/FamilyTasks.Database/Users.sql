CREATE TABLE [dbo].[User]
(
	[UserId] BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Email] NCHAR(320) NOT NULL, 
    [Password] NCHAR(100) NOT NULL, 
    [AvatarUrl] NCHAR(100) NULL, 
    [FirstName] NCHAR(30) NULL, 
    [LastName] NCHAR(30) NULL
	
)
