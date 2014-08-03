CREATE TABLE [dbo].[Profiles]
(
	[Id] BIGINT NOT NULL, 
    [Email] NCHAR(50) NULL, 
    [AvatarUrl] NCHAR(100) NULL, 
    [DisplayName] NCHAR(50) NULL, 
    CONSTRAINT [PK_Profiles] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_Profiles_USERS] FOREIGN KEY ([Id]) REFERENCES [Users]([Id])
	
    
    
)
