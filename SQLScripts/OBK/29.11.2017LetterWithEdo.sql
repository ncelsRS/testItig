USE [ncels]
GO
/****** Object:  Table [dbo].[OBK_LetterAttachments]    Script Date: 29.11.2017 22:10:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OBK_LetterAttachments](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[AttachmentName] [nvarchar](100) NULL,
	[ContentFile] [varbinary](max) NULL,
	[LetterId] [bigint] NULL,
	[SignXmlBigData] [nvarchar](max) NULL,
 CONSTRAINT [PK_OBK_LetterAttachments] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OBK_LetterFromEdo]    Script Date: 29.11.2017 22:10:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OBK_LetterFromEdo](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[IdEdo] [nvarchar](50) NULL,
	[LetterPortalEdoID] [bigint] NULL,
	[LetterRegNomer] [nvarchar](50) NULL,
	[LetterRegDate] [datetime] NULL,
	[UserEdo] [nvarchar](100) NULL,
	[LetterText] [nvarchar](250) NULL,
 CONSTRAINT [PK_OBK_LetterFromEdo] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OBK_LetterPortalEdo]    Script Date: 29.11.2017 22:10:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OBK_LetterPortalEdo](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[LetterSentEdoDate] [datetime] NULL,
	[AuthorID] [uniqueidentifier] NULL,
	[LetterRegDate] [datetime] NULL,
	[LetterContent] [nvarchar](1000) NULL,
	[LetterStatusId] [int] NULL,
	[ContractId] [uniqueidentifier] NULL,
	[EdoRegNomer] [nvarchar](50) NULL,
	[EdoRegDate] [datetime] NULL,
	[OBKLetterRegID] [bigint] NULL,
 CONSTRAINT [PK_OBK_LetterPortalEdo] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OBK_LetterRegistration]    Script Date: 29.11.2017 22:10:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OBK_LetterRegistration](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[LetterRegName] [nvarchar](100) NULL,
	[LetterRegDate] [datetime] NULL,
 CONSTRAINT [PK_OBK_LetterRegistration] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[OBK_LetterPortalEdo] ADD  CONSTRAINT [DF_OBK_LetterPortalEdo_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[OBK_LetterFromEdo]  WITH CHECK ADD  CONSTRAINT [FK_OBK_LetterFromEdo_OBK_LetterPortalEdo] FOREIGN KEY([LetterPortalEdoID])
REFERENCES [dbo].[OBK_LetterPortalEdo] ([ID])
GO
ALTER TABLE [dbo].[OBK_LetterFromEdo] CHECK CONSTRAINT [FK_OBK_LetterFromEdo_OBK_LetterPortalEdo]
GO
ALTER TABLE [dbo].[OBK_LetterPortalEdo]  WITH CHECK ADD  CONSTRAINT [FK_OBK_LetterPortalEdo_OBK_Contract] FOREIGN KEY([ContractId])
REFERENCES [dbo].[OBK_Contract] ([Id])
GO
ALTER TABLE [dbo].[OBK_LetterPortalEdo] CHECK CONSTRAINT [FK_OBK_LetterPortalEdo_OBK_Contract]
GO
ALTER TABLE [dbo].[OBK_LetterPortalEdo]  WITH CHECK ADD  CONSTRAINT [FK_OBK_LetterPortalEdo_OBK_LetterRegistration] FOREIGN KEY([OBKLetterRegID])
REFERENCES [dbo].[OBK_LetterRegistration] ([ID])
GO
ALTER TABLE [dbo].[OBK_LetterPortalEdo] CHECK CONSTRAINT [FK_OBK_LetterPortalEdo_OBK_LetterRegistration]
GO
