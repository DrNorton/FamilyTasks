CREATE TABLE [dbo].[TasksAttachedFiles]
(
	[Id] BIGINT NOT NULL PRIMARY KEY, 
    [AttachedFileId] BIGINT NOT NULL, 
    [TaskId] BIGINT NOT NULL, 
    CONSTRAINT [FK_TasksAttachedFile_AttachedFiles] FOREIGN KEY ([AttachedFileId]) REFERENCES [AttachedFiles]([Id]) ON DELETE CASCADE,
	CONSTRAINT [FK_TasksAttachedFile_Tasks] FOREIGN KEY ([TaskId]) REFERENCES [Tasks]([Id]),
)
