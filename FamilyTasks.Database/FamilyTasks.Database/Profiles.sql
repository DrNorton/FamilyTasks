create table [dbo].[Profiles]
(
	[UserId] [bigint] not null primary key, 
    [AvatarUrl] [nchar](100) null, 
    [FirstName] [nvarchar](30) null, 
    [LastName] [nvarchar](30) null
)
