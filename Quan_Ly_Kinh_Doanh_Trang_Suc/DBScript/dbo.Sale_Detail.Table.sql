USE [Quan_Ly_Kinh_Doanh_Trang_Suc]
GO
/****** Object:  Table [dbo].[Sale_Detail]    Script Date: 4/13/2023 1:24:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sale_Detail](
	[SaleDetailID] [bigint] IDENTITY(1,1) NOT NULL,
	[SaleID] [bigint] NOT NULL,
	[SaleCode] [nvarchar](250) NULL,
	[ItemBarcode] [nvarchar](4000) NULL,
	[ItemID] [bigint] NULL,
	[ItemCode] [bigint] NULL,
	[ItemName] [nvarchar](250) NULL,
	[GoldType] [nvarchar](250) NULL,
	[TotalWeight] [money] NULL,
	[GoldWeight] [money] NULL,
	[StoneWeight] [money] NULL,
	[Price] [money] NULL,
	[LaborFee] [money] NULL,
	[Amount] [money] NULL,
	[Descriptions] [nvarchar](250) NULL,
	[IsDeleted] [bit] NULL,
	[CreatedUserID] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedUserID] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[DeletedUserID] [int] NULL,
	[DeletedDate] [datetime] NULL,
 CONSTRAINT [PK_SaleDetail] PRIMARY KEY CLUSTERED 
(
	[SaleDetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
