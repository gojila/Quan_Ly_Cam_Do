/****** Object:  Table [dbo].[Category]    Script Date: 4/4/2023 11:22:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryID] [bigint] IDENTITY(1,1) NOT NULL,
	[CategoryCode] [nvarchar](250) NULL,
	[CategoryName] [nvarchar](250) NULL,
	[Descriptions] [nvarchar](250) NULL,
	[IsDeleted] [bit] NULL,
	[CreatedUserID] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedUserID] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[DeletedUserID] [int] NULL,
	[DeletedDate] [datetime] NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
