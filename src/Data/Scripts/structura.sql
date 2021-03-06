USE [MariaDB]
GO
/****** Object:  Table [dbo].[Compaign]    Script Date: 6/3/2019 3:00:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Compaign](
	[IdCompaign] [int] IDENTITY(1,1) NOT NULL,
	[IdUser] [nvarchar](50) NULL,
	[Subject] [nvarchar](150) NULL,
	[NumberOfRecipients] [int] NULL,
	[Status] [bit] NULL,
	[DateCreated] [datetime] NULL,
 CONSTRAINT [PK_Compaign] PRIMARY KEY CLUSTERED 
(
	[IdCompaign] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 6/3/2019 3:00:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[IdUser] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NULL,
	[Name] [nvarchar](50) NULL,
	[DateCreated] [datetime] NULL,
	[Password] [nvarchar](100) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[IdUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Compaign] ON 

INSERT [dbo].[Compaign] ([IdCompaign], [IdUser], [Subject], [NumberOfRecipients], [Status], [DateCreated]) VALUES (5, N'edRDNq/bDCDOUrs8qRWSAw==', N'Campaña Mayo Madres', 5, 0, CAST(N'2019-06-03T13:47:25.307' AS DateTime))
INSERT [dbo].[Compaign] ([IdCompaign], [IdUser], [Subject], [NumberOfRecipients], [Status], [DateCreated]) VALUES (6, N'edRDNq/bDCDOUrs8qRWSAw==', N'Campaña Junio Padres', 5, 1, CAST(N'2019-06-03T13:47:57.870' AS DateTime))
INSERT [dbo].[Compaign] ([IdCompaign], [IdUser], [Subject], [NumberOfRecipients], [Status], [DateCreated]) VALUES (7, N'edRDNq/bDCDOUrs8qRWSAw==', N'Campaña Julio  Cometas', 15, 1, CAST(N'2019-06-03T13:48:29.220' AS DateTime))
INSERT [dbo].[Compaign] ([IdCompaign], [IdUser], [Subject], [NumberOfRecipients], [Status], [DateCreated]) VALUES (8, N'u4OFMSyNkax0MxDU16eRGEk390ZPg69hHkWFowdb8oI=', N'Campaña Julio  Cometas', 15, 1, CAST(N'2019-06-03T13:48:29.220' AS DateTime))
INSERT [dbo].[Compaign] ([IdCompaign], [IdUser], [Subject], [NumberOfRecipients], [Status], [DateCreated]) VALUES (9, N'u4OFMSyNkax0MxDU16eRGEk390ZPg69hHkWFowdb8oI=', N'Campaña Julio  Cometas', 15, 1, CAST(N'2019-06-03T13:48:29.220' AS DateTime))
SET IDENTITY_INSERT [dbo].[Compaign] OFF
INSERT [dbo].[User] ([IdUser], [Email], [Name], [DateCreated], [Password]) VALUES (N'CCzFD0szw5BOjVs5w1nB5h5BSn/b0Zb8awPvpvMumpw=', N'Ramon.Valdez@hotmail.com', N'Ramon Valdez', CAST(N'2019-06-03T14:33:30.713' AS DateTime), N'7nNNSNnRNahrA++m8y6anA==')
INSERT [dbo].[User] ([IdUser], [Email], [Name], [DateCreated], [Password]) VALUES (N'edRDNq/bDCDOUrs8qRWSAw==', N'test1@hot.com', N'test1', CAST(N'2019-06-03T12:32:19.423' AS DateTime), N'XkBNVPCqCFE=')
INSERT [dbo].[User] ([IdUser], [Email], [Name], [DateCreated], [Password]) VALUES (N'FlMcjknPyfDh5UOJjA1rsEk390ZPg69hHkWFowdb8oI=', N'Florinda.Meza@hotmail.com', N'Florinda Meza', CAST(N'2019-06-03T14:36:15.880' AS DateTime), N'K2KITAlGym8=')
INSERT [dbo].[User] ([IdUser], [Email], [Name], [DateCreated], [Password]) VALUES (N'u4OFMSyNkax0MxDU16eRGEk390ZPg69hHkWFowdb8oI=', N'Benito.Juarez@hotmail.com', N'Benito Juarez', CAST(N'2019-06-03T14:32:28.777' AS DateTime), N'K2KITAlGym8=')
ALTER TABLE [dbo].[Compaign]  WITH CHECK ADD  CONSTRAINT [FK_Compaign_User] FOREIGN KEY([IdUser])
REFERENCES [dbo].[User] ([IdUser])
GO
ALTER TABLE [dbo].[Compaign] CHECK CONSTRAINT [FK_Compaign_User]
GO
