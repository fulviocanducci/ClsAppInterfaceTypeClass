USE [Database]
GO

/****** Object:  Table [dbo].[Trans]    Script Date: 05/04/2017 14:10:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Trans](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Value] [decimal](18, 2) NOT NULL,
	[Description] [nvarchar](50) NULL,
	[Number] [nvarchar](50) NULL,
	[Type] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Trans] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

