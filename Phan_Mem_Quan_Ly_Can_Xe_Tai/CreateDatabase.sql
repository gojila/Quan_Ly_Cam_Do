USE [PhanMemCanXeTai]
GO
/****** Object:  Table [dbo].[PhieuCan]    Script Date: 16/02/2020 11:38:45 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuCan](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[SoPhieu] [nvarchar](250) NULL,
	[Ngay] [date] NULL,
	[SoXe] [nvarchar](250) NULL,
	[KhachHang] [nvarchar](250) NULL,
	[Loaihang] [nvarchar](250) NULL,
	[NgayCan1] [datetime] NULL,
	[NgayCan2] [datetime] NULL,
	[TrongLuongCan1] [money] NULL,
	[TrongLuongCan2] [money] NULL,
	[TrongLuongHang] [money] NULL,
	[XuatNhap] [nvarchar](250) NULL,
	[GhiChu] [nvarchar](250) NULL,
	[Status] [int] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedUser] [int] NULL,
	[UpdatedDate] [datetime] NULL,
	[UpatedUser] [int] NULL,
 CONSTRAINT [PK__PhieuCan__3214EC07DC36C96D] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
