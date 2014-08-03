CREATE TABLE [dbo].[ProjectMembers]
(
	[Id] BIGINT NOT NULL PRIMARY KEY, 
    [ProjectId] BIGINT NOT NULL, 
    [MemberId] BIGINT NOT NULL, 
    CONSTRAINT [FK_ProjectMembers_Projects] FOREIGN KEY ([ProjectId]) REFERENCES [Projects]([Id]),
	CONSTRAINT [FK_ProjectMembers_Users] FOREIGN KEY ([MemberId]) REFERENCES [Users]([Id])
)
