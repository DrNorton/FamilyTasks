﻿CREATE TABLE [dbo].[AttachedFiles]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Url] NCHAR(200) NULL, 
    [Type] NCHAR(10) NULL
)
