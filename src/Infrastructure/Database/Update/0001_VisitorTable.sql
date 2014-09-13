CREATE TABLE [dbo].[Visitor](
	[Id] [uniqueidentifier] NOT NULL,
	[PathAndQuerystring] [nvarchar](4000) NOT NULL,
	[LoginName] [nvarchar](255) NOT NULL,
	[Browser] [nvarchar](4000) NOT NULL,
	[VisitDate] [datetime] NOT NULL,
	[IpAddress] [nvarchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


