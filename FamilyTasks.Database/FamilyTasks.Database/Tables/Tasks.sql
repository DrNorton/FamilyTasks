CREATE TABLE [dbo].[Tasks]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [ProjectId] BIGINT NOT NULL, 
    [Name] NCHAR(20) NULL, 
    [Description] NCHAR(200) NULL, 
    [EmployeeUserId] BIGINT NULL, 
    CONSTRAINT [FK_Tasks_Projects] FOREIGN KEY ([ProjectId]) REFERENCES [Projects]([Id]),
	CONSTRAINT [FK_Tasks_Users] FOREIGN KEY ([EmployeeUserId]) REFERENCES [Users]([Id])
)
