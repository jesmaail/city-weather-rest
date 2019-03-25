USE [Cities]
GO

/****** Object:  Table [dbo].[Cities]    Script Date: 25/03/2019 18:47:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Cities](
	[Id] int IDENTITY(1,1) PRIMARY KEY,
	[Name] [nvarchar](50) NOT NULL,
	[State] [nvarchar](50) NOT NULL,
	[Country] [nvarchar](50) NOT NULL,
	[Rating] [int] NOT NULL,
	[Established] [datetime] NOT NULL,
	[EstimatedPopulation] [int] NOT NULL,
) ON [PRIMARY]
GO


