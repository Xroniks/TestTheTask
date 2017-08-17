USE [Contragents]
GO

/****** Object:  Table [dbo].[Contragents]    Script Date: 17.08.2017 14:27:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Contragents](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NameContragent] [nvarchar](max) NULL,
	[Checkingaccount] [nvarchar](max) NULL,
	[Inn] [nvarchar](max) NULL,
	[Bik] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Contragents] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

