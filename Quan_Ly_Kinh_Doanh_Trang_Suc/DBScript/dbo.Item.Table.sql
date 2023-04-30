USE [Quan_Ly_Kinh_Doanh_Trang_Suc]
GO
/****** Object:  Table [dbo].[Item]    Script Date: 4/13/2023 1:24:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Item](
	[ItemID] [bigint] IDENTITY(1,1) NOT NULL,
	[ItemCode] [nvarchar](250) NULL,
	[ItemName] [nvarchar](250) NULL,
	[CategoryID] [bigint] NULL,
	[Descriptions] [nvarchar](250) NULL,
	[IsDeleted] [bit] NULL,
	[CreatedUserID] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedUserID] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[DeletedUserID] [int] NULL,
	[DeletedDate] [datetime] NULL,
 CONSTRAINT [PK_Item] PRIMARY KEY CLUSTERED 
(
	[ItemID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
