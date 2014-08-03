create table [dbo].[Users]
(
	[Id] [bigint] not null primary key identity(1,1), 
    [Email] [nvarchar](320) null, 
    [Password] [nvarchar](100) not null,
	[Phone] [nvarchar](100) null
)
