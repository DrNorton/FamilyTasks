CREATE TABLE [dbo].[Projects]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Name] NCHAR(50) NULL, 
    [CreatedUserId] BIGINT NOT NULL, 
    [Description] NCHAR(200) NULL, 
    [ProjectImageUrl] NCHAR(200) NULL, 
    CONSTRAINT [FK_Projects_ToUsers] FOREIGN KEY ([CreatedUserId]) REFERENCES [Users]([Id])
)
