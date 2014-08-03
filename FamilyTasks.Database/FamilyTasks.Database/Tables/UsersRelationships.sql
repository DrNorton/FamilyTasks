CREATE TABLE [dbo].[UsersRelationships]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [OwnerId] BIGINT NOT NULL, 
    [LinkedUserId] BIGINT NOT NULL, 
   	CONSTRAINT [FK_User_OwnerdId] FOREIGN KEY ([OwnerId]) REFERENCES [Users]([Id]),
	CONSTRAINT [FK_User_LinkedUserId] FOREIGN KEY ([LinkedUserId]) REFERENCES [Users]([Id])
)
