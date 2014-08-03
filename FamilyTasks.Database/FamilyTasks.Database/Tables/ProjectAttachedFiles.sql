CREATE TABLE [dbo].[ProjectAttachedFiles]
(
	[Id] BIGINT NOT NULL PRIMARY KEY, 
    [AttachedFileId] BIGINT NOT NULL, 
    [ProjectId] BIGINT NOT NULL, 
    CONSTRAINT [FK_ProjectAttachedFiles_AttachedFiles] FOREIGN KEY ([AttachedFileId]) REFERENCES [AttachedFiles]([Id]) ON DELETE CASCADE,
	CONSTRAINT [FK_ProjectAttachedFiles_Projects] FOREIGN KEY ([ProjectId]) REFERENCES [Projects]([Id]),
)
