USE [Auctions]
GO

/****** Object:  Table [dbo].[RegisteredOrganization]    Script Date: 08-11-2014 18:44:11 ******/
DROP TABLE [dbo].[RegisteredOrganization]
GO

/****** Object:  Table [dbo].[RegisteredOrganization]    Script Date: 08-11-2014 18:44:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[RegisteredOrganization](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[OrganizationName] [nvarchar](100) NOT NULL,
	[Address1] [nvarchar](100) NOT NULL,
	[Address2] [nvarchar](100) NULL,
	[Country] [nvarchar](100) NOT NULL,
	[Phone] [nvarchar](100) NOT NULL,
	[TimeZone] [nvarchar](50) NOT NULL,
	[ServicesOffered] [nvarchar](50) NOT NULL CONSTRAINT [DF_RegisteredOrganization_ServicesOffered]  DEFAULT (N'Selling'),
 CONSTRAINT [PK_RegisteredOrganization] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


ALTER TABLE [dbo].[RegisteredUsers] DROP CONSTRAINT [FK_RegisteredUsers_UserId]
GO

ALTER TABLE [dbo].[RegisteredUsers] DROP CONSTRAINT [FK_RegisteredOrganization_OrganizationId]
GO

/****** Object:  Table [dbo].[RegisteredUsers]    Script Date: 08-11-2014 18:44:25 ******/
DROP TABLE [dbo].[RegisteredUsers]
GO

/****** Object:  Table [dbo].[RegisteredUsers]    Script Date: 08-11-2014 18:44:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[RegisteredUsers](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NULL,
	[OrganizationId] [bigint] NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_RegisteredUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[RegisteredUsers]  WITH CHECK ADD  CONSTRAINT [FK_RegisteredOrganization_OrganizationId] FOREIGN KEY([OrganizationId])
REFERENCES [dbo].[RegisteredOrganization] ([Id])
GO

ALTER TABLE [dbo].[RegisteredUsers] CHECK CONSTRAINT [FK_RegisteredOrganization_OrganizationId]
GO

ALTER TABLE [dbo].[RegisteredUsers]  WITH CHECK ADD  CONSTRAINT [FK_RegisteredUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO

ALTER TABLE [dbo].[RegisteredUsers] CHECK CONSTRAINT [FK_RegisteredUsers_UserId]
GO


ALTER TABLE [dbo].[Auctions] DROP CONSTRAINT [FK_RegisteredUsers_BuyerId]
GO

ALTER TABLE [dbo].[Auctions] DROP CONSTRAINT [DF_Auctions_CreatedDateTime]
GO

/****** Object:  Table [dbo].[Auctions]    Script Date: 08-11-2014 18:44:56 ******/
DROP TABLE [dbo].[Auctions]
GO

/****** Object:  Table [dbo].[Auctions]    Script Date: 08-11-2014 18:44:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Auctions](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[BuyerId] [bigint] NOT NULL,
	[ItemName] [varchar](100) NOT NULL,
	[Description] [varchar](100) NOT NULL,
	[StartDateTime] [datetime] NOT NULL,
	[EndDateTime] [datetime] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_Auctions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Auctions] ADD  CONSTRAINT [DF_Auctions_CreatedDateTime]  DEFAULT (getdate()) FOR [CreatedDateTime]
GO

ALTER TABLE [dbo].[Auctions]  WITH CHECK ADD  CONSTRAINT [FK_RegisteredUsers_BuyerId] FOREIGN KEY([BuyerId])
REFERENCES [dbo].[RegisteredUsers] ([Id])
GO

ALTER TABLE [dbo].[Auctions] CHECK CONSTRAINT [FK_RegisteredUsers_BuyerId]
GO

ALTER TABLE [dbo].[Bids] DROP CONSTRAINT [FK_RegisteredUsers_SupplierId]
GO

ALTER TABLE [dbo].[Bids] DROP CONSTRAINT [FK_Bids_AuctionId]
GO

ALTER TABLE [dbo].[Bids] DROP CONSTRAINT [DF_Bids_CreatedDateTime]
GO

/****** Object:  Table [dbo].[Bids]    Script Date: 08-11-2014 18:45:15 ******/
DROP TABLE [dbo].[Bids]
GO

/****** Object:  Table [dbo].[Bids]    Script Date: 08-11-2014 18:45:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Bids](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[AuctionId] [bigint] NOT NULL,
	[SupplierId] [bigint] NOT NULL,
	[Amount] [decimal](18, 4) NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_Bids] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Bids] ADD  CONSTRAINT [DF_Bids_CreatedDateTime]  DEFAULT (getdate()) FOR [CreatedDateTime]
GO

ALTER TABLE [dbo].[Bids]  WITH CHECK ADD  CONSTRAINT [FK_Bids_AuctionId] FOREIGN KEY([AuctionId])
REFERENCES [dbo].[Auctions] ([Id])
GO

ALTER TABLE [dbo].[Bids] CHECK CONSTRAINT [FK_Bids_AuctionId]
GO

ALTER TABLE [dbo].[Bids]  WITH CHECK ADD  CONSTRAINT [FK_RegisteredUsers_SupplierId] FOREIGN KEY([SupplierId])
REFERENCES [dbo].[RegisteredUsers] ([Id])
GO

ALTER TABLE [dbo].[Bids] CHECK CONSTRAINT [FK_RegisteredUsers_SupplierId]
GO


ALTER TABLE [dbo].[LogActions] DROP CONSTRAINT [AspNetUsers_PerformedBy_Id]
GO

/****** Object:  Table [dbo].[LogActions]    Script Date: 08-11-2014 18:45:31 ******/
DROP TABLE [dbo].[LogActions]
GO

/****** Object:  Table [dbo].[LogActions]    Script Date: 08-11-2014 18:45:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[LogActions](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Controller] [nvarchar](50) NULL,
	[Action] [nvarchar](50) NULL,
	[Description] [nvarchar](100) NULL,
	[PerformedBy_Id] [nvarchar](128) NULL,
	[CreatedDateTime] [datetime] NULL CONSTRAINT [DF_LogActions_CreatedDateTime]  DEFAULT (getdate()),
 CONSTRAINT [PK_LogActions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[LogActions]  WITH CHECK ADD  CONSTRAINT [AspNetUsers_PerformedBy_Id] FOREIGN KEY([PerformedBy_Id])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO

ALTER TABLE [dbo].[LogActions] CHECK CONSTRAINT [AspNetUsers_PerformedBy_Id]
GO


