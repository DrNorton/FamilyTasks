﻿CREATE TABLE [dbo].[Users]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Phone] NVARCHAR(21) NOT NULL, 
	[Password] NVARCHAR(200) NOT NULL
)
